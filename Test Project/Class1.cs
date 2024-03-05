using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Project.Database;

namespace Test_Project
{
    internal class Class1
    {
        [Test]
        public void Test()
        {
            var ctx = new DatabaseContext();

            var data = ctx.YourEntities.ToList();

        }
    }
}
