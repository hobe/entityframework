using Inheritance.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitalizerSample.Model
{
    public class MyDbConfigInitializer : DropCreateDatabaseIfModelChanges<SampleDbContext>
    {
        protected override void Seed(SampleDbContext context)
        {
            IList<Person> people = new List<Person>();
            people.Add(new Person() { LastName = "bernhard", DateOfBirth = DateTime.Now });
            foreach (Person p in people)
                context.People.Add(p);

            base.Seed(context);
        }
    } 

}
