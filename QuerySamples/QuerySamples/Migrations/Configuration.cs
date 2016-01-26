namespace QuerySamples.Migrations
{
    using Cubido.Data.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Cubido.Data.Entities.BloggingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Cubido.Data.Entities.BloggingContext";
        }

        protected override void Seed(Cubido.Data.Entities.BloggingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method
            //to avoid creating duplicate seed data.E.g.

              context.Blogs.AddOrUpdate(
                p => p.BlogId,
                new Blog {BlogId = 1, Name = "Blog 1", Url = "sample" },
                new Blog { BlogId = 2, Name = "Blog 2", Url = "sample" }
              );

            context.Posts.AddOrUpdate(
                p => p.PostId,
                new Post { PostId = 1, BlogId = 1, Content= "sample1", Title ="title 1" },
                new Post { PostId = 2, BlogId = 1, Content = "sample2", Title = "title 2" },
                new Post { PostId = 3, BlogId = 2, Content = "sample2", Title = "title 2" }
              );

            context.Comments.AddOrUpdate(
                c => c.CommentId,
                new Comment { CommentId = 1, PostId = 1, Message = "comment 1", Author = "author1"},
                new Comment { CommentId = 2, PostId = 1, Message = "comment 2", Author ="author2"},
                new Comment { CommentId = 3, PostId = 2, Message = "comment 2.1", Author = "author2" }
              );


        }
    }
}
