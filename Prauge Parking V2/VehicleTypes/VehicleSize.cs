using Prauge_Parking_V2.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prauge_Parking_V2.VehicleTypes;


/////////////////////////////////////////////////////
///

public class ParkingS
{
    public int SpotId { get; set; }
    public int Capacity { get; set; }
    public List<Vehicle> ParkedVehicles { get; private set; } = new List<Vehicle>();

    public bool CanFit(Vehicle vehicle)
    {
        int totalSize = ParkedVehicles.Sum(v => v.Size) + vehicle.Size;
        return totalSize <= Capacity;
    }

    public bool ParkV(Vehicle vehicle)
    {
        if (CanFit(vehicle))
        {
            ParkedVehicles.Add(vehicle);
            return true;
        }
        return false;
    }

    public void RemoveVehicle(string licensePlate)
    {
        var vehicle = ParkedVehicles.FirstOrDefault(v => v.LicensePlate == licensePlate);
        if (vehicle != null)
            ParkedVehicles.Remove(vehicle);
    }
}

////////////////////////////////////////////////////////////
///

public class ParkingGarage
{
    public List<ParkingS> ParkingSpots { get; private set; }

    public ParkingGarage(int numberOfSpots, int defaultCapacity)
    {
        ParkingSpots = Enumerable.Range(1, numberOfSpots)
            .Select(i => new ParkingS { SpotId = i, Capacity = defaultCapacity })
            .ToList();
    }

    public bool ParkVehicle(Vehicle vehicle)
    {
        var spot = ParkingSpots.FirstOrDefault(s => s.CanFit(vehicle));
        if (spot != null)
        {
            return spot.ParkV(vehicle);
        }
        return false;
    }

    public void UnparkVehicle(string licensePlate)
    {
        foreach (var spot in ParkingSpots)
        {
            if (spot.ParkedVehicles.Any(v => v.LicensePlate == licensePlate))
            {
                spot.RemoveVehicle(licensePlate);
                break;
            }
        }
    }
}