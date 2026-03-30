using System;
using System.Collections.Generic;
using System.Linq;

namespace Matala
{
    class Program
    {
        private delegate bool Delegate<in T>(T obj);
        static void Main(string[] args)
        {
            Delegate<Course> actionDelegate;
            List<Course> Courses = new List<Course>()
            {
            new Course
                {
                    nameCourse = "C#",
                    st = new Course.Student
                    {
                        nameOfStudent = "Jojo",
                        gradeList = new List<int> { 10, 20, 100 }
                    }
                },
            new Course
                {
                    nameCourse = "C",
                    st = new Course.Student
                    {
                        nameOfStudent = "Bambi",
                        gradeList = new List<int> { 99 }
                    }
                },
            new Course
                {
                    nameCourse = "Java",
                    st = new Course.Student
                    {
                        nameOfStudent = "Bambi",
                        gradeList = new List<int> {  }
                    }
                },
            new Course
            {
                    nameCourse = "C#",
                    st = new Course.Student
                    {
                        nameOfStudent = "Jojo",
                        gradeList = new List<int> { 10, 20, 30, 40 }
                    }
                },
            new Course
                {
                    nameCourse = "Java",
                    st = new Course.Student
                    {
                        nameOfStudent = "Lady Gaga",
                        gradeList = new List<int> {100, 99, 1, 100, 100}
                    }
                },
            new Course
                {
                    nameCourse = "Java",
                    st = new Course.Student
                    {
                        nameOfStudent = "Tami",
                        gradeList = new List<int> { 60, 70, 80, 1 }
                    }
                },
            new Course
                {
                    nameCourse = "SQL",
                    st = new Course.Student
                    {
                        nameOfStudent = "Lady Gaga",
                        gradeList = new List<int> { 50 }
                    }
                }
            };

            Course.printAll(Courses);
            Console.WriteLine("Press P / p : Those who passed in average and those did not:");
            Console.WriteLine("Press # : C# courses, and other courses:");
            Console.WriteLine("Any other key: Courses with student who have at least one grade of 100, and all the other courses:");

            string chooise = Console.ReadLine();

            switch (chooise)
            {
                case "p":
                case "P":
                    actionDelegate = courseList => courseList.st.average() >= 60;
                    break;
                case "#":
                    actionDelegate = courseList => courseList.nameCourse.Equals("C#");
                    break;
                default:
                    actionDelegate = courseList => courseList.st.gradeList.Contains(100);
                    break;
            }

            var res = Q1(Courses, actionDelegate).ToList();
            var resIn = Courses.Except(res).ToList();
            Console.WriteLine();
            ToStringQ1(res, resIn);
            var result = Q2(Courses).ToList();

            Console.WriteLine(Courses[1].ShowGrade(0));
            Console.WriteLine(Courses[2].ShowGrade(3));

            ToStringQ2(result);
            Console.WriteLine("\nPress enter for clear and try again");
            Console.ReadLine();
            Console.Clear();
            Main(new string[] { });
        }
        private static IEnumerable<T> Q1<T>(IEnumerable<T> coursesList, Delegate<T> actionDelegate)
        {
            return from item in coursesList where actionDelegate(item) select item;
        }
        private static IEnumerable<Course.Student> Q2(List<Course> courses)
        {
            return from item in courses
                   let gradesGreater = item.st.gradeList.FindAll(grade => grade >= 60)
                   where gradesGreater.Count > 0 && gradesGreater.Average() >= 90
                   select item.st;
        }
        private static void ToStringQ1(IEnumerable<Course> res, IEnumerable<Course> resIn)
        {
            Console.WriteLine("Q1 Results:");
            Console.WriteLine("\n--------False---------");
            ToString(resIn);
            Console.WriteLine("\n--------True---------");
            ToString(res);

        }
        private static void ToStringQ2(List<Course.Student> q2)
        {
            q2.ForEach(student =>
            {
                Console.WriteLine($"{{ Name = {student.nameOfStudent}, Grades = {string.Join(" ", student.gradeList)} }}");
            });
        }
        private static void ToString<T>(IEnumerable<T> a)
        {
            Console.WriteLine(string.Join("\n", a));
        }
    }

}
