/* Task 21 */
--Write a query to display the employee name( first name and last name ) 
--and hire date for all employees in the same department as Clara. Exclude Clara.
SELECT CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
	,hire_date
FROM employees
WHERE department_id = (
		(
			SELECT department_id
			FROM employees
			WHERE first_name = 'Clara'
			)
		)
	AND emplyee_id <> (
		SELECT emplyee_id
		FROM employees
		WHERE first_name = 'Clara'
		);

/* Task 22 */
--Write a query to display the employee number and name( first name and last name )
--for all employees who work in a department with any employee whose name contains a T.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
FROM employees
WHERE department_id IN (
		SELECT department_id
		FROM employees
		WHERE first_name LIKE '%T%'
		);

/* Task 23 */
--Write a query to display the employee number, name( first name and last name ), 
--and salary for all employees who earn more  than the average salary and who 
--work in a department with any employee with a J in their name.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
	,salary
FROM employees
WHERE salary > (
		SELECT AVG(salary)
		FROM employees
		)
	AND department_id IN (
		SELECT department_id
		FROM employees
		WHERE first_name LIKE '%J%'
		);

/* Task 24 */
--Display the employee name( first name and last name ), employee id, 
--and job title for all employees whose department location is Toronto.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
	,emplyee_id
	,jobs.job_title
FROM employees
	,jobs
WHERE department_id IN (
		SELECT department_id
		FROM departments
		WHERE location_id = (
				SELECT location_id
				FROM locations
				WHERE city = 'Toronto'
				)
		)
	AND employees.job_id = jobs.job_id;

/* Task 25 */
--Write a query to display the employee number, name( first name and last name ) and job title for all employees 
--whose salary is smaller than any salary of those employees whose job title is MK_MAN.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
	,emplyee_id
	,job_id
FROM employees
WHERE salary < (
		SELECT salary
		FROM employees
		WHERE job_id = 'MK_MAN'
		);

/* Task 26 */
--Write a query to display the employee number, name( first name and last name ) and job title for all employees 
--whose salary is smaller than any salary of those employees whose job title is MK_MAN. Exclude Job title MK_MAN.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
	,emplyee_id
	,job_id
FROM employees
WHERE salary < (
		SELECT salary
		FROM employees
		WHERE job_id = 'MK_MAN'
		)
	AND job_id <> 'MK_MAN';

/* Task 27 */
--Write a query to display the employee number, name( first name and last name ) and job title for all employees whose 
--salary is more than any salary of those employees whose job title is PU_MAN. Exclude job title PU_MAN.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
	,emplyee_id
	,job_id
FROM employees
WHERE salary > (
		SELECT salary
		FROM employees
		WHERE job_id = 'PU_MAN'
		)
	AND job_id <> 'PU_MAN';

/* Task 28 */
--Write a query to display the employee number, name( first name and last name ) and job title for all employees whose 
--salary is more than any average salary of any department.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
	,emplyee_id
	,job_id
FROM employees
WHERE salary > ALL (
		SELECT AVG(salary)
		FROM employees
		GROUP BY department_id
		);

/* Task 29 */
--Write a query to display the employee name( first name and last name ) and department for all employees for any existence
--of those employees whose salary is more than 3700.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
	,department_id
FROM employees
WHERE EXISTS (
		SELECT *
		FROM employees
		WHERE salary > 3700
		);

/* Task 30 */
--Write a query to display the department id and the total salary for those departments which contains at least one employee.
SELECT department_id
	,SUM(salary)
FROM employees
GROUP BY department_id
HAVING COUNT(department_id) > 0;

/* Task 31 */
--Write a query to display the employee id, name ( first name and last name ) and the job id column with a modified title 
--SALESMAN for those employees whose job title is ST_MAN and DEVELOPER for whose job title is IT_PROG.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
	,job_id
	,CASE 
		WHEN job_id = 'ST_MAN'
			THEN 'SALESMAN'
		WHEN job_id = 'IT_PROG'
			THEN 'DEVELOPER'
		END 'job_title'
FROM employees;

/* Task 32 */
--Write a query to display the employee id, name ( first name and last name ), salary and the SalaryStatus column with 
--a title HIGH and LOW respectively for those employees whose salary is more than and less than the average salary of all employees.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
	,salary
	,CASE 
		WHEN salary > (
				SELECT AVG(salary)
				FROM employees
				)
			THEN 'HIGH'
		WHEN salary < (
				SELECT AVG(salary)
				FROM employees
				)
			THEN 'LOW'
		END 'SalaryStatus'
FROM employees;

/* Task 33*/
--Write a query to display the employee id, name ( first name and last name ), SalaryDrawn, 
--AvgCompare (salary - the average salary of all employees) and the SalaryStatus column with 
--a title HIGH and LOW respectively for those employees whose salary is more than and less 
--than the average salary of all employees.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
	,salary AS 'SalaryDrawn'
	,(
		salary - (
			SELECT AVG(salary)
			FROM employees
			)
		)
	,CASE 
		WHEN salary > (
				SELECT AVG(salary)
				FROM employees
				)
			THEN 'HIGH'
		WHEN salary < (
				SELECT AVG(salary)
				FROM employees
				)
			THEN 'LOW'
		END 'SalaryStatus'
FROM employees;

/* Task 34 */
--Write a subquery that returns a set of rows to find all departments that do actually have one
--or more employees assigned to them.
SELECT department_name
FROM departments
WHERE department_id IN (
		SELECT department_id
		FROM employees
		GROUP BY department_id
		HAVING COUNT(department_id) > 0
		);

