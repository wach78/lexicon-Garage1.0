using System;
using System.Collections.Generic;
using System.Text;

namespace GarageV1.Moduls;

internal class CommonVehicleData
{
    public CommonVehicleData(string numberPlate, string color, int numberOfWheels)
    {
        NumberPlate = numberPlate;
        Color = color;
        NumberOfWheels = numberOfWheels;
    }

    public string NumberPlate { get; }

    public string Color { get; }

    public int NumberOfWheels { get; }
}
