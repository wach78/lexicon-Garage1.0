using GarageV1.Enums;
using Microsoft.VisualBasic;


namespace GarageV1.Moduls
{
    internal class Car: Vehicle
    {
        public Car(string numberPlate, string color, int numberOfWheels, FuelType fuelType)
        : base(numberPlate, color, numberOfWheels)
        {
            FuelType = fuelType;
        }


        public FuelType FuelType { get;}
    }
}
