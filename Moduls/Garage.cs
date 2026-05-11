using GarageV1.Enums;
using System;
using System.Collections;
using System.Text;

namespace GarageV1.Moduls;

public class Garage
{
    private readonly Vehicle[] parkedVehicles;
    private int parkedVehicleCount;
    public Garage(int capacity)
    {
        Capacity = capacity;
        parkedVehicles = new Vehicle[capacity];
        this.parkedVehicleCount = 0;
    }

    public int Capacity { get; }

    public bool IsEmpty => parkedVehicleCount == 0;

    public AddVehicleResult Add(Vehicle vehicle)
    {
        if (parkedVehicleCount >= Capacity)
        {
            return AddVehicleResult.GarageFull;
        }

        if (PlateNumberExists(vehicle.NumberPlate))
        {

            return AddVehicleResult.DuplicatePlateNumber;
        }
            

        parkedVehicles[parkedVehicleCount] = vehicle;
        parkedVehicleCount++;

        return AddVehicleResult.Success;
    }

    public int Populate()
    {
        Vehicle[] vehicles =
        [
            new Car("ABC123", "Red", 4, FuelType.Gasoline),
            new Car("abc321", "Green", 4, FuelType.Diesel),
            new MotorCycle("MC123", "Black", 2, 600),
            new Bus("bUs123", "Blue", 6, 45),
            new Boat("BoA123", "White", 0, 8),
            new AirPlane("air123", "Silver", 3, 2)
        ];

        int addedVehicles = 0;

        foreach (Vehicle vehicle in vehicles)
        {
            AddVehicleResult result = Add(vehicle);

            if (result == AddVehicleResult.Success)
            {
                addedVehicles++;
            }
        }

        return addedVehicles;
    }

    public Vehicle[] GetParkedVehicles()
    {
        Vehicle[] result = new Vehicle[parkedVehicleCount];

        for (int index = 0; index < parkedVehicleCount; index++)
        {
            result[index] = parkedVehicles[index];
        }

        return result;
    }

    public Hashtable GetParkedVehicleTypeCounts()
    {
        Hashtable vehicleTypeCounts = new Hashtable();

        for (int index = 0; index < parkedVehicleCount; index++)
        {
            Vehicle? parkedVehicle = parkedVehicles[index];

            if (parkedVehicle is null)
            {
                continue;
            }

            string vehicleType = parkedVehicle.GetType().Name;

            if (vehicleTypeCounts.ContainsKey(vehicleType))
            {
                vehicleTypeCounts[vehicleType] = (int)vehicleTypeCounts[vehicleType]! + 1;
            }
            else
            {
                vehicleTypeCounts.Add(vehicleType, 1);
            }
        }

        return vehicleTypeCounts;
    }

    private int FindIndexByPlateNumber(string? numberPlate)
    {
        if (string.IsNullOrWhiteSpace(numberPlate))
        {
            return -1;
        }

        for (int index = 0; index < parkedVehicleCount; index++)
        {
            Vehicle? parkedVehicle = parkedVehicles[index];

            if (
                parkedVehicle is not null &&
                string.Equals(
                    parkedVehicle.NumberPlate,
                    numberPlate,
                    StringComparison.OrdinalIgnoreCase
                )
            )
            {
                return index;
            }
        }

        return -1;
    }

    private bool PlateNumberExists(string numberPlate)
    {
        return FindIndexByPlateNumber(numberPlate) != -1;
    }

    public Vehicle? FindByPlateNumber(string? numberPlate)
    {
        int vehicleIndex = FindIndexByPlateNumber(numberPlate);

        if (vehicleIndex == -1)
        {
            return null;
        }

        return parkedVehicles[vehicleIndex];
    }

    public bool RemoveByPlateNumber(string? numberPlate)
    {
        int vehicleIndex = FindIndexByPlateNumber(numberPlate);

        if (vehicleIndex == -1)
        {
            return false;
        }

        for (int moveIndex = vehicleIndex; moveIndex < parkedVehicleCount - 1; moveIndex++)
        {
            parkedVehicles[moveIndex] = parkedVehicles[moveIndex + 1];
        }

        parkedVehicles[parkedVehicleCount - 1] = null;
        parkedVehicleCount--;

        return true;
    }

    public Vehicle[] SearchVehicles(string? color, int? numberOfWheels, Type? vehicleType)
    {
        Vehicle?[] matches = new Vehicle?[parkedVehicleCount];
        int matchCount = 0;

        for (int index = 0; index < parkedVehicleCount; index++)
        {
            Vehicle? vehicle = parkedVehicles[index];

            if (vehicle is null)
            {
                continue;
            }

            if (
                !string.IsNullOrWhiteSpace(color) &&
                !string.Equals(vehicle.Color, color.Trim(), StringComparison.OrdinalIgnoreCase)
            )
            {
                continue;
            }

            if (numberOfWheels.HasValue && vehicle.NumberOfWheels != numberOfWheels.Value)
            {
                continue;
            }

            if (vehicleType is not null && vehicle.GetType() != vehicleType)
            {
                continue;
            }

            matches[matchCount] = vehicle;
            matchCount++;
        }

        Vehicle[] result = new Vehicle[matchCount];

        for (int index = 0; index < matchCount; index++)
        {
            result[index] = matches[index]!;
        }

        return result;
    }
}
