using System;
using System.Collections.Generic;
using System.Linq;

namespace Matala
{
    class Course
    {
        public Student st { get; set; }
        public string nameCourse { get; set; }
        public override string ToString()
        {

            return $"{nameCourse,-10}   {st}";
        }
        public string ShowGrade(int index)
        {
            Console.WriteLine($"\ncourses[1].ShowGrade({index})");
            try { return $"{(st.getListGrade())[index]}"; }
            catch (Exception e) { return ""; }
        }
        public static void printAll(List<Course> list)
        {
            Console.WriteLine("List of courses:\n");
            list.ForEach(x => { Console.WriteLine(x); });
            Console.WriteLine();
        }
        internal class Student
        {
            public string nameOfStudent { get; set; }
            public List<int> gradeList { get; set; }

            public List<int> getListGrade() { return gradeList; }
            public float average()
            {
                if (gradeList.Count == 0)
                    return 0;
                else
                    return (float)(gradeList.Sum(item => item) / gradeList.Count);
            }
            public override string ToString()
            {

                return $"{nameOfStudent,-14}  {string.Join(" ", gradeList)}";
            }
            
        }
    }
}
