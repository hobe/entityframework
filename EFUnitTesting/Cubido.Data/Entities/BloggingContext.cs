namespace Cubido.Data.Entities
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BloggingContext : DbContext, IBloggingContext
    {
        public BloggingContext()
            : base("name=BloggingContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.Database.Log = Console.WriteLine;
        }
    }

}