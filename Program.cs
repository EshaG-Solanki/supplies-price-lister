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
            //1. Load appsettings data
            LoadAppSettings.LoadParameters();

            //Create initial objects
            MegacorpProvider megacorpProvider = new MegacorpProvider();
            HumphriesProvider humphriesProvider = new HumphriesProvider();
            FetchData fetchdata = new FetchData();

            //2. Load Megacorp supplies into data model
            Megacorp megacorp = megacorpProvider.GetMegacorpSupplies();
            //3. Load Humphries supplies into data model
            IList<Humphries> humphries = humphriesProvider.GetHumphriesSupplies();

            //4. Concatenate and get both results in order by desc price list
            var result = fetchdata.GetSupplies(humphries, megacorp);

            //5. Push data to console
            foreach (SuppliesPrice s in result)
            {
                Console.Write(s.ID + ",");
                Console.Write(s.ItemName + ",");
                Console.Write(s.Price );
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
