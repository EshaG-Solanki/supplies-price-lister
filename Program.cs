using SuppliesPriceLister.Providers;
using System;

namespace SuppliesPriceLister
{
    class Program
    {
        static void Main(string[] args)
        {
            // Your solution begins here
            LoadAppSettings.LoadParameters();
            MegacorpProvider megacorpProvider = new MegacorpProvider();
        }
    }
}
