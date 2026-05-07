using System;
using System.Collections.Generic;
using System.Text;

namespace GarageV1.Moduls
{
    internal class AirPlane: Vehicle
    {
        public AirPlane(string numberPlate, string color, int numberOfWheels, int numberOfEngines)
        : base(numberPlate, color, numberOfWheels)
        {
            NumberOfEngines = numberOfEngines;
        }
        public int NumberOfEngines { get;}
    }
}
