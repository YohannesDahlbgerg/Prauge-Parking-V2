using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prauge_Parking_V2.Parking
{
    public class RemoveVehicle : ParkingSpot
    {
        public void removeVehicle()
        {
            Console.Write("Ange registreringsnummer att ta bort: ");
            string regNumber = Console.ReadLine();

            int spot = FindVehicle(regNumber);
            if (spot == -1)
            {
                Console.WriteLine("Fordonet kunde inte hittas.");
                return;
            }

            parkingSpots[spot].RemoveAt(0); // Ta bort fordonet
            Console.WriteLine($"Fordonet med registreringsnummer {regNumber} har tagits bort från plats {spot + 1}.");


            if (parkingSpots[spot].Count == 0)
            {
                parkingSpots[spot] = new List<(string, string)>();
            }
        }
    }
}
