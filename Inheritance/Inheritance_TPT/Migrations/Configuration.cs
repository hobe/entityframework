namespace Inheritance_TPT.Migrations
{
    using Inheritance.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Inheritance.Model.SampleDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Inheritance.Model.SampleDbContext context)
        {
            context.People.AddOrUpdate(new Teacher
            {
                FirstName = "Bernhard",
                LastName = "Hochgatterer",
                DateOfBirth = new DateTime(1986, 07, 12),
                Subject = "Math"
            });

            context.People.AddOrUpdate(new Student
            {
                DateOfBirth = DateTime.Now,
                LastName = "Teacher",
                FirstName = "First",
                EnrollmentDate = DateTime.Now
            });
        }
    }
}
