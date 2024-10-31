using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using Prauge_Parking_V2.Parking;
using Prauge_Parking_V2.VehicleTypes;


namespace Prauge_Parking_V2.DataAccess;

public class carInfo : Vehicle
{
    // Implementerar egenskapen Size
    //public override int Size => Vehicle;

    // Nya egenskaper specifika för carInfo
    public int VehicleSize { get; set; }

    // Konstruktor för carInfo som anropar basklassen Vehicle
    public carInfo(string LicensePlate, string vehicleType, int vehicleSize)
        : base(LicensePlate, vehicleType) // Skickar vidare parametrarna till basklassen
    {
        VehicleSize = vehicleSize;
    }
}

public class Readjson // Skapar, sparar och läser av carInfo-objekt som JSON-fil.
{
    private readonly string filePath;

    public Readjson()
    {
        // Spara filen i Dokument-mappen
        filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "carInfo.json");
    }

    public void SparaData()
    {
        // Skapa ett carInfo-objekt
        carInfo car = new carInfo("ABC123", "Sedan", 2);

        // Konvertera objektet till JSON-sträng
        string jsonString = JsonSerializer.Serialize(car);

        // Skriv JSON-strängen till en fil
        File.WriteAllText(filePath, jsonString);
        Console.WriteLine("Data sparad till JSON-fil.");
    }

    public void LaserData()
    {
        // Läs JSON-filen och deserialisera till ett carInfo-objekt
        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            carInfo car = JsonSerializer.Deserialize<carInfo>(jsonString);

            Console.WriteLine($"Registreringsnummer: {car.LicensePlate}");
            Console.WriteLine($"Fordonstyp: {car.Type}");
            Console.WriteLine($"Storlek: {car.VehicleSize}");

            // Öppnar filen i standardprogrammet
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
        else
        {
            Console.WriteLine("JSON-filen kunde inte hittas.");
        }
    }
}