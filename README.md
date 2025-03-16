# Order Processing App (qualification app)
# Order Processing Application

A console-based application built with .NET to manage order processing with status tracking and business rules, developed as part of a recruitment task. This project demonstrates object-oriented programming (OOP), clean code practices, and CI/CD integration.

## Features
- **Order Management**: Create and process orders with user-defined details.
- **Statuses**: Supports 6 order statuses: New, In Warehouse, In Shipping, Returned to Client, Error, Closed.
- **Operations**:
  1. Create a new order with custom input.
  2. Send an order to the warehouse.
  3. Send an order to shipping.
  4. View all orders.
  5. Exit the application.
- **Business Rules**:
  - Orders ≥ 2500 with cash-on-delivery are returned to the client when sent to the warehouse.
  - Orders without a delivery address result in an error status.
  - Orders in shipping transition to "Closed" after a 5-second delay.
- **CI/CD**: Automated build, test, and artifact publishing via GitHub Actions.

## Project Structure
OrderProcessingApp/
├── OrderProcessingApp/         # Main console application
│   ├── Order.cs
│   ├── OrderService.cs
│   ├── Program.cs
│   └── *.cs (Enums)
├── OrderProcessingApp.Tests/   # Unit tests
│   ├── OrderTests.cs
├── OrderProcessingApp.sln      # Solution file
├── .github/
│   └── workflows/
│       └── quick-ci.yml        # CI/CD pipeline
└── README.md                   # This file

## Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 or compatible)
- Git (for cloning the repository)
- Optional: GitHub account to view CI/CD runs

## Setup Instructions
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/yourusername/OrderProcessingApp.git
   cd OrderProcessingApp

## Running the Application
Start the console app:
    dotnet run --project OrderProcessingApp/OrderProcessingApp.csproj

## Running Tests
Execute unit tests:
    dotnet test OrderProcessingApp.sln