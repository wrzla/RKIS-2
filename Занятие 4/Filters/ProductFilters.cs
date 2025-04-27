using System;

namespace Filters
{
    public static class ProductFilters
    {
        public static Func<Product, bool> FilterByCategory(Category category)
        {
            return product => product.Category == category;
        }

        public static Func<Product, bool> FilterByPrice(decimal minPrice, decimal maxPrice)
        {
            return product => product.Price >= minPrice && product.Price <= maxPrice;
        }

        public static Func<Product, bool> FilterByStock(int minStock)
        {
            return product => product.StockCount >= minStock;
        }

        public static Func<Product, bool> FilterByExpirationDate(DateTime currentDate)
        {
            return product => !product.ExpirationDate.HasValue ||  product.ProductionDate + product.ExpirationDate.Value >= currentDate;
        }

        public static Func<Product, bool> FilterByNameContains(string namePart)
        {
            return product => product.Name.Contains(namePart, StringComparison.OrdinalIgnoreCase);
        }
    }
}
