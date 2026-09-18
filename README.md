# myMiniBank

A simple console-based banking application built in C# as a learning project for .NET and object-oriented programming (OOP).

## Purpose

This project is used to practice and demonstrate core C# and OOP concepts while building something that resembles a real-world domain (banking). It is designed to grow over time as I learn more about .NET, cloud, and software architecture.

## Current Features

- Create a bank account with an account number
- Deposit money
- Withdraw money
- View current balance
- Basic validation (e.g., no negative deposits, no overdrafts)

## Concepts Practiced

- Classes and objects
- Properties and encapsulation (`private set`)
- Methods, parameters, and arguments
- Value types vs reference types
- Basic exception handling
- Console I/O and formatting (e.g., currency with `€`)

## Tech Stack

- C#
- .NET console application

## Future Plans

This project is intended to evolve. Possible next steps:

- Add multiple account types (e.g., checking, savings)
- Add customers and transaction history
- Introduce interfaces and inheritance more extensively
- Refactor into a layered architecture
- Build an ASP.NET Core Web API on top of the domain
- Add a database with Entity Framework Core
- Deploy to Azure (App Service, Azure SQL, etc.)

## How to Run

1. Clone the repository:
   ```bash
   git clone <repo-url>
   cd myMiniBank
   ```

2. Run the project:
   ```bash
   dotnet run
   ```

## License

This is a learning project. No specific license is applied at this stage.
