using GarageV1.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageV1.Moduls
{
    internal class MotorCycle: Vehicle
    {
        public MotorCycle(string numberPlate, string color, int numberOfWheels, int cylinderVolume)
        : base(numberPlate, color, numberOfWheels)
        {
            CylinderVolume = cylinderVolume;
        }
        public int CylinderVolume { get;}
    }
}
