/* Task 1*/
-- Write an SQL script to create table Planets. Fill it with the values from the example

CREATE TABLE Planets (
	ID INT IDENTITY(1, 1) PRIMARY KEY
	,PlanetName VARCHAR(12)
	,Radius INT
	,SunSeason FLOAT
	,OpeningYear SMALLINT CHECK (
		OpeningYear > 0
		AND OpeningYear <= 2019
		)
	,HavingRings BIT
	,Opener VARCHAR(20)
	);

INSERT INTO Planets
VALUES (
	'Mars'
	,3396
	,687
	,1659
	,0
	,'Christiaan Huygens'
	)
	,(
	'Saturn'
	,60268
	,10759.22
	,NULL
	,1
	,NULL
	)
	,(
	'Neptune'
	,24764
	,60190
	,1846
	,1
	,'John Couch Adams'
	)
	,(
	'Mercury'
	,2439
	,115.88
	,1631
	,0
	,'Nicolaus Copernicus'
	)
	,(
	'Venus'
	,6051
	,243
	,1610
	,0
	,'Galileo Galilei'
	);

/* Task 2*/
-- Display records whose radius value (Radius) ranges from 3000 to 9000 
--Use the SQL WHERE clause 

SELECT *
FROM Planets
WHERE (
		Radius > 3000
		AND Radius < 9000
		);

/* Task 3*/
--Display the name of the planet (PlanetName), the year of its discovery (OpeningYear) and the name of the discoverer (Opener).
--Planets name does not start and does not end with the letter “s”.
--Use the SQL WHERE clause

SELECT PlanetName
	,OpeningYear
	,Opener
FROM Planets
WHERE (PlanetName NOT LIKE 's%s');

/* Task 4*/
--Display records of planets whose radius is less than 10000 and it was discovered (OpeningYear) after 1620.
--Use SQL WHERE clause 

SELECT *
FROM Planets
WHERE (
		Radius < 10000
		AND OpeningYear > 1620
		);

/* Task 5*/
--Display records of planets whose names begin with the letter "N"
--or end with the letter "s" and not having rings.
--Use SQL WHERE clause

SELECT *
FROM Planets
WHERE (
		PlanetName LIKE ('N%')
		OR PlanetName LIKE ('%s')
		)
	AND HavingRings = 0;

/* Task 6*/
--Change the name of the planet Neptune to Pluto.
--Use the SQL UPDATE clause

UPDATE Planets
SET PlanetName = 'Pluton'
WHERE PlanetName LIKE ('Neptune');

/* Task 7*/
--In the first three records of the table, change the value of the presence of rings (HavingRings) to "0".
--Use the SQL UPDATE clause

UPDATE Planets
SET HavingRings = 0
WHERE id < 4;

/* Task 8*/
--Insert records from the table Planets,that have rings into the table PlanetsWithRings.
--Use the SQL INTO clause

SELECT *
INTO PlanetsWithRings
FROM Planets
WHERE HavingRings = 1;

/* Task 9*/
Display the TABLE PlanetsWithRings.

SELECT *
FROM PlanetsWithRings;

/* Task 10*/
--Remove records from the table Planets without rings and with blank fields.
--Use the SQL UPDATE DELETE

DELETE
FROM Planets
WHERE HavingRings = 0
	AND ID IN (
		SELECT ID
		FROM Planets
		WHERE (
				PlanetName IS NULL
				OR Radius IS NULL
				OR SunSeason IS NULL
				OR OpeningYear IS NULL
				OR HavingRings IS NULL
				OR Opener IS NULL
				)
		)

/* Task from www.sql-ex.ru */
--Task1

SELECT model
	,speed
	,hd
FROM PC
WHERE price < 500;

--Task2

SELECT DISTINCT (maker)
FROM Product
WHERE type = 'Printer';

--Task3

SELECT model
	,ram
	,screen
FROM Laptop
WHERE price > 1000;

--Task4

SELECT *
FROM Printer
WHERE color = 'y';

--Task5

SELECT model
	,speed
	,hd
FROM PC
WHERE (
		cd = '12x'
		OR cd = '24x'
		)
	AND price < 600;
