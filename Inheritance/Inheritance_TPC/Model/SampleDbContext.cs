namespace Inheritance
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// Sample for showing how to use Table-Per-Concrete-Type (TPC)
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

            modelBuilder.Entity<Person>()
              .Property(p => p.ID)
              .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            modelBuilder.Entity<Teacher>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Teacher");
            });

            modelBuilder.Entity<Student>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Student");
            });
        }


    }

}