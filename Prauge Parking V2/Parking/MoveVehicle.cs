using Prauge_Parking_V2.Parking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Prauge_Parking_V2.Parking
//{
//    public class MoveVehicle : ParkingGarage
//    {
//        public MoveVehicle(int totalSpots) : base(totalSpots) { }

//        public void moveVehicle()
//        {
//            Console.Write("Ange registreringsnummer: ");
//            string regNumber = Console.ReadLine();

//            int currentSpot = FindVehicle(regNumber);
//            if (currentSpot == -1)
//            {
//                Console.WriteLine("Fordonet kunde inte hittas.");
//                return;
//            }

//            Console.Write("Ange ny platsnummer (1–100): ");
//            if (int.TryParse(Console.ReadLine(), out int newSpot) && newSpot >= 1 && newSpot <= 100)
//            {
//                newSpot--; // Justera för att använda nollindexering

//                var vehicle = parkingSpots[currentSpot][0];

//                // Kontrollera om den nya platsen kan rymma fordonet
//                if ((vehicle.vehicleType == "MC" && (parkingSpots[newSpot].Count == 0 || (parkingSpots[newSpot].Count == 1 && parkingSpots[newSpot][0].vehicleType == "MC"))) ||
//                    (vehicle.vehicleType == "CAR" && parkingSpots[newSpot].Count == 0))
//                {
//                    // Flytta fordonet
//                    parkingSpots[newSpot].Add(vehicle);
//                    parkingSpots[currentSpot].RemoveAt(0); // Ta bort fordonet från sin gamla plats

//                    // Om den gamla platsen nu är tom, återställ listan
//                    if (parkingSpots[currentSpot].Count == 0)
//                    {
//                        parkingSpots[currentSpot] = new List<(string vehicleType, string regNumber)>();
//                    }

//                    Console.WriteLine($"{vehicle.vehicleType} har flyttats till plats {newSpot + 1}.");
//                }
//                else
//                {
//                    Console.WriteLine("Den nya platsen är upptagen.");
//                }
//            }
//            else
//            {
//                Console.WriteLine("Ogiltigt platsnummer.");
//            }
//        }
//    }
//}

/////////////////////////////////////////////////////////////////
///
namespace Prauge_Parking_V2.Parking;
public class MoveVehicle : ParkingGarage
{
    public MoveVehicle(int totalSpots) : base(totalSpots) { }

    public void moveVehicle()
    {
        Console.Write("Ange registreringsnummer: ");
        string regNumber = Console.ReadLine();

        int currentSpot = FindVehicle(regNumber);
        if (currentSpot == -1)
        {
            Console.WriteLine("Fordonet kunde inte hittas.");
            return;
        }

        Console.Write("Ange ny platsnummer (1–100): ");
        if (int.TryParse(Console.ReadLine(), out int newSpot) && newSpot >= 1 && newSpot <= 100)
        {
            newSpot--; // Justera för att använda nollindexering

            var vehicle = parkingSpots[currentSpot][0];

            // Kontrollera om den nya platsen kan rymma fordonet
            if ((vehicle.vehicleType == "MC" && (parkingSpots[newSpot].Count == 0 || (parkingSpots[newSpot].Count == 1 && parkingSpots[newSpot][0].vehicleType == "MC"))) ||
                (vehicle.vehicleType == "CAR" && parkingSpots[newSpot].Count == 0))
            {
                // Flytta fordonet
                parkingSpots[newSpot].Add(vehicle);
                parkingSpots[currentSpot].RemoveAt(0); // Ta bort fordonet från sin gamla plats

                // Om den gamla platsen nu är tom, återställ listan
                if (parkingSpots[currentSpot].Count == 0)
                {
                    parkingSpots[currentSpot] = new List<(string vehicleType, string regNumber)>();
                }

                Console.WriteLine($"{vehicle.vehicleType} har flyttats till plats {newSpot + 1}.");
            }
            else
            {
                Console.WriteLine("Den nya platsen är upptagen.");
            }
        }
        else
        {
            Console.WriteLine("Ogiltigt platsnummer.");
        }
    }

    private int FindVehicle(string regNumber)
    {
        for (int i = 0; i < parkingSpots.Count; i++)
        {
            if (parkingSpots[i].Any(v => v.regNumber == regNumber)) // Kolla registreringsnummer
            {
                return i; // Returplatsen där fordonet finns
            }
        }
        return -1; // Om fordonet inte hittas
    }
}
