using System.Linq.Expressions;

namespace Records
{
    public record Student(string Name, int Class, int Marks);

    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student("Ankit", 9, 80),
                 new Student("Ankita", 10, 70),
                  new Student("Vinod", 10, 50),
                   new Student("Karan", 10, 60),
            };

            var grouped = students.GroupBy(s => s.Class).Select(g => new {Class = g.Key, Avg = g.Average(x => x.Marks) });

            foreach (var record in grouped)
            {
                Console.WriteLine($"{record.Avg} ");
            }

            var toppers = students
                .GroupBy(s => s.Class)
                .Select(g => g
                    .OrderByDescending(s => s.Marks)
                    .First()
                );

            foreach (var topper in toppers)
            {
                Console.WriteLine($"{topper.Class} - {topper.Name} ({topper.Marks})");
            }
        }
    }
}
