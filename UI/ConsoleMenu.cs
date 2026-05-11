using GarageV1.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageV1.UI;

internal class ConsoleMenu
{
    public static void Menu()
    {
        Console.Write(
            $"""
            Welcome to the main menu.
            Enter a number to choose an option.

            {(int)MenuChoice.CreateGarage} = Create garage
            {(int)MenuChoice.PopulateGarage} = Populate garage with vehicles
            {(int)MenuChoice.ListParkedVehicles} = List all parked vehicles
            {(int)MenuChoice.ListVehicleTypes} = List vehicle types and count
            {(int)MenuChoice.ParkVehicle} = Park a vehicle
            {(int)MenuChoice.RemoveVehicle} = Remove a vehicle
            {(int)MenuChoice.FindVehicleByPlateNumber} = Find vehicle by plate number
            {(int)MenuChoice.SearchVehicles} = Search vehicles
            {(int)MenuChoice.Exit} = Exit

            Your choice:
            """
        );
    }

    public static void VehicleTypeMenu()
    {
        Console.Write(
            $"""
            Choose vehicle type:
            {(int)VehicleTypeChoice.Car} = Car
            {(int)VehicleTypeChoice.Motorcycle} = Motorcycle
            {(int)VehicleTypeChoice.Bus} = Bus
            {(int)VehicleTypeChoice.Boat} = Boat
            {(int)VehicleTypeChoice.Airplane} = Airplane
            {(int)VehicleTypeChoice.Back} = Back to main menu

            Your choice:
            """
        );
    }

    public static void SearchVehicleTypeMenu()
    {
        Console.Write(
         $"""
        Search vehicles by filters.
        Choose vehicle type.

        {(int)SearchVehicleTypes.All} = All vehicle types
        {(int)SearchVehicleTypes.Car} = Car
        {(int)SearchVehicleTypes.Motorcycle} = Motorcycle
        {(int)SearchVehicleTypes.Bus} = Bus
        {(int)SearchVehicleTypes.Boat} = Boat
        {(int)SearchVehicleTypes.Airplane} = Airplane

        Your choice:
        """
        );
    }
}
