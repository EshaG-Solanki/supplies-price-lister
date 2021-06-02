using System;
using System.Collections.Generic;
using System.Text;

namespace SuppliesPriceLister.Model
{
    
    public class Megacorp
    {
        public List<partner> partners { get; set; }

    }

    //comment 2 added
    public class partner
    {
        public string name { get; set; }
        public string partnerType { get; set; }
        public string partnerAddress { get; set; }
        public IList<MegacorpSupplies> supplies { get; set; }
    }
    public class MegacorpSupplies
    {
        public Guid ID { get; set; }
        public string description { get; set; }
        public string uom { get; set; }
        public int priceInCents { get; set; }
        public string providerId { get; set; }
        public string materialType { get; set; }
        public decimal priceinAUD
        {
            get
            {
                return priceInCents / 100 * LoadAppSettings.ExchangeRate;

            }
        }
    }
}
