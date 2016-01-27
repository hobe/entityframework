namespace Inheritance.Model
{
    using InitalizerSample.Model;
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
            : base("name=MyDbContext")
        {
            //Database.SetInitializer<SampleDbContext>(new DropCreateDatabaseAlways<SampleDbContext>());
            Database.SetInitializer<SampleDbContext>(new MyDbConfigInitializer());
        }

        public virtual DbSet<Person> People { get; set; }

        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
        }


    }

}