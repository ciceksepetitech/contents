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
INSERT INTO Users (UserId, Name, Age) VALUES (9, 'Sheldon Cooper', 34);
INSERT INTO Users (UserId, Name, Age) VALUES (10, 'Eleanor Shellstrop', 35);
INSERT INTO Users (UserId, Name, Age) VALUES (11, 'Leonard Hotstadter', 21);
INSERT INTO Users (UserId, Name, Age) VALUES (12, 'Stuart Bloom', 47);
INSERT INTO Users (UserId, Name, Age) VALUES (13, 'Charles Boyle', 29);
INSERT INTO Users (UserId, Name, Age) VALUES (14, 'Ray Holt', 38);
INSERT INTO Users (UserId, Name, Age) VALUES (15, 'Luke Skywalker', 29);
INSERT INTO Users (UserId, Name, Age) VALUES (16, 'Jesse Pinkman', 16);