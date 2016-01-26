using Cubido.Data;
using Cubido.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var svc = new BlogService(new BloggingContext());

            svc.AddBlog("Blog 1", "http://www.myblog.de");

            Console.WriteLine("Listing all blogs: ");
            foreach (var b in svc.GetAllBlogs())
            {
                Console.WriteLine(b.Name);
            }

            Console.ReadKey();
        }
    }
}
