using System;
using System.Collections.Generic;
using System.Text;
using SuppliesPriceLister.Model;
using System.Linq;

namespace SuppliesPriceLister
{
    public class FetchData
    {
        //Fetch data from both suppliers and merge
        public IList<SuppliesPrice> GetSupplies(IList<Humphries> humphrieslist, Megacorp megacorp)
        {
            IList<SuppliesPrice> suppliesPrices = new List<SuppliesPrice>();
            IList<SuppliesPrice> suppliesPrices2 = new List<SuppliesPrice>();

            var humphries = humphrieslist.Select(p => new { p.ID, p.Description, p.costAUD }).ToList();
            // var su = (IList<MegacorpSupplies>)megacorp.partners.Select(p => new { p.supplies }).ToList();
            foreach (var partner in megacorp.partners)
            {
                suppliesPrices2 = partner.supplies.Select(p => new SuppliesPrice()
                {
                    ID = Convert.ToString(p.ID),
                    ItemName = p.description,
                    Price = Convert.ToDecimal(p.priceinAUD)
                }).ToList();
            }
        
            //var frf = su.Select(p => new { p.ID , p.description, p.priceinAUD }).ToList();


            suppliesPrices = (from u in humphrieslist
                              select new SuppliesPrice()
                              {
                                  ID = u.ID,
                                  ItemName = u.Description,
                                  Price = Convert.ToDecimal(u.costAUD)
                              }).ToList()
                              .Union (from s in suppliesPrices2 select s).ToList();
            //(from u in su
            // select new SuppliesPrice()
            // {
            //     ID = Convert.ToString(u.ID),
            //     ItemName = u.description,
            //     Price = Convert.ToDecimal(u.priceinAUD)
            // }).ToList();

            return suppliesPrices; 
        }

    }
}
