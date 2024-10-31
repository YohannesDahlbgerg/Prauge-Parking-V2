using Prauge_Parking_V2.VehicleTypes;
using System;

namespace Prauge_Parking_V2.VehicleTypes
{
    public enum VehicleType
    {
        Car,
        MC,
        Bus,
        Bicycle
    }

    public abstract class Vehicle
    {
        private string type;

        protected Vehicle(string licensePlate, string type)
        {
            LicensePlate = licensePlate;
            this.type = type;
        }

        public string LicensePlate { get; set; }
        public DateTime CheckInTime { get; set; }
        public VehicleType Type { get; set; }
        public int Size { get; set; } // 1 för cyklar, 2 för MC, 4 för bilar, 16 för bussar
    }

    public class Car : Vehicle
    {
        public Car(string licensePlate) : base(licensePlate, "Car") // Anropar bas-konstruktorn
        {
            Type = VehicleType.Car;
            Size = 4;
        }
    }

    public class MC : Vehicle
    {
        public MC(string licensePlate) : base(licensePlate, "MC") // Anropar bas-konstruktorn
        {
            Type = VehicleType.MC;
            Size = 2;
        }
    }

    public class Bus : Vehicle
    {
        public Bus(string licensePlate) : base(licensePlate, "Bus") // Anropar bas-konstruktorn
        {
            Type = VehicleType.Bus;
            Size = 16;
        }
    }

    public class Bicycle : Vehicle
    {
        public Bicycle(string licensePlate) : base(licensePlate, "Bicycle") // Anropar bas-konstruktorn
        {
            Type = VehicleType.Bicycle;
            Size = 1;
        }
    }
}
