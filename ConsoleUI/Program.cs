using DALStudent;
using DALStudent.Model;
using System;

namespace ConsoleUI
{
    class Program
    {
        private static UnitOfWork unit;

        static void Main(string[] args)
        {
            DisplayGeneralMenu();
        }

        static void DisplayGeneralMenu()
        {
            bool IsValid = false;
            while (IsValid != true)
            {
                Console.WriteLine(new String('-', 30));
                Console.WriteLine("1. View entity");
                Console.WriteLine("2. Add entity");
                Console.WriteLine("3. Delete entity");
                Console.WriteLine("4. Update entity");

                Console.WriteLine("Enter number of action:");
                var action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        DisplaySubViewMenu();
                        break;
                    case "2":
                        DisplaySubAddMenu();
                        break;
                    case "3":
                        DisplaySubDeleteMenu();
                        break;
                    case "4":
                        DisplaySubUpdateMenu();
                        break;
                    default:
                        break;
                }
            }
        }

        static void DisplaySubAddMenu()
        {
            bool IsActive = true;
            while (IsActive)
            {
                Console.WriteLine(new String('-', 30));
                Console.WriteLine("1. Add students");
                Console.WriteLine("2. Add cources");
                Console.WriteLine("3. Add departments");
                Console.WriteLine("0. Go back");

                Console.WriteLine("Enter number of action:");
                var action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        AddCourse();
                        break;
                    case "3":
                        AddDepartment();
                        break;
                    case "0":
                        IsActive = false;
                        break;
                    default:
                        Console.WriteLine("Wrong choise. Try again.");
                        break;
                }
            }
        }

        static void DisplaySubUpdateMenu()
        {
            bool IsActive = true;
            while (IsActive)
            {
                Console.WriteLine(new String('-', 30));
                Console.WriteLine("1. Update students");
                Console.WriteLine("2. Update cources");
                Console.WriteLine("3. Update departments");
                Console.WriteLine("0. Go back");

                Console.WriteLine("Enter number of action:");
                var action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        UpdateStudent();
                        break;
                    case "2":
                        UpdateCourse();
                        break;
                    case "3":
                        UpdateDepartment();
                        break;
                    case "0":
                        IsActive = false;
                        break;
                    default:
                        Console.WriteLine("Wrong choise. Try again.");
                        break;
                }
            }
        }

        static void DisplaySubDeleteMenu()
        {
            bool IsActive = true;
            while (IsActive)
            {
                Console.WriteLine(new String('-', 30));
                Console.WriteLine("1. Delete student");
                Console.WriteLine("2. Delete course");
                Console.WriteLine("3. Delete department");
                Console.WriteLine("0. Go back");

                Console.WriteLine("Enter number of action:");
                var action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        DeleteStudent();
                        break;
                    case "2":
                        DeleteCourse();
                        break;
                    case "3":
                        DeleteDepartment();
                        break;
                    case "0":
                        IsActive = false;
                        break;
                    default:
                        Console.WriteLine("Wrong choise. Try again.");
                        break;
                }
            }
        }

        static void DisplaySubViewMenu()
        {
            bool IsActive = true;
            while (IsActive)
            {
                Console.WriteLine(new String('-', 30));
                Console.WriteLine("1. View students");
                Console.WriteLine("2. View cources");
                Console.WriteLine("3. View departments");
                Console.WriteLine("0. Go back");

                Console.WriteLine("Enter number of action:");
                var action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        ViewStudents();
                        break;
                    case "2":
                        ViewCources();
                        break;
                    case "3":
                        ViewDepartment();
                        break;
                    case "0":
                        IsActive = false;
                        break;
                    default:
                        Console.WriteLine("Wrong choise. Try again.");
                        break;
                }
            }
        }

        static void ViewStudents()
        {
            unit = new UnitOfWork();

            var students = unit.StudentRepository.Get();

            foreach (var item in students)
            {
                Console.WriteLine(item);
            }
        }

        static void ViewCources()
        {
            unit = new UnitOfWork();

            var courses = unit.CourseRepository.Get();

            foreach (var item in courses)
            {
                Console.WriteLine(item);
            }
        }

        static void ViewDepartment()
        {
            unit = new UnitOfWork();

            var departments = unit.DepartmentRepository.Get();

            foreach (var item in departments)
            {
                Console.WriteLine(item);
            }
        }

        static void AddStudent()
        {
            unit = new UnitOfWork();

            Student student = new Student();
            Console.WriteLine("Enter student's name:");
            student.FirstName = Console.ReadLine();
            Console.WriteLine("Enter student's surname:");
            student.LastName = Console.ReadLine();

            unit.StudentRepository.Insert(student);
            unit.Save();
        }

        static void AddCourse()
        {
            unit = new UnitOfWork();

            Course course = new Course();
            Console.WriteLine("Enter course:");
            course.Name = Console.ReadLine();

            unit.CourseRepository.Insert(course);
            unit.Save();
        }

        static void AddDepartment()
        {
            unit = new UnitOfWork();

            Department department = new Department();
            Console.WriteLine("Enter course:");
            department.Name = Console.ReadLine();

            unit.DepartmentRepository.Insert(department);
            unit.Save();
        }

        static void UpdateStudent()
        {
            unit = new UnitOfWork();
            Student student = ChooseStudent();

            Console.WriteLine("Enter new student name:");
            student.FirstName = Console.ReadLine();
            Console.WriteLine("Enter new student surname:");
            student.LastName = Console.ReadLine();

            unit.StudentRepository.Update(student);
            unit.Save();
        }

        static void UpdateCourse()
        {
            unit = new UnitOfWork();
            Course сourse = ChooseCourse();

            Console.WriteLine("Enter course name:");
            сourse.Name = Console.ReadLine();

            unit.CourseRepository.Update(сourse);
            unit.Save();
        }

        static void UpdateDepartment()
        {
            unit = new UnitOfWork();
            Department department = ChooseDepartment();

            Console.WriteLine("Enter department name:");
            department.Name = Console.ReadLine();

            unit.DepartmentRepository.Update(department);
            unit.Save();
        }

        static void DeleteStudent()
        {
            unit = new UnitOfWork();
            Student student = ChooseStudent();

            unit.StudentRepository.Delete(student);
            unit.Save();
        }

        static void DeleteCourse()
        {
            unit = new UnitOfWork();
            Course сourse = ChooseCourse();

            unit.CourseRepository.Delete(сourse);
            unit.Save();
        }

        static void DeleteDepartment()
        {
            unit = new UnitOfWork();
            Department department = ChooseDepartment();

            unit.DepartmentRepository.Delete(department);
            unit.Save();
        }

        static Student ChooseStudent()
        {
            bool IsValid = false;
            unit = new UnitOfWork();
            Student student = new Student();
            ViewStudents();

            while (IsValid == false)
            {
                Console.WriteLine("Enter id of student:");
                var studentId = Int32.Parse(Console.ReadLine());

                student = unit.StudentRepository.GetByID(studentId);
                if (student != null)
                {
                    IsValid = true;
                    return student;
                }
                else
                    Console.WriteLine("Wrong student id.");
            }
            return student;
        }

        static Course ChooseCourse()
        {
            bool IsValid = false;
            unit = new UnitOfWork();
            Course course = new Course();
            ViewCources();

            while (IsValid == false)
            {
                Console.WriteLine("Enter id of course:");
                var courseId = Int32.Parse(Console.ReadLine());

                course = unit.CourseRepository.GetByID(courseId);
                if (course != null)
                {
                    IsValid = true;
                    return course;
                }
                else
                    Console.WriteLine("Wrong course id.");
            }
            return course;
        }

        static Department ChooseDepartment()
        {
            bool IsValid = false;
            unit = new UnitOfWork();
            Department department = new Department();
            ViewDepartment();

            while (IsValid == false)
            {
                Console.WriteLine("Enter id of department:");
                var departmentId = Int32.Parse(Console.ReadLine());

                department = unit.DepartmentRepository.GetByID(departmentId);
                if (department != null)
                {
                    IsValid = true;
                    return department;
                }
                else
                    Console.WriteLine("Wrong department id.");
            }
            return department;
        }
    }
}