using System;
using System.Collections.Generic;
using System.Text;

namespace GarageV1.Moduls
{
    internal class Bus: Vehicle
    {
        public Bus(string numberPlate, string color, int numberOfWheels, int numberOfSeats)
        : base(numberPlate, color, numberOfWheels)
        {
            NumberOfSeats = numberOfSeats;
        }

        public int NumberOfSeats { get;}
    }
}
