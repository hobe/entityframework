namespace Cubido.Data.Entities
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BloggingContext : DbContext
    {
        public BloggingContext()
            : base("name=BloggingContext")
        {
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Post>()
            //    .HasRequired(p => p.Blog)
            //    .WithMany(b => b.Posts)
            //    .HasForeignKey(p => p.BlogId);

            base.OnModelCreating(modelBuilder);
            this.Database.Log = Console.WriteLine;
        }
    }

}