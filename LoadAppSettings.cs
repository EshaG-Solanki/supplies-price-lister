using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace SuppliesPriceLister
{
    public static class LoadAppSettings
    {
        //private LoadConfigs _loadConfigs = new LoadConfigs();
        private static string _exchangeRate;
        private static string _filePathHumphries;
        private static string _filePathMegacorp;




        public static void LoadParameters()
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _exchangeRate = builder.Build().GetSection("audUsdExchangeRate").Value;

            _filePathHumphries = builder.Build().GetSection("filePaths").GetSection("Humphries").Value;
            _filePathMegacorp = builder.Build().GetSection("filePaths").GetSection("Megacorp").Value;

        }

        public static decimal ExchangeRate
        {
            get
            {
                //TODO add checks for null value and valid decimal
                return Convert.ToDecimal(_exchangeRate);
            }
        }

        public static string FilePathHumphries
        {
            get
            {
                if (!String.IsNullOrEmpty(_filePathHumphries))
                    return _filePathHumphries;
                else
                    throw new Exception("FilePath for Humphries not found. Please check appsettings.");
            }
        }

        public static string FilePathMegacorp
        {
            get
            {
                if (!String.IsNullOrEmpty(_filePathMegacorp))
                    return _filePathMegacorp;
                else
                    throw new Exception("FilePath for MegaCorp not found. Please check appsettings.");
            }
        }

    }
}
