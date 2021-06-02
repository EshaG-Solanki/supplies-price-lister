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
        //Fill data from json file
        public MegacorpProvider()
        {
            string jsonString = File.ReadAllText(LoadAppSettings.FilePathMegacorp);
            Megacorp megacorpSupplies = JsonSerializer.Deserialize<Megacorp>(jsonString);          
            
        }
    }
}
