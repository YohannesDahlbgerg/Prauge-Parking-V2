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

    public int VehicleSize { get; set; }

    
    public carInfo(string LicensePlate, string vehicleType, int vehicleSize)
        : base(LicensePlate, vehicleType)
    {
        VehicleSize = vehicleSize;
    }
}

public class Readjson
{
    public readonly string filePath;

    public Readjson()
    {
        
        filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "carInfo.json");
    }

    public void SparaData()
    {
        
        carInfo car = new carInfo(Type, LicensePlate, vehicleSize);

        
        string jsonString = JsonSerializer.Serialize(car);

        
        File.WriteAllText(filePath, jsonString);
        Console.WriteLine("Data sparad till JSON-fil.");
    }

    public void LaserData()
    {
        
        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            carInfo car = JsonSerializer.Deserialize<carInfo>(jsonString);

            Console.WriteLine($"Registreringsnummer: {car.LicensePlate}");
            Console.WriteLine($"Fordonstyp: {car.Type}");
            Console.WriteLine($"Storlek: {car.VehicleSize}");

            
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
        else
        {
            Console.WriteLine("JSON-filen kunde inte hittas.");
        }
    }
}