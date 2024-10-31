using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prauge_Parking_V2.Parking;

namespace Gruppuppgift_Parkingv2.Parkingv2mapp
{
    public class Pricelist
    {
        private readonly string _filePath;
        public Dictionary<string, int> Prices { get; private set; } = new Dictionary<string, int>();

        public Pricelist(string filePath)
        {
            _filePath = filePath;
            LoadPrices();
        }

        // Laddar priser från fil
        public void LoadPrices()
        {
            Prices.Clear();

            foreach (var line in File.ReadLines(_filePath))
            {
                var cleanedLine = line.Split('#')[0].Trim(); // Ignorera kommentarer
                if (string.IsNullOrWhiteSpace(cleanedLine)) continue;

                var parts = cleanedLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 2 && int.TryParse(parts[1], out int amount))
                    Prices[parts[0]] = amount;
            }
        }

        // Visar prislistan
        public void DisplayPrices()
        {
            Console.WriteLine("\nAktuell Prislista:");
            foreach (var entry in Prices)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value} CZK per timme");
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            var priceList = new Pricelist("prislista.txt");

            while (true)
            {
                Console.WriteLine("\nVälj ett alternativ:");
                Console.WriteLine("1. Ladda om prislistan");
                Console.WriteLine("2. Visa prislistan");
                Console.WriteLine("3. Avsluta");

                var choice = Console.ReadLine();
                if (choice == "1")
                {
                    priceList.LoadPrices();
                    Console.WriteLine("Prislistan har laddats om.");
                }
                else if (choice == "2")
                {
                    priceList.DisplayPrices();
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Avslutar...");
                    break;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val, försök igen.");
                }
            }
        }
    }
}
