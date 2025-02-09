namespace Filters
{
	public static class ProductService
	{
		public static List<Product> FilterProducts(List<Product> products, Func<Product, bool> filter)
		{
			var filteredProducts = new List<Product>();

			foreach (var product in products)
			{
				if (filter(product))
					filteredProducts.Add(product);
			}

			return filteredProducts;
		}

		//напишите методы Not, And, Or и Xor
	}
}
