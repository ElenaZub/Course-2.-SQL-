/*Task 1*/
--Write a query in SQL to display the full name (first and last), hire date, salary, 
--and department number for those employees whose first name does not containing the letter M and make the result set in ascending order by department number. 
SELECT CONCAT (
		first_name
		,last_name
		) AS full_name
	,hire_date
	,salary
	,department_id
FROM employees
WHERE first_name NOT LIKE '%M%'
ORDER BY department_id;

/*Task 2*/
--Write a query in SQL to display all the information of employees whose salary is in the range of 8000 and 12000 and commission is not null or department number
--is except the number 40, 120 and 70 and they have been hired before June 5th, 2002.
SELECT *
FROM employees
WHERE salary BETWEEN 8000
		AND 12000
	AND commission_pct IS NOT NULL
	OR department_id NOT IN (
		40
		,120
		,70
		)
	AND hire_date < '2002-06-05';

/*Task 3*/
--Write a query in SQL to display the full name (first and last), the phone number and email separated by hyphen, and salary, for those employees whose salary is
--within the range of 9000 and 17000. The column headings assign with Full_Name, Contact_Details and Remuneration respectively.
SELECT CONCAT (
		first_name
		,last_name
		) AS full_name
	,CONCAT (
		phone_number
		,'-'
		,email
		) AS 'concat_details'
	,salary AS 'renumeration'
FROM employees
WHERE salary BETWEEN 9000
		AND 17000;

/*Task 4*/
--Write a query in SQL to display the full name (first and last) name, and salary, for all employees whose salary is out of the range 7000 and 15000 and make the
--result set in ascending order by the full name
SELECT CONCAT (
		first_name
		,last_name
		) AS full_name
	,CONCAT (
		phone_number
		,'-'
		,email
		) AS 'concat_details'
	,salary AS 'renumeration'
FROM employees
WHERE salary NOT BETWEEN 7000
		AND 15000;

/*Task 5*/
--Write a query in SQL to display the full name (first and last), job id and date of hire for those employees who was hired during November 5th, 2007 and July 5th, 2009
SELECT CONCAT (
		first_name
		,last_name
		) AS full_name
	,job_id
	,hire_date
FROM employees
WHERE hire_date BETWEEN '2007-11-05'
		AND '2009-07-05';

/*Task 6*/
--Write a query in SQL to display the full name (first name and last name), hire date, commission percentage, email and telephone separated by '-', and salary for those
--employees who earn the salary above 11000 or the seventh digit in their phone number equals 3 and make the result set in a descending order by the first name.
SELECT CONCAT (
		first_name
		,last_name
		) AS full_name
	,hire_date
	,commission_pct
	,CONCAT (
		phone_number
		,'-'
		,email
		) AS 'concat_details'
	,salary
FROM employees
WHERE salary > 11000
	OR phone_number LIKE '_______3%'
ORDER BY first_name DESC;

/*Task 7*/
--Write a query in SQL to display the employee ID, first name, job id, and department number for those employees who is working except the departments 50,30 and 80.
SELECT emplyee_id
	,first_name
	,job_id
	,department_id
FROM employees
WHERE department_id NOT IN (
		50
		,30
		,80
		);

/*Task 8*/
--Write a query in SQL to display the ID for those employees who did two or more jobs in the past.
SELECT employee_id
FROM job_history
GROUP BY employee_id
HAVING COUNT(employee_id) > 1;

/*Task 9*/
--Write a query to display the name ( first name and last name ) for those employees who gets more salary than the employee whose ID is 163.
SELECT CONCAT (
		first_name
		,' '
		,last_name
		) AS 'full name'
FROM employees
WHERE salary > (
		SELECT salary
		FROM employees
		WHERE emplyee_id = 163
		);

/*Task 10*/
-- Write a query to display the name ( first name and last name ), salary, department id, job id for those employees who works in the same 
--designation as the employee works whose id is 169. 
SELECT CONCAT (
		first_name
		,' '
		,last_name
		) AS 'full name'
	,salary
	,department_id
	,job_id
FROM employees
WHERE department_id = (
		SELECT department_id
		FROM employees
		WHERE emplyee_id = 169
		);

/*Task 11*/
--Write a query to display the name ( first name and last name ), salary, department id for those employees who earn such amount of salary 
--which is the smallest salary of any of the departments.
SELECT CONCAT (
		first_name
		,' '
		,last_name
		) AS 'full name'
	,salary
	,department_id
	,job_id
FROM employees
WHERE salary = (
		SELECT DISTINCT MIN(salary) AS salary_1
		FROM employees
		);

/*Task 12*/
--Write a query to display the employee id, employee name (first name and last name ) for all employees who earn more than the average salary.
SELECT emplyee_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'full name'
FROM employees
WHERE salary > (
		SELECT DISTINCT AVG(salary)
		FROM employees
		);

/*Task 13*/
--Write a query to display the employee name ( first name and last name ), employee id and salary of all employees who report to Payam.
SELECT CONCAT (
		first_name
		,' '
		,last_name
		) AS 'full name'
	,emplyee_id
	,salary
	,manager_id
FROM employees
WHERE manager_id = (
		SELECT emplyee_id
		FROM employees
		WHERE first_name = 'Payam'
		);

/*Task 14*/
-- Write a query to display the department number, name ( first name and last name ), job and department name for all employees in the Finance department.
SELECT department_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'full name'
	,job_id
FROM employees
WHERE department_id = (
		SELECT department_id
		FROM departments
		WHERE department_name = 'Finance'
		);

/*Task 15*/
--Write a query to display all the information of an employee whose salary and reporting person id is 3000 and 121 respectively.
SELECT department_id
	,CONCAT (
		first_name
		,' '
		,last_name
		) AS 'full name'
	,job_id
FROM employees
WHERE salary = 3000
	AND manager_id = 121;

/*Task 16*/
-- Display all the information of an employee whose id is any of the number 134, 159 and 183.
SELECT *
FROM employees
WHERE emplyee_id IN (
		134
		,159
		,183
		);

/*Task 17*/
--Write a query to display all the information of the employees whose salary is within the range 1000 and 3000.
SELECT *
FROM employees
WHERE salary BETWEEN 1000
		AND 3000;

/*Task 18*/
--Write a query to display all the information of the employees whose salary is within the range of smallest salary and 2500.
SELECT *
FROM employees
WHERE salary BETWEEN (
				SELECT DISTINCT MIN(salary)
				FROM employees
				)
		AND 2500;

/*Task 19*/
--Write a query to display all the information of the employees who does not work in those departments where some employees works whose manager id within the range 100 and 200.
SELECT *
FROM employees
WHERE manager_id NOT IN (
		SELECT manager_id
		FROM employees
		WHERE manager_id BETWEEN 100
				AND 200
		);

/*Task 20*/
--Write a query to display all the information for those employees whose id is any id who earn the second highest salary.
SELECT *
FROM employees
WHERE salary = (
		SELECT DISTINCT MAX(salary)
		FROM employees
		WHERE salary <> (
				SELECT DISTINCT MAX(salary)
				FROM employees
				)
		);
