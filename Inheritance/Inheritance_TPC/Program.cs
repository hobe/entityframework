using Inheritance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SampleDbContext())
            {
                var teachers = ctx.People.OfType<Teacher>().ToList();
                Console.WriteLine(teachers.Count);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}
