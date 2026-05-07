using GarageV1.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageV1.Moduls
{
    internal class Garage
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

        public bool Add(Vehicle vehicle)
        {
            if (parkedVehicleCount >= Capacity)
            {
                return false;
            }

            parkedVehicles[parkedVehicleCount] = vehicle;
            parkedVehicleCount++;

            return true;
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
                if (Add(vehicle))
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
                result[index] = parkedVehicles[index]!;
            }

            return result;
        }
    }
}
