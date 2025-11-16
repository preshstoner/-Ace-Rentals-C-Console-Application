This project is a simple, object-oriented console application written in C# to simulate a basic car rental system. It demonstrates core OOP principles such as Inheritance, Polymorphism (Method Overriding), and Method Overloading by defining different car types and calculating rental costs.

🚀 Getting Started

To run and collaborate on this project, you will need the following tools installed on your system:

Prerequisites

.NET SDK: Version 6.0 or higher is recommended.

IDE: Visual Studio or Apache NetBeans IDE 23 (as used during development) is ideal for C# development.

Running the Application

Clone the repository:

git clone https://github.com/preshstoner/-Ace-Rentals-C-Console-Application.git    
cd AceRentals


Restore dependencies: (If using the command line)

dotnet restore


Run the project:

dotnet run


Alternatively, open the project file (.csproj) in your IDE and click the Run or Start button.

🛠️ Project Structure and Key Concepts

The application is contained within the AceRentals namespace and is structured to showcase OOP features:

Class

Concept Demonstrated

Description

Car

Base Class

Contains common properties like Brand, Model, and DailyRate.

ElectricCar

Inheritance, Overloading

Inherits from Car. Includes BatteryCapacity and two overloaded CalculateRent methods (one with discount, one without).

SUV

Inheritance

Inherits from Car. Includes the specific property Has4WD.

LuxuryCar

Sealed Class

Demonstrates the sealed keyword, meaning this class cannot be inherited from. It's designed outside the main inheritance hierarchy.

Customer

Data Model

Holds customer information and rental duration.

Company

Static Class

Holds static, global information like CompanyName and Location.

🤝 Contribution Guidelines

We welcome contributions! The primary goal for collaboration is to transform this basic simulation into a more robust, extensible application. Please open an issue before submitting large pull requests.

Areas for Improvement

The current code is functional but contains several limitations that could be addressed by collaborators. Here are the top priorities:

1. Data Management and Persistence (Highest Priority)

Problem: All car and customer data is hardcoded and instantiated directly in the Main method.

Improvement: Introduce a RentalManager or Inventory class to manage a List<Car> collection. This class should handle adding, finding, and removing cars.

Next Level: Implement basic file I/O (using JSON or CSV) to persist the car inventory data across application runs, rather than recreating it every time.

2. Input Validation and Error Handling

Problem: The current code uses Convert.ToInt32(Console.ReadLine()) without any safety checks. Entering non-numeric text will crash the application (FormatException).

Improvement: Replace Convert.ToInt32 with int.TryParse() to safely handle user input for age, choice, and days. Implement a loop to prompt the user again if invalid input is detected.

3. Abstraction and Interface Use

Problem: The logic for calculating rent is currently implemented directly in the ElectricCar class, and the SUV calculation is in Main.

Improvement: Define an IRentable interface that includes a method like CalculateRentalCost(int days). All Car subclasses should implement this interface for consistent rent calculation logic.

4. Console User Experience (UX)

Problem: The console output uses hardcoded tabs and repeated Console.WriteLine calls for formatting.

Improvement: Utilize string interpolation ($"{...}") for cleaner output. Implement a separate utility function to handle formatted currency display (e.g., ensuring rates look like $100,000.00)
