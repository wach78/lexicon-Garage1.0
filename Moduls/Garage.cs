using System;
using System.Collections.Generic;
using System.Text;

namespace GarageV1.Moduls
{
    internal class Garage
    {
        private readonly Vehicle[] parkedVehicles;
        public Garage(int capacity)
        {
            Capacity = capacity;
            parkedVehicles = new Vehicle[capacity];
        }

        public int Capacity { get; }
    }
}
