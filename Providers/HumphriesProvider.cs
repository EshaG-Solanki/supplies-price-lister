using SuppliesPriceLister.Models;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

namespace SuppliesPriceLister.Providers
{
    class HumphriesProvider
    {
        public HumphriesProvider()
        {
            //Fill data from XML file 
            List<Humphries> values = File.ReadAllLines(LoadAppSettings.FilePathHumphries)
                                           .Skip(1)
                                           .Select(v => Humphries.FromCsv(v))
                                           .ToList();

        }
    }
}
