create table Users
(
    UserId int auto_increment primary key,
    Name   varchar(100) charset utf8 not null,
    Age    tinyint                   not null
);

INSERT INTO Users (UserId, Name, Age) VALUES (1, 'John Doe', 32);
INSERT INTO Users (UserId, Name, Age) VALUES (2, 'Jane Doe', 25);
INSERT INTO Users (UserId, Name, Age) VALUES (3, 'Janie Doe', 12);
INSERT INTO Users (UserId, Name, Age) VALUES (4, 'Janie Doe', 32);
INSERT INTO Users (UserId, Name, Age) VALUES (5, 'Danny James', 45);

INSERT INTO Users (UserId, Name, Age) VALUES (6, 'Rick Sanchez', 64);
INSERT INTO Users (UserId, Name, Age) VALUES (7, 'Morty Smith', 13);

INSERT INTO Users (UserId, Name, Age) VALUES (8, 'Jake Peralta', 28);