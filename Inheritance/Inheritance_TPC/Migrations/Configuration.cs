namespace Inheritance.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Inheritance.SampleDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Inheritance.SampleDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.People.AddOrUpdate(new Model.Teacher()
            {
                ID = 1,
                FirstName = "Bernhard",
                LastName = "Hochgatterer",
                DateOfBirth = new DateTime(1986, 07, 12),
                Subject = "Math"
            });

            context.People.AddOrUpdate(new Model.Student
            {
                ID = 2,
                DateOfBirth = DateTime.Now,
                LastName = "TEacher",
                FirstName = "First",
                EnrollmentDate = DateTime.Now
            });

        }
    }
}
