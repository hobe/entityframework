using CascadeDelete.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CascadeDelete
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                using (var ctx = new SampleDbContext())
                {
                    var blogs = ctx.Blogs.Include(i => i.Posts).ToList();
                    
                    foreach (var blog in blogs)
                    {
                        Console.WriteLine(blog.Id+ ": "+ blog.Title);
                    }


                        var option = PrintOptions();
                    switch (option)
                    {
                        case Options.CascadeDelete:
                            Console.WriteLine("Enter ID ");
                            var key = Console.ReadKey();
                            int id = int.Parse(key.KeyChar.ToString());

                            var blog = ctx.Blogs.Find(id);
                            if (blog != null)
                            {
                                //ctx.Database.ExecuteSqlCommand("DELETE FROM Blog WHERE Id = @p0", id);
                                ctx.Blogs.Remove(blog);

                                ctx.SaveChanges();
                                Console.WriteLine("removed successfully!");
                            }
                            else
                            {
                                Console.WriteLine("ID does not exist");
                            }
                            break;
                        case Options.Exit:
                            return;
                    }
                }
            }
            while (true);
        }

        private static Options PrintOptions()
        {
            Console.WriteLine("Chose an option below:");
            Console.WriteLine("[1]: Delete All (Cascade Delete)");
            Console.WriteLine("[2]: Exit");
            var key = Console.ReadKey();
            Console.WriteLine();
            switch (key.KeyChar)
            {
                case '1':
                    return Options.CascadeDelete;
                case '2':
                    return Options.Exit;
                default: return Options.Unknown; 
            }

        }
    }

    public enum Options
    {
        CascadeDelete,
        Exit,
        Unknown
    }
}
