//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;

//namespace Gruppuppgift_Parkingv2.Parking
//{
//    internal class Parkingspots
//    {

//    }

//    public class ParkingSpot
//    {
//        public int SpotNumber { get; }
//        public bool IsOccupied { get; private set; }

//        public ParkingSpot(int spotNumber)
//        {
//            SpotNumber = spotNumber;
//            IsOccupied = false;
//        }

//        public void ParkVehicle() => IsOccupied = true;
//        public void RemoveVehicle() => IsOccupied = false;

//        public override string ToString() => IsOccupied ? "[X]" : "[ ]";
//    }

//    public class ParkingGarage
//    {
//        private readonly List<ParkingSpot> _spots;

//        public ParkingGarage(int totalSpots)
//        {
//            _spots = new List<ParkingSpot>();
//            for (int i = 1; i <= totalSpots; i++)
//            {
//                _spots.Add(new ParkingSpot(i));
//            }
//        }

//        public void ParkVehicle(int spotNumber)
//        {
//            var spot = _spots.Find(s => s.SpotNumber == spotNumber);
//            if (spot != null && !spot.IsOccupied)
//            {
//                spot.ParkVehicle();
//                Console.WriteLine($"Fordon parkerat på plats {spotNumber}");
//            }
//            else
//            {
//                Console.WriteLine("Platsen är upptagen eller ogiltig.");
//            }
//        }

//        public void RemoveVehicle(int spotNumber)
//        {
//            var spot = _spots.Find(s => s.SpotNumber == spotNumber);
//            if (spot != null && spot.IsOccupied)
//            {
//                spot.RemoveVehicle();
//                Console.WriteLine($"Fordon borttaget från plats {spotNumber}");
//            }
//            else
//            {
//                Console.WriteLine("Platsen är redan ledig eller ogiltig.");
//            }
//        }



//public void DisplayMap(int spotsPerRow)
//{
//    Console.WriteLine("\nParkeringskarta:");
//    for (int i = 0; i < _spots.Count; i++)
//    {
//        Console.Write(_spots[i]);
//        if ((i + 1) % spotsPerRow == 0)
//        {
//            Console.WriteLine();
//        }
//    }
//    Console.WriteLine();
//}

//public int GetAvailableSpots() => _spots.FindAll(s => !s.IsOccupied).Count;
//    }



//    public class Program
//    {
//        public static void Main()
//        {
//            var garage = new ParkingGarage(100); // Skapar ett garage med 100 platser

//            while (true)
//            {
//                Console.WriteLine("\nVälj ett alternativ:");
//                Console.WriteLine("1. Parkera fordon");
//                Console.WriteLine("2. Hämta fordon");
//                Console.WriteLine("3. Visa karta");
//                Console.WriteLine("4. Visa antal lediga platser");
//                Console.WriteLine("5. Avsluta");

//                var choice = Console.ReadLine();
//                switch (choice)
//                {
//                    case "1":
//                        Console.Write("Ange platsnummer att parkera på (1-100): ");
//                        if (int.TryParse(Console.ReadLine(), out int parkSpot))
//                        {
//                            garage.ParkVehicle(parkSpot);
//                        }
//                        break;
//                    case "2":
//                        Console.Write("Ange platsnummer att hämta från (1-100): ");
//                        if (int.TryParse(Console.ReadLine(), out int removeSpot))
//                        {
//                            garage.RemoveVehicle(removeSpot);
//                        }
//                        break;
//                    case "3":
//                        garage.DisplayMap(10); // Visa 10 platser per rad
//                        break;
//                    case "4":
//                        Console.WriteLine($"Antal lediga platser: {garage.GetAvailableSpots()}");
//                        break;
//                    case "5":
//                        Console.WriteLine("Avslutar...");
//                        return;
//                    default:
//                        Console.WriteLine("Ogiltigt val, försök igen.");
//                        break;
//                }
//            }
//        }
//    }

//}