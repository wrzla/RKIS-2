using NUnit.Framework;

namespace Filters
{
	public class ProductFiltersTest
	{
		[Test]
		public void TestFilterByCategory()
		{
			var products = new List<Product>
			{
				new Product("Smartphone", DateTime.Now.AddYears(-1), TimeSpan.FromDays(365), Category.Electronics, 499.99m, 50),
				new Product("Jeans", DateTime.Now.AddMonths(-6), TimeSpan.FromDays(365), Category.Clothing, 39.99m, 150)
			};

			var electronicsFilter = ProductFilters.FilterByCategory(Category.Electronics);
			var filteredProducts = ProductService.FilterProducts(products, electronicsFilter);

			Assert.AreEqual(1, filteredProducts.Count);
			Assert.AreEqual("Smartphone", filteredProducts.First().Name);
		}

		[Test]
		public void TestFilterByPrice()
		{
			var products = new List<Product>
			{
				new Product("Smartphone", DateTime.Now.AddYears(-1), TimeSpan.FromDays(365), Category.Electronics, 499.99m, 50),
				new Product("Jeans", DateTime.Now.AddMonths(-6), TimeSpan.FromDays(365), Category.Clothing, 39.99m, 150)
			};

			var priceFilter = ProductFilters.FilterByPrice(100, 500);
			var filteredProducts = ProductService.FilterProducts(products, priceFilter);

			Assert.AreEqual(1, filteredProducts.Count);
			Assert.AreEqual("Smartphone", filteredProducts.First().Name);
		}

		[Test]
		public void TestNotOperation()
		{
			var products = new List<Product>
			{
				new Product("Smartphone", DateTime.Now.AddYears(-1), TimeSpan.FromDays(365), Category.Electronics, 499.99m, 50),
				new Product("Jeans", DateTime.Now.AddMonths(-6), TimeSpan.FromDays(365), Category.Clothing, 39.99m, 150)
			};

			var electronicsFilter = ProductFilters.FilterByCategory(Category.Electronics);
			var notElectronicsFilter = ProductService.Not(electronicsFilter);
			var filteredProducts = ProductService.FilterProducts(products, notElectronicsFilter);

			Assert.AreEqual(1, filteredProducts.Count);
			Assert.AreEqual("Jeans", filteredProducts.First().Name);
		}

		[Test]
		public void TestAndManyOperation()
		{
			var products = new List<Product>
			{
				new Product("Smartphone", DateTime.Now.AddYears(-1), TimeSpan.FromDays(365), Category.Electronics, 499.99m, 50),
				new Product("Jeans", DateTime.Now.AddMonths(-6), TimeSpan.FromDays(365), Category.Clothing, 39.99m, 150)
			};

			var electronicsFilter = ProductFilters.FilterByCategory(Category.Electronics);
			var affordableFilter = ProductFilters.FilterByPrice(100, 500);
			var stockFilter = ProductFilters.FilterByStock(10);

			var andManyFilter = ProductService.And(electronicsFilter, affordableFilter, stockFilter);
			var filteredProducts = ProductService.FilterProducts(products, andManyFilter);

			Assert.AreEqual(1, filteredProducts.Count);
			Assert.AreEqual("Smartphone", filteredProducts.First().Name);
		}

		[Test]
		public void TestOrManyOperation()
		{
			var products = new List<Product>
			{
				new Product("Smartphone", DateTime.Now.AddYears(-1), TimeSpan.FromDays(365), Category.Electronics, 499.99m, 50),
				new Product("Jeans", DateTime.Now.AddMonths(-6), TimeSpan.FromDays(365), Category.Clothing, 39.99m, 150)
			};

			var electronicsFilter = ProductFilters.FilterByCategory(Category.Electronics);
			var affordableFilter = ProductFilters.FilterByPrice(100, 500);
			var stockFilter = ProductFilters.FilterByStock(200);

			var orManyFilter = ProductService.Or(electronicsFilter, affordableFilter, stockFilter);
			var filteredProducts = ProductService.FilterProducts(products, orManyFilter);

			Assert.AreEqual(2, filteredProducts.Count);
		}

		[Test]
		public void TestXorManyOperation()
		{
			var products = new List<Product>
			{
				new Product("Smartphone", DateTime.Now.AddYears(-1), TimeSpan.FromDays(365), Category.Electronics, 499.99m, 50),
				new Product("Jeans", DateTime.Now.AddMonths(-6), TimeSpan.FromDays(365), Category.Clothing, 39.99m, 150)
			};

			var electronicsFilter = ProductFilters.FilterByCategory(Category.Electronics);
			var affordableFilter = ProductFilters.FilterByPrice(100, 500);
			var stockFilter = ProductFilters.FilterByStock(10);

			var xorManyFilter = ProductService.Xor(electronicsFilter, affordableFilter, stockFilter);
			var filteredProducts = ProductService.FilterProducts(products, xorManyFilter);

			Assert.AreEqual(1, filteredProducts.Count);
		}
	}
}
