using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace Prauge_Parking_V2.DataAccess;
public class Grabb  // sätta så klassens egenskaper är regnummer och bil typ
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Snygghet { get; set; }
}

public class Readjson //skapa json fil och starta när programmet körs.
{
    public void Laser()
    {
        // Skapa ett objekt
        Grabb person = new Grabb
        {
            Name = "Yohannes",
            Age = 19,
            Snygghet = "10/10"
        };

        // Konvertera objektet till JSON-sträng
        string jsonString = JsonSerializer.Serialize(person);

        // Skriv JSON-strängen till en fil
        string filePath = "C:\\Users\\yohan\\source\\repos\\Prauge Parking V2\\Prauge Parking V2\\DataAccess\\person.json"; // Ange filens sökväg
        File.WriteAllText(filePath, jsonString);

        //Öppnar filen när programmet körs
        string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "person.json");

        if (File.Exists(filePath))
        {
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
        else
        {
            Console.WriteLine("Filen hittades inte!");
        }
    }
}
