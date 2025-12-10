using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Tailwind.Traders.Product.Api.Infrastructure
{
    public class ProccessCsv : IProcessFile
    {
        private readonly ILogger<ProccessCsv> _logger;
        private readonly IEnumerable<ClassMap> _classMaps;

        public ProccessCsv(ILogger<ProccessCsv> logger, IEnumerable<ClassMap> classMaps)
        {
            _logger = logger;
            _classMaps = classMaps;
        }

        public IEnumerable<TModel> Process<TModel>(string root, string fileName, CsvConfiguration configuration = null)
        {
            try
            {
                _logger.LogDebug($"Start process file from path {Path.Combine(root, "Setup", $"{fileName}.csv")}");

                using (var reader = File.OpenText(Path.Combine(root, "Setup", $"{fileName}.csv")))
                {
                    var config = configuration ?? new CsvConfiguration(CultureInfo.InvariantCulture);
                    var csvReader = new CsvReader(reader, config);

                    RegisterMappers(csvReader.Context);

                    var model = csvReader.GetRecords<TModel>().ToList();

                    _logger.LogDebug($"End process file from path {Path.Combine(root, "Setup", $"{fileName}.csv")}");

                    return model;
                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Error try to process file from path {Path.Combine(root, "Setup", $"{ fileName}.csv")}");
                throw;
            }
        }

        private void RegisterMappers(CsvContext context)
        {
            foreach(var classMap in _classMaps)
            {
                context.RegisterClassMap(classMap.GetType());
            }
        }
    }
}
