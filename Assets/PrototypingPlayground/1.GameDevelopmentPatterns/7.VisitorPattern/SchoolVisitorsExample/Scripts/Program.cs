using System;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._7.VisitorPattern.SchoolVisitorsExample
{
    public class Program
    {
        private static void Main(string[] _args)
        {
            School school = new School();
            Doctor visitor1 = new Doctor("James");
            school.PerformOperation(visitor1);
            Console.WriteLine();
            Salesman visitor2 = new Salesman("John");
            school.PerformOperation(visitor2);
            Console.Read();
        }
    }
}
