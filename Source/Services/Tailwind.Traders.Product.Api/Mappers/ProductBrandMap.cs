using CsvHelper.Configuration;
using System.Globalization;
using Tailwind.Traders.Product.Api.Models;

namespace Tailwind.Traders.Product.Api.Mappers
{
    public class ProductBrandMap : ClassMap<ProductBrand>
    {
        public ProductBrandMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
        }
    }
}
