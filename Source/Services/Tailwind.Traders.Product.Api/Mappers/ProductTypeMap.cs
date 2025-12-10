using CsvHelper.Configuration;
using System.Globalization;
using Tailwind.Traders.Product.Api.Models;

namespace Tailwind.Traders.Product.Api.Mappers
{
    public class ProductTypeMap : ClassMap<ProductType>
    {
        public ProductTypeMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
        }
    }
}
