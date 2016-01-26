namespace CascadeDelete.Model
{
    using CascadeDelete.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// Sample for showing how to use Table-Per-Hierarchy (TPH)
    /// </summary>
    public class SampleDbContext : DbContext
    {
        public SampleDbContext()
            : base("name=SampleModel")
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .ToTable("Post")
                .HasOptional(p => p.Blog)
                .WithMany(b => b.Posts)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Blog>()
                .ToTable("Blog");

        }

    }

}