using Prauge_Parking_V2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

//namespace Prauge_Parking_V2.VehicleTypes;

//public class Car : Vehicle
//{
//    public new string vehicleType { get; private set; } = "CAR";

//    public override int Size { get =>4;  }

//    public Car(string regNumber, int size) : base(regNumber, "CAR")
//    {
//        Console.WriteLine($"{vehicleType}#{regNumber}:{Size}");
//    }

//    public static void Cars(string regNumber, int Size)
//    {
//        var car = new Car(regNumber, Size);
//    }
//}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prauge_Parking_V2.VehicleTypes;

namespace Prague_Parking_V2.VehicleTypes
{
    public class Car : Vehicle
    {

        public Car(string licensePlate, string type) : base(licensePlate, type)
        {

        }

        public int GetParkingFee(decimal hourlyRate)
        {
            TimeSpan parkedDuration = DateTime.Now - CheckInTime;
            int freeMinutes = 10;

            if (parkedDuration.TotalMinutes <= freeMinutes)
            {
                return 0;
            }

            var parkedTime = (parkedDuration.TotalMinutes - freeMinutes) / 60;
            var parkedPrice = (decimal)parkedTime * hourlyRate;

            return (int)parkedPrice;

        }
    }
}