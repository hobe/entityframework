using Cubido.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUnitTestProject.TestDoubles
{
    /// <summary>
    /// The Find method is difficult to implement in a generic fashion. If you need to test 
    /// code that makes use of the Find method it is easiest to create a test DbSet for each 
    /// of the entity types that need to support find. You can then write logic to find that 
    /// particular type of entity, as shown below.
    /// </summary>
    public class TestBlogDbSet : TestDbSet<Blog>
    {
        public override Blog Find(params object[] keyValues)
        {
            var id = (int)keyValues.Single();
            return this.SingleOrDefault(b => b.BlogId == id);
        }
    }
}
