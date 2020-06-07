using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqApp
{
    class Program
    {
        public class Student
        {
            #region data
            public enum GradeLevel { FirstYear = 1, SecondYear, ThirdYear, FourthYear };

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Id { get; set; }
            public GradeLevel Year;
            public List<int> ExamScores;

            protected static List<Student> students = new List<Student>
            {
                new Student {FirstName = "Terry", LastName = "Adams", Id = 120,
                    Year = GradeLevel.SecondYear,
                    ExamScores = new List<int> { 99, 82, 81, 79}},
                new Student {FirstName = "Fadi", LastName = "Fakhouri", Id = 116,
                    Year = GradeLevel.ThirdYear,
                    ExamScores = new List<int> { 99, 86, 90, 94}},
                new Student {FirstName = "Hanying", LastName = "Feng", Id = 117,
                    Year = GradeLevel.FirstYear,
                    ExamScores = new List<int> { 93, 92, 80, 87}},
                new Student {FirstName = "Cesar", LastName = "Garcia", Id = 114,
                    Year = GradeLevel.FourthYear,
                    ExamScores = new List<int> { 97, 89, 85, 82}},
                new Student {FirstName = "Debra", LastName = "Garcia", Id = 115,
                    Year = GradeLevel.ThirdYear,
                    ExamScores = new List<int> { 35, 72, 91, 70}},
                new Student {FirstName = "Hugo", LastName = "Garcia", Id = 118,
                    Year = GradeLevel.SecondYear,
                    ExamScores = new List<int> { 92, 90, 83, 78}},
                new Student {FirstName = "Sven", LastName = "Mortensen", Id = 113,
                    Year = GradeLevel.FirstYear,
                    ExamScores = new List<int> { 88, 94, 65, 91}},
                new Student {FirstName = "Claire", LastName = "O'Donnell", Id = 112,
                    Year = GradeLevel.FourthYear,
                    ExamScores = new List<int> { 75, 84, 91, 39}},
                new Student {FirstName = "Svetlana", LastName = "Omelchenko", Id = 111,
                    Year = GradeLevel.SecondYear,
                    ExamScores = new List<int> { 97, 92, 81, 60}},
                new Student {FirstName = "Lance", LastName = "Tucker", Id = 119,
                    Year = GradeLevel.ThirdYear,
                    ExamScores = new List<int> { 68, 79, 88, 92}},
                new Student {FirstName = "Michael", LastName = "Tucker", Id = 122,
                    Year = GradeLevel.FirstYear,
                    ExamScores = new List<int> { 94, 92, 91, 91}},
                new Student {FirstName = "Eugene", LastName = "Zabokritski", Id = 121,
                    Year = GradeLevel.FourthYear,
                    ExamScores = new List<int> { 96, 85, 91, 60}}
            };
            #endregion

            // Helper method, used in GroupByRange.
            protected static int GetPercentile(Student s)
            {
                double avg = s.ExamScores.Average();
                return avg > 0 ? (int)avg / 10 : 0;
            }

            public static void QueryHighScores(int exam, int score)
            {
                var highScores = from student in students
                                 where student.ExamScores[exam] > score
                                 select new { Name = student.FirstName, Score = student.ExamScores[exam] };

                foreach (var item in highScores)
                {
                    Console.WriteLine($"{item.Name,-15}{item.Score}");
                }
            }
            public static IEnumerable<Student> QueryHighScoresTest(int exam, int score)
            {
                return from student in students
                       where student.ExamScores[exam] > score
                       select student;
            }
        }
        public class City
        {
            #region fields
            public int population;
            public string name;
            #endregion fields

            #region constructors
            City(){ }

            public City(string name, int population)
            {
                this.name = name;
                this.population = population;
            }
            #endregion constructors
        }
        static void Main(string[] args)
        {
            // - - - - - - -
            // Specify the data source.
            //int[] scores = new int[] { 97, 92, 81, 60, 64, 38, 86 };
            List<int> scores = new List<int>() { 97, 92, 81, 60, 64, 38, 86 };

            List<City> Cities = new List<City>();
            Cities.Add(new City("Oulu", 195000));
            Cities.Add(new City("Turku", 191603));
            Cities.Add(new City("Helsinki", 500000));
            Cities.Add(new City("Tampere", 230000));

            // Define the query expression.
            //var scoreQuery =
            /*
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                orderby score
                select score;
            */

            // Execute the query.
            /*
            foreach (int i in scoreQuery)
            {
                Console.Write(i + " ");
            }
            */

            // Returned IENumerable can be string or any other object.
            /*
            IEnumerable<string> scoreQuery =
                from score in scores
                where score > 80
                orderby score
                select $"Answer is: {score}";

            // Execute the query.
            foreach (string i in scoreQuery)
            {
                Console.Write(i + " ");
            }
            */

            // Different syntaxes are supported.
            /*
            var scoreQuery =
                (from score in scores
                where score > 80
                orderby score
                select score)
                .Count();
            */

            //Console.WriteLine(scoreQuery);

            // You can also go through classes.
            IEnumerable<City> queryMajorCities =
                from city in Cities
                where city.population > 200000
                select city;

            IEnumerable<City> queryMajorCities2 = Cities.Where(c => c.population > 200000);

            foreach (City i in queryMajorCities)
            {
                Console.Write(i.name + " ");
            }

            Console.WriteLine("\n\nPress <Enter>");
            Console.ReadLine();
            // - - - - - - -

            Student.QueryHighScores(1, 90);
            Console.WriteLine("\n\n");

            List<Student> mystudent = Student.QueryHighScoresTest(1, 70).ToList();
            foreach (Student iter in mystudent)
            {
                //Console.WriteLine(iter.LastName);
                Console.WriteLine(iter.LastName);
            }

            Student.QueryHighScores(1, 90);
            
            Console.WriteLine("\n\nPress <Enter>");
            Console.ReadLine();
        }
    }
}
