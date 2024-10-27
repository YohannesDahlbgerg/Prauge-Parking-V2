using Prauge_Parking_V2.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Channels;


public class Parking
{

    // Parkeringsplatser
    static List<(string vehicleType, string regNumber)>[] parkingSpots = new List<(string, string)>[101];
    static readonly TimeSpan openingTime = new TimeSpan(7, 0, 0);
    static readonly TimeSpan closingTime = new TimeSpan(0, 0, 0);

    static void Main(string[] args)
    {
        Program.Second(args);
        // Skapar en lista för varje parkeringsruta
        for (int i = 0; i < parkingSpots.Length; i++)
        {
            parkingSpots[i] = new List<(string, string)>();
        }


        while (true)
        {
            ShowMenu();
            switch (Console.ReadLine())
            {
                case "1":
                    ParkVehicle();
                    break;
                case "2":
                    MoveVehicle();
                    break;
                case "3":
                    RemoveVehicle();
                    break;
                case "4":
                    SearchVehicle();
                    break;
                case "5":
                    ShowParkingStatus();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }
    }

    static void ParkVehicle()
    {
        if (!IsParkingOpen())
        {
            Console.WriteLine("Parkeringssystemet är stängt. Öppettider: 07:00 - 00:00.");
            return;
        }

        Console.Write("Ange fordonstyp (MC eller CAR): ");
        string vehicleType = Console.ReadLine().ToUpper();
        Console.Write("Ange registreringsnummer: ");
        string regNumber = Console.ReadLine();


        if (string.IsNullOrWhiteSpace(regNumber) || (vehicleType != "MC" && vehicleType != "CAR"))
        {
            Console.WriteLine("Ogiltigt fordonstyp eller registreringsnummer angivet.");
            return;
        }

        // Hitta en ledig plats
        for (int i = 0; i < parkingSpots.Length; i++)
        {
            if ((vehicleType == "MC" && (parkingSpots[i].Count == 0 || (parkingSpots[i].Count == 1 && parkingSpots[i][0].vehicleType == "MC"))) ||
                (vehicleType == "CAR" && parkingSpots[i].Count == 0))
            {
                parkingSpots[i].Add((vehicleType, regNumber));
                Console.WriteLine($"{vehicleType + regNumber} har parkerats på plats {i + 1}.");
                return;
            }
        }

        Console.WriteLine($"Det finns ingen ledig parkeringsplats för {vehicleType}.");
    }

    static void MoveVehicle()
    {
        Console.Write("Ange registreringsnummer: ");
        string regNumber = Console.ReadLine();

        int currentSpot = FindVehicle(regNumber);
        if (currentSpot == -1)
        {
            Console.WriteLine("Fordonet kunde inte hittas.");
            return;
        }

        Console.Write("Ange ny platsnummer (1-100): ");
        if (int.TryParse(Console.ReadLine(), out int newSpot) && newSpot >= 1 && newSpot <= 100)
        {
            newSpot--;

            var vehicle = parkingSpots[currentSpot][0];
            // Kontrollera om den nya platsen kan rymma fordonet
            if ((vehicle.vehicleType == "MC" && (parkingSpots[newSpot].Count == 0 || (parkingSpots[newSpot].Count == 1 && parkingSpots[newSpot][0].vehicleType == "MC"))) ||
                (vehicle.vehicleType == "CAR" && parkingSpots[newSpot].Count == 0))
            {
                parkingSpots[newSpot].Add(vehicle);
                parkingSpots[currentSpot].RemoveAt(0); // Ta bort fordonet från sin gamla plats


                if (parkingSpots[currentSpot].Count == 0)
                {
                    parkingSpots[currentSpot] = new List<(string, string)>();
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

    static void RemoveVehicle()
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

    static void SearchVehicle()
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

    static int FindVehicle(string regNumber)
    {
        for (int i = 0; i < parkingSpots.Length; i++)
        {
            if (parkingSpots[i].Exists(v => v.regNumber.Equals(regNumber, StringComparison.OrdinalIgnoreCase)))
            {
                return i;
            }
        }
        return -1;
    }

    static void ShowParkingStatus()
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

    static void ShowMenu()
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

    static bool IsParkingOpen()
    {
        var currentTime = DateTime.Now.TimeOfDay;
        if (currentTime >= openingTime || currentTime < closingTime)
        {
            return true;
        }
        return false;
    }

   

}

class Program
{
    public static void Second(string[] args)
    {
        // Skapa en instans av Reader-klassen
        Readjson reader = new Readjson();

        // Anropa metoden Läser
        reader.Laser();
    }
}