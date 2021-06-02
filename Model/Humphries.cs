using System;
using System.Collections.Generic;
using System.Text;

namespace SuppliesPriceLister.Model
{
    public class Humphries
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public string unit { get; set; }
        public string costAUD { get; set; }

        public static Humphries FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Humphries humphriesSupplies = new Humphries();
            humphriesSupplies.ID = values[0];
            humphriesSupplies.Description = values[1];
            humphriesSupplies.unit = values[2];
            humphriesSupplies.costAUD = values[3];
            
            return humphriesSupplies;
        }
    }
}
