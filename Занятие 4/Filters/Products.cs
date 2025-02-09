namespace Filters
{
	public enum Category
	{
		Electronics,
		Clothing,
		Food,
		Furniture
	}

	public class Product
	{
		public string Name { get; set; }
		public DateTime ProductionDate { get; set; }
		public TimeSpan? ExpirationDate { get; set; }
		public Category Category { get; set; }
		public decimal Price { get; set; }
		public int StockCount { get; set; }

		public Product(string name, DateTime productionDate, TimeSpan? expirationDate, Category category, decimal price, int stockCount)
		{
			Name = name;
			ProductionDate = productionDate;
			ExpirationDate = expirationDate;
			Category = category;
			Price = price;
			StockCount = stockCount;
		}
	}
}
