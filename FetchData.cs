using System;
using System.Collections.Generic;
using System.Text;
using SuppliesPriceLister.Model;
using System.Linq;

namespace SuppliesPriceLister
{
    public class FetchData
    {
        /// <summary>
        /// Fetch data from both suppliers and merge
        /// </summary>
        /// <param name="humphrieslist"></param>
        /// <param name="megacorp"></param>
        /// <returns></returns>
        public IEnumerable<SuppliesPrice> GetSupplies(IList<Humphries> humphrieslist, Megacorp megacorp)
        {
            IList<SuppliesPrice> humphriesSuppliesPrices = GethumphriesSupplies(humphrieslist);
            IList<SuppliesPrice> megacorpSuppliesPrices = GetmegacorpSupplies(megacorp);
            IList<SuppliesPrice> suppliesPrices = new List<SuppliesPrice>();

            var result = humphriesSuppliesPrices.Union(megacorpSuppliesPrices).AsEnumerable().OrderByDescending(x=>x.Price);

            return result; 
        }

        /// <summary>
        /// Fetch GetmegacorpSupplies
        /// </summary>
        /// <param name="megacorp"></param>
        /// <returns></returns>
        private IList<SuppliesPrice> GetmegacorpSupplies(Megacorp megacorp)
        {
            IList<SuppliesPrice> suppliesPrices = new List<SuppliesPrice>();
            foreach (var partner in megacorp.partners)
            {
                suppliesPrices = suppliesPrices.Union(partner.supplies.Select(p => new SuppliesPrice()
                {
                    ID = Convert.ToString(p.id),
                    ItemName = p.description,
                    Price = Convert.ToDecimal(p.priceinAUD)
                })).ToList();

            }
            return (from s in suppliesPrices select s).ToList();
        }

        /// <summary>
        /// Fetch GethumphriesSupplies
        /// </summary>
        /// <param name="humphrieslist"></param>
        /// <returns></returns>
        private IList<SuppliesPrice> GethumphriesSupplies(IList<Humphries> humphrieslist)
        {
            return (from u in humphrieslist
                    select new SuppliesPrice()
                    {
                        ID = u.ID,
                        ItemName = u.Description,
                        Price = Convert.ToDecimal(u.costAUD)
                    }).ToList();
        }
    }
}
