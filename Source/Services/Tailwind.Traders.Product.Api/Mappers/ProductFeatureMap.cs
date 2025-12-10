using CsvHelper.Configuration;
using System.Globalization;
using Tailwind.Traders.Product.Api.Models;

namespace Tailwind.Traders.Product.Api.Mappers
{
    public sealed class ProductFeatureMap : ClassMap<ProductFeature>
    {
        public ProductFeatureMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
        }
    }
}
