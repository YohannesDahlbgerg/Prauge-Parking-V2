using Prauge_Parking_V2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Prauge_Parking_V2.VehicleTypes;

internal class Car : Vehicle
{
    public new string vehicleType { get; private set; } = "CAR";

    public override int Size { get =>4;  }

    public Car(string regNumber, int size) : base(regNumber, "CAR")
    {
        Console.WriteLine($"{vehicleType}#{regNumber}:{Size}");
    }

    static void Cars(string regNumber, int Size)
    {
        var car = new Car(regNumber, Size);
    }
}

