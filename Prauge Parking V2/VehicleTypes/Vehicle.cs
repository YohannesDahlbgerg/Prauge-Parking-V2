using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prauge_Parking_V2.VehicleTypes;

public abstract class Vehicle
{
    // Egenskaper för fordonet
    public string RegNumber { get; set; }
    public int VehicleSize { get; set; }
    public string VehicleType { get; set; }

    public abstract int Size { get;}

    // Konstruktor för att sätta egenskaperna vid skapandet av ett objekt
    public Vehicle(string regNumber, string vehicleType)
    {
        RegNumber = regNumber;
        vehicleType = vehicleType;
        
        
    }

    // Metod för att visa fordonsinformation
    public void DisplayInfo() // Gör så det kommer upp i JSON fil !!
    {
        Console.WriteLine($"Regnummer: {RegNumber}");
        Console.WriteLine($"Storlek: {VehicleSize}");
        Console.WriteLine($"Fordonstyp: {VehicleType}");
    }
}

// Exempel på användning i din Main-metod
class ProgramV
{
    static void Main(string[] args)
    {
        Console.Write("Ange registreringsnummer: ");
        string regNumber = Console.ReadLine();

        Console.Write("Ange fordonstyp (CAR/MC): ");
        string vehicleType = Console.ReadLine().ToUpper();

        int vehicleSize;

        var veh = new Car(regNumber);


       
        

        if (vehicleType == "CAR")
        {
            vehicleSize = 4;
        }
        else if (vehicleType == "MC")
        {
            vehicleSize = 2;
        }
        else
        {
            Console.WriteLine("Ogiltig fordonstyp. Vänligen ange CAR eller MC.");
            return;
        }

        Vehicle vehicle = new(regNumber, vehicleSize, vehicleType);
        vehicle.DisplayInfo();
    }
}