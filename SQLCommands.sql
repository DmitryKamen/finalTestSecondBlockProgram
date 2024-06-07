-- Создание базы данных
CREATE DATABASE HumanFriends;

-- Использование базы данных
USE HumanFriends;

-- Создание таблицы для всех животных
CREATE TABLE Animals (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    BirthDate DATE NOT NULL,
    Type VARCHAR(50) NOT NULL,
    Commands VARCHAR(255)
);

-- Создание таблиц для домашних и вьючных животных
CREATE TABLE Pets (
    AnimalID INT,
    FOREIGN KEY (AnimalID) REFERENCES Animals(ID)
);

CREATE TABLE PackAnimals (
    AnimalID INT,
    FOREIGN KEY (AnimalID) REFERENCES Animals(ID)
);

-- Вставка данных
INSERT INTO Animals (Name, BirthDate, Type, Commands) VALUES 
('Fido', '2020-01-01', 'Dog', 'Sit, Stay, Fetch'),
('Whiskers', '2019-05-15', 'Cat', 'Sit, Pounce'),
('Hammy', '2021-03-10', 'Hamster', 'Roll, Hide'),
('Buddy', '2018-12-10', 'Dog', 'Sit, Paw, Bark'),
('Smudge', '2020-02-20', 'Cat', 'Sit, Pounce, Scratch'),
('Peanut', '2021-08-01', 'Hamster', 'Roll, Spin'),
('Bella', '2019-11-11', 'Dog', 'Sit, Stay, Roll'),
('Oliver', '2020-06-30', 'Cat', 'Meow, Scratch, Jump'),
('Thunder', '2015-07-21', 'Horse', 'Trot, Canter, Gallop'),
('Sandy', '2016-11-03', 'Camel', 'Walk, Carry Load'),
('Eeyore', '2017-09-18', 'Donkey', 'Walk, Carry Load, Bray'),
('Storm', '2014-05-05', 'Horse', 'Trot, Canter'),
('Dune', '2018-12-12', 'Camel', 'Walk, Sit'),
('Burro', '2019-01-23', 'Donkey', 'Walk, Bray, Kick'),
('Blaze', '2016-02-29', 'Horse', 'Trot, Jump, Gallop'),
('Sahara', '2015-08-14', 'Camel', 'Walk, Run');

-- Заполнение таблиц Pets и PackAnimals
INSERT INTO Pets (AnimalID)
SELECT ID FROM Animals WHERE Type IN ('Dog', 'Cat', 'Hamster');

INSERT INTO PackAnimals (AnimalID)
SELECT ID FROM Animals WHERE Type IN ('Horse', 'Camel', 'Donkey');

-- Удаление записей о верблюдах
DELETE FROM Animals WHERE Type = 'Camel';

-- Объединение таблиц лошадей и ослов в одну таблицу
CREATE TABLE HorseAndDonkey AS
SELECT * FROM Animals WHERE Type IN ('Horse', 'Donkey');

-- Создание таблицы для животных в возрасте от 1 до 3 лет
CREATE TABLE YoungAnimals AS
SELECT *, TIMESTAMPDIFF(MONTH, BirthDate, CURDATE()) AS AgeInMonths
FROM Animals
WHERE TIMESTAMPDIFF(YEAR, BirthDate, CURDATE()) BETWEEN 1 AND 3;

-- Объединение всех созданных таблиц в одну, сохраняя информацию о принадлежности к исходным таблицам
CREATE TABLE AllAnimals AS
SELECT *, 'Pets' AS OriginTable FROM Pets
JOIN Animals ON Pets.AnimalID = Animals.ID
UNION ALL
SELECT *, 'PackAnimals' AS OriginTable FROM PackAnimals
JOIN Animals ON PackAnimals.AnimalID = Animals.ID
UNION ALL
SELECT *, 'HorseAndDonkey' AS OriginTable FROM HorseAndDonkey;