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

        /// <summary>
        /// Custom Discriminator ("PersonType") [optional, otherwise Column "Discriminator" would contain Name of Class (eg. "Teacher")]
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Map<Teacher>(m => m.Requires("PersonType").HasValue("T"))
                .Map<Student>(m => m.Requires("PersonType").HasValue("S"));
        }


    }

}