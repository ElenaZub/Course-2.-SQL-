/* Task 57 */
--Write a query in SQL to display the first name, last name, department number, and department name for each employee.
SELECT employees.first_name
	,employees.last_name
	,departments.department_name
FROM employees
INNER JOIN departments ON employees.department_id = departments.department_id;

/* Task 58*/
--Write a query in SQL to display the first and last name, department, city, and state province for each employee.
SELECT employees.first_name
	,employees.last_name
	,departments.department_name
	,locations.city
	,locations.state_province
FROM employees
INNER JOIN departments ON employees.department_id = departments.department_id
INNER JOIN locations ON departments.location_id = locations.location_id;

/* Task 59 */
--Write a query in SQL to display the first name, last name, salary, and job grade for all employees.
SELECT first_name
	,last_name
	,salary
	,grade_level
FROM employees
INNER JOIN job_grades ON employees.salary BETWEEN job_grades.lowest_sal
		AND job_grades.highest_sal;

/* Task 60 */
--Write a query in SQL to display the first name, last name, department number and department name,
--for all employees for departments 80 or 40.
SELECT employees.first_name
	,employees.last_name
	,employees.department_id
	,departments.department_name
FROM employees
INNER JOIN departments ON employees.department_id = departments.department_id
WHERE departments.department_id = 80
	OR departments.department_id = 40;

/* Task 61 */
--Write a query in SQL to display those employees who contain a letter z to their first name and 
--also display their last name, department, city, and state province.
SELECT employees.first_name
	,employees.last_name
	,departments.department_name
	,locations.city
	,locations.state_province
FROM employees
INNER JOIN departments ON employees.department_id = departments.department_id
INNER JOIN locations ON departments.location_id = locations.location_id
WHERE employees.first_name LIKE ('%z%');

/* Task 62*/
--Write a query in SQL to display all departments including those where does not have any employee.
SELECT employees.first_name
	,employees.last_name
	,employees.department_id
	,departments.department_name
FROM departments
LEFT JOIN employees ON departments.department_id = employees.department_id
	OR employees.department_id IS NULL;

/* Task 63 */
--Write a query in SQL to display the first and last name and salary for those employees who earn 
--less than the employee earn whose number is 182.
SELECT em1.first_name
	,em1.last_name
	,em1.salary
FROM employees AS em1
INNER JOIN employees AS em2 ON em1.salary < em2.salary
	AND em2.emplyee_id = 182;

/* Task 64 */
--Write a query in SQL to display the first name of all employees including the first name of their manager.
SELECT em1.first_name
	,em2.first_name
FROM employees AS em1
INNER JOIN employees AS em2 ON em1.manager_id = em2.emplyee_id;

/* Task 65 */
--Write a query in SQL to display the department name, city, and state province for each department.
SELECT departments.department_name
	,locations.city
	,locations.state_province
FROM departments
INNER JOIN locations ON departments.location_id = locations.location_id;

/* Task 66 */
--Write a query in SQL to display the first name, last name, department number and name, 
--for all employees who have or have not any department
SELECT employees.first_name
	,employees.last_name
	,departments.department_id
	,departments.department_name
FROM employees
LEFT JOIN departments ON employees.department_id = departments.department_id
	OR employees.department_id IS NULL;

/* Task 67 */
--Write a query in SQL to display the first name of all employees and the first name of their 
--manager including those who does not working under any manager.
SELECT em1.first_name AS 'Employee Name'
	,em2.first_name
FROM employees AS em1
LEFT JOIN employees AS em2 ON em1.manager_id = em2.emplyee_id
	OR em1.manager_id IS NULL;

/* Task 68 */
--Write a query in SQL to display the first name, last name, and department number for those employees who works
--in the same department as the employee who holds the last name as Taylor.
SELECT em1.first_name
	,em1.last_name
	,em1.department_id
FROM employees AS em1
INNER JOIN employees AS em2 ON em1.department_id = em2.department_id
WHERE em2.last_name = 'Taylor';

/* Task 69 */
--Write a query in SQL to display the job title, department name, full name (first and last name ) of employee, 
--and starting date for all the jobs which started on or after 1st January, 1993 and ending with on or before 
--31 August, 1997.
SELECT jobs.job_title
	,departments.department_name
	,CONCAT (
		employees.first_name
		,' '
		,employees.last_name
		) AS 'Employees_name'
	,job_history.start_date
FROM employees
INNER JOIN job_history ON job_history.employee_id = employees.emplyee_id
INNER JOIN jobs ON jobs.job_id = employees.job_id
INNER JOIN departments ON departments.department_id = employees.department_id
WHERE job_history.start_date >= '1993-01-01'
	AND job_history.start_date <= '1997-08-31';

/* Task 70 */
--Write a query in SQL to display job title, full name (first and last name ) of employee, and the difference 
--between maximum salary for the job and salary of the employee.
SELECT jobs.job_title
	,CONCAT (
		employees.first_name
		,' '
		,employees.last_name
		) AS Full_name
	,jobs.max_salary - employees.salary
FROM jobs
INNER JOIN employees ON employees.job_id = jobs.job_id;