/* Task 35 */
--Write a query that will identify all employees who work in departments located in the United Kingdom.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
	,emplyee_id
FROM employees
WHERE department_id IN (
		SELECT department_id
		FROM departments
		WHERE location_id IN (
				SELECT location_id
				FROM locations
				WHERE country_id = (
						SELECT country_id
						FROM countries
						WHERE country_name = 'United Kingdom'
						)
				)
		);

/* Task 36 */
--Write a query to determine who earns more than Mr. Ozer.
SELECT first_name
	,last_name
	,salary
FROM employees
WHERE salary > (
		SELECT salary
		FROM employees
		WHERE last_name = 'Ozer'
		);

/* Task 37 */
--Write a query to find out which employees have a manager who works for a department based in the US.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
FROM employees
WHERE manager_id IN (
		SELECT emplyee_id
		FROM employees
		WHERE department_id IN (
				SELECT department_id
				FROM departments
				WHERE location_id IN (
						SELECT location_id
						FROM locations
						WHERE country_id = 'US'
						)
				)
		);

/* Task 38 */
--Write a query which is looking for the names of all employees whose salary is greater than 50% of their
--department’s total salary bill.
SELECT CONCAT (
		emp_1.first_name
		,' '
		,emp_1.last_name
		) AS 'Full name'
FROM employees AS emp_1
WHERE salary > (
		SELECT 0.5 * SUM(salary) AS 'half'
		FROM employees AS emp_2
		WHERE emp_1.department_id = emp_2.department_id
		);

/* Task 39 */
--Write a query to get the details of employees who are managers.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
FROM employees
WHERE emplyee_id IN (
		SELECT DISTINCT (manager_id)
		FROM employees
		);

/* Task 40 */
--Write a query to get the details of employees who manage a department.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
FROM employees
WHERE emplyee_id IN (
		SELECT manager_id
		FROM departments
		);

/* Task 41 */
--Write a query to display the employee id, name ( first name and last name ), salary, department name and city 
--for all the employees who gets the salary as the salary earn by the employee which is maximum within 
--the joining person January 1st, 2002 and December 31st, 2003.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
	,salary
	,departments.department_name
	,locations.city
FROM employees
	,departments
	,locations
WHERE employees.department_id = departments.department_id
	AND departments.location_id = locations.location_id
	AND salary = (
		SELECT MAX(salary)
		FROM employees
		WHERE hire_date >= '2002-01-01'
			AND hire_date <= '2003-12-31'
		);

/* Task 42 */
--Write a query in SQL to display the department code and name for all departments which located in the city London.
SELECT department_id
	,department_name
FROM departments
WHERE location_id = (
		SELECT location_id
		FROM locations
		WHERE city = 'London'
		);

/* Task 43 */
--Write a query in SQL to display the first and last name, salary, and department ID for all those employees who earn
--more than the average salary and arrange the list in descending order on salary.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
	,salary
	,department_id
FROM employees
WHERE salary > (
		SELECT AVG(salary)
		FROM employees
		)
ORDER BY salary;

/* Task 44 */
--Write a query in SQL to display the first and last name, salary, and department ID for those employees who earn more 
--than the maximum salary of a department which ID is 40.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
	,salary
	,department_id
FROM employees
WHERE salary > (
		SELECT MAX(salary)
		FROM employees
		GROUP BY department_id
		HAVING department_id = 40
		);

/* Task 45 */
--Write a query in SQL to display the department name and Id for all departments where they located, that Id is equal to
--the Id for the location where department number 30 is located.
SELECT department_name
	,departments.department_id
	,locations.city
	,locations.location_id
FROM departments
	,locations
WHERE locations.location_id = (
		SELECT location_id
		FROM departments
		WHERE department_id = 30
		)
	AND departments.location_id = locations.location_id;

/* Task 46 */
--Write a query in SQL to display the first and last name, salary, and department ID for all those employees who work in 
--that department where the employee works who hold the ID 201.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
	,salary
	,department_id
FROM employees
WHERE department_id = (
		SELECT department_id
		FROM employees
		WHERE emplyee_id = 201
		);

/* Task 47 */
--Write a query in SQL to display the first and last name, salary, and department ID for those employees whose salary is 
--equal to the salary of the employee who works in that department which ID is 40.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
	,salary
	,department_id
FROM employees
WHERE salary = (
		SELECT salary
		FROM employees
		WHERE department_id = 40
		);

/* Task 48 */
--Write a query in SQL to display the first and last name, and department code for all employees who work in 
--the department Marketing.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
	,department_id
FROM employees
WHERE department_id = (
		SELECT department_id
		FROM departments
		WHERE department_name = 'Marketing'
		);

/* Task 49 */
-- Write a query in SQL to display the first and last name, salary, and department ID for those employees 
--who earn more than the minimum salary of a department which ID is 40.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
	,salary
	,department_id
FROM employees
WHERE salary > (
		SELECT MIN(salary)
		FROM employees
		GROUP BY department_id
		HAVING department_id = 40
		);

/* Task 50 */
--Write a query in SQL to display the full name,email, and designation for all those employees who was hired 
--after the employee whose ID is 165.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'Full name'
	,email
	,department_id
FROM employees
WHERE hire_date > (
		SELECT hire_date
		FROM employees
		WHERE emplyee_id = 165
		);
