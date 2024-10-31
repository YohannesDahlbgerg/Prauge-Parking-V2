using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prauge_Parking_V2.Parking
{
    public class ParkingGarage
    {
        public List<List<(string vehicleType, string regNumber)>> parkingSpots;

        public ParkingGarage(int totalSpots)
        {
            // Initiera listan med parkeringsplatser
            parkingSpots = new List<List<(string, string)>>();
            for (int i = 0; i < totalSpots; i++)
            {
                parkingSpots.Add(new List<(string, string)>());
            }
        }

        public void ShowParkingStatus()
        {
            Console.WriteLine("\nParkeringsstatus:");
            for (int i = 0; i < parkingSpots.Count; i++)
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

