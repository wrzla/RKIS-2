namespace Filters
{
	class Program
	{
		static void Main()
		{
			var products = new List<Product>
			{
				// Продукты в категории "Электроника"
				new Product("Смартфон", DateTime.Now.AddYears(-1), null, Category.Electronics, 12999.99m, 50),
				new Product("Ноутбук", DateTime.Now.AddMonths(-6), null, Category.Electronics, 24999.99m, 30),
				new Product("Умные часы", DateTime.Now.AddMonths(-2), null, Category.Electronics, 5999.99m, 100),

				// Продукты в категории "Одежда"
				new Product("Джинсы", DateTime.Now.AddMonths(-6), null, Category.Clothing, 999.99m, 150),
				new Product("Шорты", DateTime.Now.AddMonths(-2), null, Category.Clothing, 499.99m, 200),
				new Product("Костюм", DateTime.Now.AddMonths(-8), null, Category.Clothing, 3999.99m, 70),

				// Продукты в категории "Мебель"
				new Product("Диван", DateTime.Now.AddYears(-2), null, Category.Furniture, 29999.99m, 5),
				new Product("Стол", DateTime.Now.AddMonths(-5), null, Category.Furniture, 11999.99m, 20),
				new Product("Кресло", DateTime.Now.AddMonths(-6), null, Category.Furniture, 10999.99m, 80),

				// Продукты в категории "Продукты питания"
				new Product("Хлеб", DateTime.Now.AddDays(-10), TimeSpan.FromDays(7), Category.Food, 199.99m, 500),
				new Product("Молоко", DateTime.Now.AddDays(-4), TimeSpan.FromDays(7), Category.Food, 99.99m, 100),
				new Product("Сыр", DateTime.Now.AddDays(-2), TimeSpan.FromDays(30), Category.Food, 499.99m, 200)
			};


			// Пример сложных фильтров
			var electronicsFilter = ProductFilters.FilterByCategory(Category.Electronics);
			var priceFilter = ProductFilters.FilterByPrice(5000, 30000);
			var stockFilter = ProductFilters.FilterByStock(50);
			var nameFilter = ProductFilters.FilterByNameContains("часы");
			//nameFilter = ProductService.Not(nameFilter);

			// Комбинация фильтров
			var complexFilter = ProductService.And(
				electronicsFilter,
				priceFilter,
				stockFilter,
				nameFilter);

			var filteredProducts = ProductService.FilterProducts(products, complexFilter);

			Console.WriteLine("And Filter:");
			foreach (var product in filteredProducts)
			{
				Console.WriteLine($"{product.Name}, {product.Category}, Price: {product.Price}, Stock: {product.StockCount}");
			}

			Console.WriteLine("\nOr Filter:");
			var orFilter = ProductService.Or(
				ProductFilters.FilterByCategory(Category.Clothing),
				ProductFilters.FilterByCategory(Category.Food));

			var orFilteredProducts = ProductService.FilterProducts(products, orFilter);
			foreach (var product in orFilteredProducts)
			{
				Console.WriteLine($"{product.Name}, {product.Category}, Price: {product.Price}, Stock: {product.StockCount}");
			}

			// Пример XOR-операции: выбираем товары, количество которых меньше 100, либо одежду, но не одновременно
			Console.WriteLine("\nXor Filter:");
			var xorFilter = ProductService.Xor(
				ProductService.Not(ProductFilters.FilterByStock(100)),
				ProductFilters.FilterByCategory(Category.Clothing));

			var xorFilteredProducts = ProductService.FilterProducts(products, xorFilter);
			foreach (var product in xorFilteredProducts)
			{
				Console.WriteLine($"{product.Name}, {product.Category}, Price: {product.Price}, Stock: {product.StockCount}");
			}
		}
	}
}
