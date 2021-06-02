using SuppliesPriceLister.Model;
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

        }

        /// <summary>
        /// Fill data from XML file.
        /// File location in appsettings.json
        /// </summary>
        /// <returns></returns>
        public IList<Humphries> GetHumphriesSupplies()
        {
            
            IList<Humphries> values = File.ReadAllLines(LoadAppSettings.FilePathHumphries)
                                           .Skip(1)
                                           .Select(v => Humphries.FromCsv(v))
                                           .ToList();
            return values;
        }
    }
}
