using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prauge_Parking_V2.Parking
{
    internal class ParkingGarage : ParkingSpot
    {
        public void ShowParkingStatus()
        {
            Console.WriteLine("\nParkeringsstatus:");
            for (int i = 0; i < parkingSpots.Length; i++)
            {
                if (parkingSpots[i].Count > 0)
                {
                    Console.WriteLine($"Plats {i + 1}: {string.Join(", ", parkingSpots[i].Select(v => $"{v.vehicleType} ({v.regNumber})"))}");
                }
                else
                {
                    Console.WriteLine($"Plats {i + 1}: [TOM]");
                }
            }
        }
    }
}
