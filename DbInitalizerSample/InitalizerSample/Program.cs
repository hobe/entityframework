using Inheritance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitalizerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new SampleDbContext();
            var people = ctx.People.ToList();
            Console.WriteLine("exit");

        }
    }
}
