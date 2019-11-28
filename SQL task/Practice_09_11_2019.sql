/* Task 21 */
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

/* Task 23*/
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

/*Task24  */
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

/* Task 25*/
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

/* Task 26*/
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

/* Task 27*/
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
	AND job_id <> 'PU_MAN'

/* Task 28*/
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
SELECT department_id
	,SUM(salary)
FROM employees
GROUP BY department_id
HAVING COUNT(department_id) > 0;

/* Task 31 */
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

/*Task 32 */
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

/* Task 34*/
SELECT department_name
FROM departments
WHERE department_id IN (
		SELECT department_id
		FROM employees
		GROUP BY department_id
		HAVING COUNT(department_id) > 0
		);

/* Task 35*/
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

/* Task 40  */
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
SELECT department_id
	,department_name
FROM departments
WHERE location_id = (
		SELECT location_id
		FROM locations
		WHERE city = 'London'
		);

/* task 43 */
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
