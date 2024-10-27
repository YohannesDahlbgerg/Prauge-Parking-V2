using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prauge_Parking_V2._1.PraugeConsole
{
    internal class Menu
    {
        public static void ShowMenu()
        {
            Console.WriteLine("\n--- Parkeringssystem ---");
            Console.WriteLine("Öppet från 07:00 - 00:00, annars straffavgift.");
            Console.WriteLine("1. Parkera fordon");
            Console.WriteLine("2. Flytta fordon");
            Console.WriteLine("3. Ta bort fordon");
            Console.WriteLine("4. Sök efter fordon");
            Console.WriteLine("5. Visa parkeringsstatus");
            Console.WriteLine("6. Avsluta");
            Console.Write("Vänligen välj ett alternativ: ");
        }
    }
}
