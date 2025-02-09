namespace Filters
{
	public static class ProductFilters
	{
		public static Func<Product, bool> FilterByCategory(Category category)
		{
			return ...;
		}

		public static Func<Product, bool> FilterByPrice(decimal minPrice, decimal maxPrice)
		{
			return ...;
		}

		public static Func<Product, bool> FilterByStock(int minStock)
		{
			return ...;
		}

		public static Func<Product, bool> FilterByExpirationDate(DateTime date)
		{
			return ...
		}

		public static Func<Product, bool> FilterByNameContains(string namePart)
		{
			return ...;
		}
	}
}
