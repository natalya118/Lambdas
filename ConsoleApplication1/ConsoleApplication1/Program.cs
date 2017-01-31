using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{

    public class Student
    {
        public Student(string lastname, Dictionary<string, int> disciplines)
        {
            this.LastName = lastname;
            this.Disciplines = disciplines;
        }
        public string LastName { get; set; }
        public Dictionary<string, int> Disciplines;


        public double GetRaiting()
        {
            double res = 0;
            int count = 0;
            foreach(KeyValuePair<string,int> d in Disciplines)
            {
                count++;
                res += d.Value;
            }
            return res / count;
        }
        override
        public string ToString()
        {
            string res = "Student: " + LastName + "\nDisciplines: \n";
            string disc = "";
            foreach (KeyValuePair<string, int> d in Disciplines)
            {
                disc = d.Key + ": " + d.Value + "\n";
                res += disc;
            }
            disc = "Rating = " + this.GetRaiting() +"\n";
            res += disc;
            return res;
        }

    }
    class Program
    {
        //The .NET framework is casting the lambda (st1,st2)=>int as a Comparer<Student>
        public static void Sort(List<Student> students)
        {
            students.Sort((st1, st2) => st1.GetRaiting().CompareTo(st2.GetRaiting()));
        }
        public static void Print(List<Student> students)
        {
            foreach (Student s in students)
            {
                Console.WriteLine(s.ToString());
            }
        }
        static void Main(string[] args)
        {
            List<Student> st = new List<Student>();
            Dictionary<string, int> disciplines = new Dictionary<string, int>();
            disciplines.Add(".NET", 100);
            disciplines.Add("C++", 91);
            disciplines.Add("Databases", 95);
            st.Add( new Student("Dranchuk", disciplines));
            
            Dictionary<string, int> disciplines2 = new Dictionary<string, int>();
            disciplines2.Add(".NET", 81);
            disciplines2.Add("Math", 78);
            st.Add(new Student("Ivanov", disciplines2));

            Dictionary<string, int> disciplines3 = new Dictionary<string, int>();
            disciplines3.Add(".NET", 81);
            disciplines3.Add("English", 92);
            st.Add(new Student("Petrov", disciplines3));
            Console.WriteLine("--------------------Before sorting-----------------");
            Print(st);
            Sort(st);
            Console.WriteLine("--------------------After sorting-----------------");
            Print(st);
            Console.ReadKey();
        }
    }
}
