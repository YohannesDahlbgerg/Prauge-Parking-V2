using Prauge_Parking_V2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Prauge_Parking_V2.DataAccess
{
    public class Config
    {
        public string AppName { get; set; }
        public string Version { get; set; }
        public Settings Settings { get; set; }
    }

    public class Settings
    {
        public int MaxRetries { get; set; }
        public bool EnableLogging { get; set; }
        public string LogLevel { get; set; }
    }

}

public class ProgramA
{
    public static void Main(string[] args)
    {
        string filePath = "config.json"; // Ange sökvägen till JSON-filen

        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            Config config = JsonSerializer.Deserialize<Config>(jsonString);

            Console.WriteLine($"AppName: {config.AppName}");
            Console.WriteLine($"Version: {config.Version}");
            Console.WriteLine($"MaxRetries: {config.Settings.MaxRetries}");
            Console.WriteLine($"EnableLogging: {config.Settings.EnableLogging}");
            Console.WriteLine($"LogLevel: {config.Settings.LogLevel}");
        }
        else
        {
            Console.WriteLine("Konfigurationsfilen kunde inte hittas.");
        }
    }
}


