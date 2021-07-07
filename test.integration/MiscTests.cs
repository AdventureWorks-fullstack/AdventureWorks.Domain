using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.Domain.Migrations;
using Xunit;

namespace test.integration
{
    public class MiscTests
    {
        [Fact]
        public void GetShelvesTest()
        {
            var values = AddShelvesToWebshop.GetValues();

            //Assert.False(string.IsNullOrEmpty(values));
        }
    }
}
