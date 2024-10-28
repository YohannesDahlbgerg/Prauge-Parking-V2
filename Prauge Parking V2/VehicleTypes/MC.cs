using Prauge_Parking_V2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Prauge_Parking_V2.VehicleTypes;

public class MC : Vehicle
{
    public new string vehicleType { get; private set; } = "MC";

    public override int Size { get => 2; }

    public MC(string regNumber, int Size) : base(regNumber, "MC")
    {
        Console.WriteLine($"{vehicleType}#{regNumber}:{Size}");
    }

    static void MCs(string regNumber, int Size)
    {
        var car = new MC(regNumber, Size);
    }
}

