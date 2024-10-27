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
    public Car(string regNumber, int vehicleSize) : base(regNumber, vehicleSize, "CAR")
    {
        Console.WriteLine($"{vehicleType}#{regNumber}:{vehicleSize}");
    }

    static void Cars(string regNumber, int vehicleSize)
    {
        var car = new Car(regNumber, vehicleSize);
    }
}

