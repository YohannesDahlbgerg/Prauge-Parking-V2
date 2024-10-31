using Prauge_Parking_V2.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//namespace Prauge_Parking_V2.Parking
//{
//    public class ParkingSpot : ParkingS
//    {
//        public List<(string vehicleType, string regNumber)>[] parkingSpots = new List<(string, string)>[101];
//        public readonly TimeSpan openingTime = new TimeSpan(7, 0, 0);
//        public readonly TimeSpan closingTime = new TimeSpan(0, 0, 0);

//        public ParkingSpot()
//        {
//            // Initierar varje parkeringsplats som en tom lista
//            for (int i = 0; i < parkingSpots.Length; i++)
//            {
//                parkingSpots[i] = new List<(string, string)>();
//            }
//        }

//        // Metod för att kontrollera om parkeringen är öppen
//        public bool IsParkingOpen()
//        {
//            var currentTime = DateTime.Now.TimeOfDay;
//            return currentTime >= openingTime || currentTime < closingTime;
//        }

//        // Metod för att hitta ett fordon baserat på registreringsnummer
//        public int FindVehicle(string regNumber)
//        {
//            for (int i = 0; i < parkingSpots.Length; i++)
//            {
//                if (parkingSpots[i].Exists(v => v.regNumber.Equals(regNumber, StringComparison.OrdinalIgnoreCase)))
//                {
//                    return i; // Returnerar platsen där fordonet hittades
//                }
//            }
//            return -1; // Returnerar -1 om fordonet inte hittades
//        }

//        // Metod för att parkera ett fordon
//        public void ParkVehicle()
//        {
//            if (!IsParkingOpen())
//            {
//                Console.WriteLine("Parkeringssystemet är stängt. Öppettider: 07:00 - 00:00.");
//                return;
//            }

//            Console.Write("Ange fordonstyp (MC eller CAR): ");
//            string vehicleType = Console.ReadLine().ToUpper();
//            Console.Write("Ange registreringsnummer: ");
//            string regNumber = Console.ReadLine();

//            if (string.IsNullOrWhiteSpace(regNumber) || (vehicleType != "MC" && vehicleType != "CAR"))
//            {
//                Console.WriteLine("Ogiltigt fordonstyp eller registreringsnummer angivet.");
//                return;
//            }

//            //Hitta en ledig plats
//            for (int i = 0; i < parkingSpots.Length; i++)
//            {
//                if ((vehicleType == "MC" && (parkingSpots[i].Count == 0 || (parkingSpots[i].Count == 1 && parkingSpots[i][0].vehicleType == "MC"))) ||
//                    (vehicleType == "CAR" && parkingSpots[i].Count == 0))
//                {
//                    parkingSpots[i].Add((vehicleType, regNumber));
//                    Console.WriteLine($"{vehicleType} {regNumber} har parkerats på plats {i + 1}.");
//                    return;
//                }
//            }



//            Console.WriteLine($"Det finns ingen ledig parkeringsplats för {vehicleType}.");
//        }

//    }

//}


/////////////////////////////////////////////////////
///
public class ParkingSpot : ParkingS
{
    public int SpotId { get; set; }
    public int Capacity { get; set; }
    public List<Vehicle> ParkedVehicles { get; private set; } = new List<Vehicle>();

    public readonly TimeSpan openingTime = new TimeSpan(7, 0, 0);
    public readonly TimeSpan closingTime = new TimeSpan(0, 0, 0);


    public bool IsParkingOpen()
    {
        var currentTime = DateTime.Now.TimeOfDay;
        return currentTime >= openingTime || currentTime < closingTime;
    }

    public bool CanFit(Vehicle vehicle)
    {
        int totalSize = ParkedVehicles.Sum(v => v.Size) + vehicle.Size;
        return totalSize <= Capacity;
    }

    public bool ParkVehicle(Vehicle vehicle)
    {
        if (!IsParkingOpen())
        {
            Console.WriteLine("Parkeringssystemet är stängt. Öppettider: 07:00 - 00:00.");
            return false;
        }

        if (CanFit(vehicle))
        {
            ParkedVehicles.Add(vehicle);
            Console.WriteLine($"{vehicle.Type} med registreringsnummer {vehicle.LicensePlate} har parkerats.");
            return true;
        }

        Console.WriteLine($"Det finns ingen ledig plats för {vehicle.Type}.");
        return false;
    }

    public void RemoveVehicle(string licensePlate)
    {
        var vehicle = ParkedVehicles.FirstOrDefault(v => v.LicensePlate == licensePlate);
        if (vehicle != null)
        {
            ParkedVehicles.Remove(vehicle);
            Console.WriteLine($"{vehicle.Type} med registreringsnummer {licensePlate} har tagits bort.");
        }
        else
        {
            Console.WriteLine($"Fordon med registreringsnummer {licensePlate} hittades inte.");
        }
    }
}
