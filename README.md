# GarageV1

GarageV1 is a C# console application built as a programming exercise for practicing object-oriented programming, inheritance, arrays, enums, input handling, and basic unit testing.

The application simulates a simple garage where different vehicle types can be parked, listed, searched, and removed.

## Features

- Create a garage with a fixed capacity
- Park vehicles in the garage
- Remove vehicles by plate number
- Find vehicles by plate number
- List all parked vehicles
- List vehicle types and count how many of each type are parked
- Populate the garage with predefined demo vehicles
- Search vehicles by filters:
  - Vehicle type
  - Color
  - Number of wheels
- Case-insensitive plate number matching
- Duplicate plate number protection
- Basic console input validation

## Vehicle types

The application supports the following vehicle types:

- Car
- Motorcycle
- Bus
- Boat
- Airplane

All vehicles share common properties:

- Plate number
- Color
- Number of wheels

Each vehicle type also has its own specific property, such as fuel type, cylinder volume, number of seats, length, or number of engines.

## Technologies

- C#
- .NET
- Console application
- Object-oriented programming
- Arrays
- Enums
- xUnit for unit testing

## Project structure

```text
GarageV1/
├── Enums/
│   └── Application enums
├── Moduls/
│   └── Garage and vehicle classes
├── UI/
│   └── Console menu and input handling
├── Program.cs
├── GarageV1.csproj
└── GarageV1.slnx
```

## Main concepts practiced

This project focuses on:

- Classes and objects
- Constructors
- Inheritance
- Method design
- Encapsulation
- Arrays instead of generic collections for garage storage
- Enum-based menu choices
- Case-insensitive string comparison
- Console input validation
- Basic unit testing with xUnit

## How to run

Clone the repository:

```bash
git clone https://github.com/wach78/lexicon-Garage1.0.git
```

Go into the project folder:

```bash
cd lexicon-Garage1.0
```

Run the application:

```bash
dotnet run
```

## How to use

When the application starts, use the main menu to:

1. Create a garage
2. Populate the garage with demo vehicles
3. List parked vehicles
4. List vehicle types and counts
5. Park a new vehicle
6. Remove a vehicle
7. Find a vehicle by plate number
8. Search vehicles by filters
9. Exit the application

A garage must be created before vehicles can be added, listed, removed, or searched.

## Unit tests

The project is tested with xUnit.

The tests cover:

- Garage creation
- Adding vehicles
- Duplicate plate number handling
- Full garage handling
- Finding vehicles by plate number
- Removing vehicles
- Listing parked vehicles
- Counting vehicle types

Run tests with:

```bash
dotnet test
```

## Notes

This project is a learning exercise. The current focus is correctness, object-oriented structure, array handling, and clear console interaction.
