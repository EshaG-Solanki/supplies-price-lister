using SuppliesPriceLister.Providers;
using System;
using SuppliesPriceLister.Model;
using System.Collections.Generic;

namespace SuppliesPriceLister
{
    class Program
    {
        static void Main(string[] args)
        {
            // Your solution begins here
            LoadAppSettings.LoadParameters();
            MegacorpProvider megacorpProvider = new MegacorpProvider();
            HumphriesProvider humphriesProvider = new HumphriesProvider();
            FetchData fetchdata = new FetchData();

            Megacorp megacorp = megacorpProvider.GetMegacorpSupplies();
            IList<Humphries> humphries = humphriesProvider.GetHumphriesSupplies();

            var result = fetchdata.GetSupplies(humphries, megacorp);
            foreach (SuppliesPrice s in result)
            {
                Console.Write(s.ID);
                Console.Write(s.ItemName);
                Console.Write(s.Price);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
