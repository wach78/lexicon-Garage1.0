using GarageV1.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageV1.Moduls
{
    public class Boat: Vehicle
    {
        public Boat(string numberPlate, string color, int numberOfWheels, int length)
        : base(numberPlate, color, numberOfWheels)
        {
            Length = length;
        }

        public int Length { get;}

        public override string ToString()
        {
            return $"{base.ToString()}, Length: {Length}";
        }
    }
}
