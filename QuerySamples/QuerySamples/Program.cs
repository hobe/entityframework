using Cubido.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace QuerySamples
{
    class Program
    {
        static void Main(string[] args)
        {

            var ctx = new BloggingContext();

            // Simple query:
            var blogs = ctx.Blogs.ToList();


            // LINQ Query Syntax:
            var res = (from p in ctx.Posts.Include("Blog")
                       where p.BlogId == 1
                       select p).FirstOrDefault<Post>();

            // Filtering:
            blogs = ctx.Blogs.OrderBy(i => i.Name).ThenByDescending(i => i.BlogId).ToList();
            var blog = ctx.Blogs.FirstOrDefault(i => i.BlogId > 12);

            // this does not work:
            //blogs = ctx.Blogs.Where(i => i.Name.Split(',').Count() > 4).ToList();

            // SQL query:

            blogs = ctx.Blogs.SqlQuery("SELECT * From Blogs WHERE BlogId > 0").ToList();

            int value = 12;
            blogs = ctx.Database.SqlQuery<Blog>("SELECT * From Blogs WHERE BlogId > {0}", value).ToList();


            // Projection (Multi Level)
            var allData = ctx.Blogs.Include(i => i.Posts.Select(p => p.Comments)).ToList();

            // Select gets a list of lists of phone numbers
            //IEnumerable<IEnumerable<PhoneNumber>> phoneLists = people.Select(p => p.PhoneNumbers);

            // SelectMany flattens it to just a list of comments
            List<List<Comment>> comments = ctx.Posts.Select(p => p.Comments).ToList();
            List<Comment> comments2 = ctx.Posts.SelectMany(p => p.Comments).ToList();


            // GroupBy:
            var groups = ctx.Posts.GroupBy(i => i.BlogId).ToList();


            // Anonymous Class results:
            var result = ctx.Posts.Select(i => new
                {
                    Prop1 = i.Content,
                    Prop2 = i.PostId + " " + i.Title,
                    Prop3 = i.Content
                }).ToList();
            Console.WriteLine(result.FirstOrDefault());



            // Enable/Disable LazyLoading:
            blog = null;

            using (var ctx2 = new BloggingContext())
            {
                blog = ctx2.Blogs.First(i => i.BlogId == 1);
                ctx2.Database.Log = Console.WriteLine;

                foreach (var post in blog.Posts)
                    Console.WriteLine(post.Content);
            }

            // this would not work with disabled lazy loading:
            //using (var ctx2 = new BloggingContext())
            //{
            //    blog = ctx2.Blogs.First(i => i.BlogId == 1);
            //    ctx2.Database.Log = Console.WriteLine;
            //}
            //foreach (var post in blog.Posts)
            //    Console.WriteLine(post.Content);




            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();





        }
    }
}
