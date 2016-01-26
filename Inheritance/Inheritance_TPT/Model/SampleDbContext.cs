namespace Inheritance.Model
{
    using Model;
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

        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().ToTable("Teacher");
            modelBuilder.Entity<Student>().ToTable("Student");
        }


    }

}