using Xunit;
using AdventureWorks.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace test.integration
{
    public class DbContextTests
    {
        const string connectionString = "Server=localhost,1433;Database=AdventureWorks;User Id=SA;Password=my_password";

        [Fact]
        public void GetProductsTests()
        {
            var context = AdventureWorksContextFactory.GetContext(connectionString);
            var products = context.Products.Include(x => x.ProductModel).ToList();
            var models = products.Where(x => x.ProductModel != null).Select(x => x.ProductModel).ToList();

            Assert.NotNull(products);
            Assert.True(products.Count() > 0);

            Assert.NotNull(models);
            Assert.True(models.Count() > 0);
        }
    }
}