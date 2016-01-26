namespace CascadeDelete.Migrations
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Model.SampleDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Model.SampleDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            var blog1 = new Blog { Title = "Blog1", BloggerName = "BernhardH" };
            var blog2 = new Blog { Title = "Blog2", BloggerName = "BernhardH" };
            context.Blogs.AddOrUpdate(
                i => i.Id,
                blog1, blog2
                );

            context.Posts.AddOrUpdate(
              p => p.Id,
                new Post { Content ="Sample Content1", DateCreated = DateTime.Now, Title = "Sample Post1", Blog = blog1 },
                new Post { Content = "Sample Content2", DateCreated = DateTime.Now, Title = "Sample Post2", Blog = blog1 },
                new Post { Content = "Sample Content3", DateCreated = DateTime.Now, Title = "Sample Post3", Blog = blog1 },
                new Post { Content = "Sample Content3", DateCreated = DateTime.Now, Title = "Sample Post3", Blog = blog2 }
            );

        }
    }
}
