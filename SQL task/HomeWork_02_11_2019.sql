/* Task 11 */
SELECT AVG(speed)
FROM PC;

/* Task 12 */
SELECT AVG(speed)
FROM Laptop
WHERE price > 1000;

/* Task 13 */
SELECT AVG(speed)
FROM PC
INNER JOIN Product ON PC.model = Product.model
WHERE Product.maker = 'A';

/* Task 14 */
SELECT Classes.class
	,name
	,Classes.country
FROM Ships
INNER JOIN Classes ON Ships.class = Classes.class
WHERE numGuns >= 10;

/* Task 15 */
SELECT hd
FROM PC
GROUP BY hd
HAVING COUNT(hd) > 1;

/* Task 19 */
SELECT Product.maker
	,AVG(screen)
FROM Laptop
INNER JOIN Product ON product.model = Laptop.model
GROUP BY Product.maker;

/* Task 21 */
SELECT Product.maker AS Maker
	,MAX(PC.price) AS Max_price
FROM PC
INNER JOIN Product ON Product.model = PC.model
GROUP BY Product.maker;

/* Task 22 */
SELECT speed
	,AVG(price)
FROM PC
GROUP BY speed
HAVING speed > 600;

/* Task 28 */
SELECT COUNT(maker) AS qty
FROM Product
GROUP BY maker
HAVING COUNT(model) = 1;

/* Task 31 */
SELECT Classes.class
	,Classes.country
FROM Classes
WHERE bore >= 16;

/* Task 33 */
SELECT Outcomes.ship
FROM Battles
INNER JOIN Outcomes ON Outcomes.battle = Battles.name
WHERE Outcomes.result = 'sunk'
	AND Battles.name = 'North Atlantic';

/* Task 38 */
SELECT country
FROM Classes
WHERE type = 'bb'

INTERSECT

SELECT country
FROM Classes
WHERE type = 'bc';

/* Task 42 */
SELECT Outcomes.ship
	,Battles.name
FROM Outcomes
INNER JOIN Battles ON Outcomes.battle = Battles.name
WHERE Outcomes.result = 'sunk';

/* Task 44 */
SELECT name
FROM Ships
WHERE name LIKE 'R%'

UNION

SELECT ship
FROM Outcomes
WHERE ship LIKE 'R%';

/* Task 45 */
SELECT name
FROM Ships
WHERE name LIKE '% % %'

UNION

SELECT ship
FROM Outcomes
WHERE ship LIKE '% % %';

/* Task 49 */
SELECT name
FROM Ships
INNER JOIN Classes ON Classes.class = Ships.class
WHERE bore = 16

UNION

SELECT ship
FROM Outcomes
INNER JOIN Classes ON Classes.class = Outcomes.ship
WHERE bore = 16;

/* Task 50 */
SELECT DISTINCT (battle)
FROM Outcomes
INNER JOIN Ships ON Outcomes.ship = Ships.name
WHERE class = 'Kongo';
