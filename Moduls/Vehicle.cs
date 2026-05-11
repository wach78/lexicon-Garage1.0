using System;
using System.Collections.Generic;
using System.Text;

namespace GarageV1.Moduls
{
    public class Vehicle
    {

        public Vehicle(string numberPlate, string color, int numberOfWheels)
        {
            NumberPlate = numberPlate; 
            Color = color;
            NumberOfWheels = numberOfWheels;
        }

        public string NumberPlate { get;}
        public string Color { get;}
        public int NumberOfWheels { get;}

        public override string ToString()
        {
            return $"Number plate: {NumberPlate} color: {Color} Number of wheels: {NumberOfWheels}";
        }

    }
}
