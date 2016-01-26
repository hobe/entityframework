using Inheritance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_TPT
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SampleDbContext())
            {
                ctx.Database.Log = Console.WriteLine;
                var allPeople = ctx.People.ToList();
                var teacher = ctx.People.OfType<Teacher>().ToList();
                Console.WriteLine(allPeople.Count);
                Console.WriteLine(teacher.Count);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
