CREATE TABLE `students` (
    `id` INT NOT NULL,
    `name` VARCHAR(100),
    `age` INT,
    PRIMARY KEY (`id`)
);

CREATE TABLE `courses` (
    `course_id` INT NOT NULL,
    `course_name` VARCHAR(100),
    PRIMARY KEY (`course_id`)
);