using Prauge_Parking_V2.Parking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prauge_Parking_V2.Parking
{
    public class Search : Find
    {
        public Search(int totalSpots) : base(totalSpots)
        {
        }

        public void SearchVehicle()
        {
            Console.Write("Ange registreringsnummer att söka: ");
            string regNumber = Console.ReadLine();

            int spot = FindVehicle(regNumber);
            if (spot == -1)
            {
                Console.WriteLine("Fordonet kunde inte hittas.");
            }
            else
            {
                Console.WriteLine($"Fordonet finns på plats {spot + 1}.");
            }
        }
    }
}

public class Find : ParkingGarage
{
    public Find(int totalSpots) : base(totalSpots) { }

    public int FindVehicle(string regNumber)
    {
        for (int i = 0; i < parkingSpots.Count; i++)
        {
            if (parkingSpots[i].Exists(v => v.regNumber.Equals(regNumber, StringComparison.OrdinalIgnoreCase)))
            {
                return i;
            }
        }
        return -1;
    }
}
