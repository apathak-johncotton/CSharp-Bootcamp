namespace Linq_Intro_with_a_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new() { Name = "Aarav", Class = 10, Marks = 78 },
                new() { Name = "Vihaan", Class = 10, Marks = 92 },
                new() { Name = "Ishaan", Class = 9,  Marks = 65 },
                new() { Name = "Kabir",  Class = 10, Marks = 55 },
                new() { Name = "Reyansh",Class = 9,  Marks = 81 }
            };

            var topper = students.OrderByDescending(s => s.Marks).FirstOrDefault();
            var class10 = students.Where(x => x.Class == 10).OrderBy(s => s.Name).ToList();
            var avg = students.Average(s => s.Marks);
            var highScorers = students.Where(s => s.Marks >= 80).Select(s => s.Name).ToList();
        }
    }
}
