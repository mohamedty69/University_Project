import time 
import os

from dotenv import load_dotenv
from openai import OpenAI, APIError, APIConnectionError


client = None
load_dotenv()


def main():
    global client
    client = get_client()
    print(get_completion("Explain the enrollment process."))


def handle_deepseek_errors(func):
    """
    Decorator to handle DeepSeek API errors and retry logic.
    """
    def wrapper(*args, **kwargs):
        max_retries = 3
        retry_delay = 2

        for attempt in range(max_retries):
            try:
                return func(*args, **kwargs)
            except APIError as e:
                error_data = e.response.json() if e.response else {}
                error_message = error_data.get('error', {}).get('message', 'Unknown error')
                error_code = e.status_code
                
                if error_code == 401: 
                    print("401 Error: Authentication Failed.\nVerify your API key.")
                    return "Authentication Error - Check API credentials"
                
                elif error_code == 402:
                    print("402 Error: Insufficient Balance.\nAdd funds to your account.")
                    return "Account Balance Depleted - Please top up"
                
                elif error_code == 422:
                    print("422 Error: Invalid Parameters.\nCheck token parameters.")
                    return "Invalid parameters provided"
                
                elif error_code == 429:
                    wait_time = 2 ** (attempt + 1)
                    print(f"429 Error: Rate Limit Exceeded. Retrying in {wait_time}s...")
                    time.sleep(wait_time)
                    continue

                elif error_code == 500:
                    print("500 Error: Internal Server Error. Retrying...")
                    if attempt < max_retries - 1:
                        time.sleep(retry_delay)
                        continue
                    return "Internal Server Error - Please try again later"
                
                elif error_code == 503:
                    print("503 Error: Serever is overloaded. Retrying...")
                    if attempt < max_retries - 1:
                        time.sleep(retry_delay)
                        continue
                    print("Server is overloaded, switch to backup provider.")
                    return "Server Overloaded - Please try again later"
                
                else:
                    print(f"Unexpected Error {error_code}: {error_message}")
                    return "Unexpected error occurred"
                
            except APIConnectionError  as e:
                print(f"Connection Error: {str(e)}")
                if attempt < max_retries - 1:
                    print(f"Retrying in {retry_delay}s...")
                    time.sleep(retry_delay)
                    continue
                return "Network connection failed"
            
        return "Maximum retries exceeded. Please try again later."
    return wrapper


def get_client():
    """
    Initialize the OpenAI client with the API key and base URL.
    """
    api_key = os.getenv("DEEPSEEK_API_KEY")
    if not api_key:
        raise ValueError("""
        Missing API key! Please:
        1. Create .env file
        2. Add DEEPSEEK_API_KEY=your_key
        """)
    
    return OpenAI(api_key=api_key,
        base_url=os.getenv("BASE_URL", "https://api.deepseek.com/v1")
    )


@handle_deepseek_errors
def get_completion(user_prompt):
    """
    Get a response from the DeepSeek API based on the user prompt.
    """
    with open("context.txt", 'r') as file:
        system_prompt = file.read()
        
    response = client.chat.completions.create(
        model="deepseek/deepseek-chat-v3-0324:free",
        messages=[{"role": "system", "content": system_prompt}, 
                    {"role": "user", "content": user_prompt}], 
        temperature=0.3, top_p=0.6, 
        frequency_penalty=0.4, presence_penalty=0.2,
        max_tokens=400,
    )
    return(response.choices[0].message.content)


if __name__ == "__main__":
    main()