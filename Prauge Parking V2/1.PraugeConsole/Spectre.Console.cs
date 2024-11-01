//using Prauge_Parking_V2.VehicleTypes;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Prauge_Parking_V2._1.PraugeConsole
//{
//    internal class Class1
//    {
//        using Spectre.Console;

//    public class Program
//    {
//        static void Main()
//        {
//            var garage = new ParkingGarage(100, 5);

//            while (true)
//            {
//                AnsiConsole.Clear();
//                var option = AnsiConsole.Prompt(
//                    new SelectionPrompt<string>()
//                        .Title("Välj ett alternativ:")
//                        .AddChoices("Parkera fordon", "Ta bort fordon", "Visa beläggning", "Avsluta"));

//                switch (option)
//                {
//                    case "Parkera fordon":
//                        ParkVehicleMenu(garage);
//                        break;

//                    case "Ta bort fordon":
//                        UnparkVehicleMenu(garage);
//                        break;

//                    case "Visa beläggning":
//                        DisplayGarageOccupancy(garage);
//                        break;

//                    case "Avsluta":
//                        return;
//                }
//            }
//        }

//        static void ParkVehicleMenu(ParkingGarage garage)
//        {
//            var vehicleType = AnsiConsole.Prompt(
//                new SelectionPrompt<string>()
//                    .Title("Välj fordonstyp:")
//                    .AddChoices("Bil", "MC", "Buss", "Cykel"));

//            string licensePlate = AnsiConsole.Ask<string>("Ange registreringsnummer:");

//            Vehicle vehicle = vehicleType switch
//            {
//                "Bil" => new Car { LicensePlate = licensePlate, CheckInTime = DateTime.Now },
//                "MC" => new MC { LicensePlate = licensePlate, CheckInTime = DateTime.Now },
//                "Buss" => new Bus { LicensePlate = licensePlate, CheckInTime = DateTime.Now },
//                "Cykel" => new Bicycle { LicensePlate = licensePlate, CheckInTime = DateTime.Now },
//                _ => null
//            };

//            if (garage.ParkVehicle(vehicle))
//                AnsiConsole.MarkupLine("[green]Fordonet parkerades![/]");
//            else
//                AnsiConsole.MarkupLine("[red]Inga lediga platser för detta fordon.[/]");
//            Console.ReadKey();
//        }

//        static void UnparkVehicleMenu(ParkingGarage garage)
//        {
//            string licensePlate = AnsiConsole.Ask<string>("Ange registreringsnummer för att ta bort:");

//            garage.UnparkVehicle(licensePlate);
//            AnsiConsole.MarkupLine("[green]Fordonet togs bort från P-huset.[/]");
//            Console.ReadKey();
//        }

//        static void DisplayGarageOccupancy(ParkingGarage garage)
//        {
//            var table = new Table();
//            table.AddColumn("P-plats");
//            table.AddColumn("Fordon");

//            foreach (var spot in garage.ParkingSpots)
//            {
//                var vehicles = string.Join(", ", spot.ParkedVehicles.Select(v => $"{v.Type} ({v.LicensePlate})"));
//                table.AddRow($"P-plats {spot.SpotId}", vehicles.Length > 0 ? vehicles : "Ledig");
//            }

//            AnsiConsole.Write(table);
//            Console.ReadKey();
//        }
//    }
//}
