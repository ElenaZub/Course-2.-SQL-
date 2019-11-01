CREATE DATABASE ComputerFirm;

CREATE TABLE Product (
	maker VARCHAR(10)
	,model VARCHAR(50) PRIMARY KEY
	,type VARCHAR(50)
	);

CREATE TABLE PC (
	code INT PRIMARY KEY
	,model VARCHAR(50)
	,speed SMALLINT
	,ram SMALLINT
	,hd REAL
	,cd VARCHAR(50)
	,price MONEY
	,FOREIGN KEY (model) REFERENCES Product(model)
	);

CREATE TABLE Laptop (
	code INT PRIMARY KEY
	,model VARCHAR(50)
	,speed SMALLINT
	,ram SMALLINT
	,hd REAL
	,price MONEY
	,screen TINYINT
	,FOREIGN KEY (model) REFERENCES Product(model)
	);

CREATE TABLE Printer (
	code INT PRIMARY KEY
	,model VARCHAR(50)
	,color CHAR(1)
	,type VARCHAR(10)
	,price MONEY
	,FOREIGN KEY (model) REFERENCES Product(model)
	);

--Task 6

SELECT DISTINCT (maker) AS Maker
	,speed
FROM Product
INNER JOIN Laptop ON Laptop.model = Product.model
WHERE Laptop.hd >= 10

--Task 7

SELECT PC.model
	,PC.price
FROM PC
INNER JOIN Product ON PC.model = Product.model
WHERE Product.maker = 'B'

UNION

SELECT Laptop.model
	,Laptop.price
FROM Laptop
INNER JOIN Product ON Laptop.model = Product.model
WHERE Product.maker = 'B'

UNION

SELECT Printer.model
	,Printer.price
FROM Printer
INNER JOIN Product ON Printer.model = Product.model
WHERE Product.maker = 'B'

--Task8

SELECT DISTINCT (maker) AS Maker
FROM Product
INNER JOIN PC ON Product.model = PC.model

EXCEPT

SELECT maker AS Maker
FROM Product
INNER JOIN Laptop ON Product.model = Laptop.model

--Task 9

SELECT DISTINCT(maker)
FROM Product
INNER JOIN PC ON Product.model = PC.model
WHERE PC.speed >= 450

--Task 10

SELECT DISTINCT model
	,price
FROM Printer
WHERE price = (
		SELECT MAX(price)
		FROM Printer
		)
