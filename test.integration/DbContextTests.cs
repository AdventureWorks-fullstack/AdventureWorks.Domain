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
        public void GetProductsTest()
        {
            var context = AdventureWorksContextFactory.GetContext(connectionString);
            var products = context.Products.Include(x => x.ProductModel).ToList();
            var models = products.Where(x => x.ProductModel != null).Select(x => x.ProductModel).ToList();

            Assert.NotNull(products);
            Assert.True(products.Count() > 0);

            Assert.NotNull(models);
            Assert.True(models.Count() > 0);
        }
        [Fact]
        public void GetSalesTest()
        {
            var context = AdventureWorksContextFactory.GetContext(connectionString);
            var sales = context.SalesOrderDetails.Include(x => x.Product);
            var products = sales.Where(x => x.Product != null).Select(x => x.Product).ToList();

            Assert.NotNull(sales);
            Assert.True(sales.Count() > 0);

            Assert.NotNull(products);
            Assert.True(products.Count() > 0);
        }
    }
}