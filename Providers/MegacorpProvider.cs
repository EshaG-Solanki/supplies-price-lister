using SuppliesPriceLister.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SuppliesPriceLister.Providers
{
    class MegacorpProvider
    {        
        public MegacorpProvider()
        {                   
            
        }

        /// <summary>
        /// Fill data from json file
        /// File location in appsettings.json
        /// </summary>
        /// <returns></returns>
        public Megacorp GetMegacorpSupplies()
        {
            string jsonString = File.ReadAllText(LoadAppSettings.FilePathMegacorp);
            Megacorp megacorpSupplies = JsonSerializer.Deserialize<Megacorp>(jsonString);
            return megacorpSupplies;
        }
    }
}
