create table Users
(
    UserId int auto_increment
        primary key,
    Name   varchar(100) charset utf8 not null,
    Age    tinyint                   not null
);

INSERT INTO UserDB.Users (UserId, Name, Age) VALUES (1, 'John Doe', 30);