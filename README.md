# 24-Hour Code Challenge

## Overview

This project involves creating a RESTful API using **.NET 8.0** for importing, storing, and retrieving sales data from CSV files. The API is documented with Swagger.

## Prerequisites

- **.NET 8.0 SDK**: Ensure you have .NET 8.0 installed on your development machine.
- **MSSQL Server**: Have an MSSQL Server instance available for your database.

## Setup Instructions

1. **Clone the Project**

    Clone the repository to your local machine

2. **Database Setup**

    Open the Package Manager Console in Visual Studio and run the following commands to set up your database:

    ```bash
    dotnet ef migrations InitializeDatabase
    dotnet ef database update
    ```

3. **Configure Connection String**

    After running the migrations, configure your database connection string in `appsettings.json`. Ensure it points to your MSSQL Server instance.

4. **Copy the Sample CSV Files**

    Copy the sample CSV files to your local machine

5. **Run the Application**

    Build and run the application:

    ```bash
    dotnet run
    ```

    Access the Swagger documentation by navigating to `http://localhost:<port>/swagger` in your browser.

## Guide on Importing Data from CSV Files

### Pizza

- **File**: `pizzas.csv`
- **Endpoint**: `api/Import/Pizza`

### Pizza Type

- **File**: `pizza_types.csv`
- **Endpoint**: `api/Import/PizzaType`

### Order Details

- **File**: `order_details.csv`
- **Endpoint**: `api/Import/OrderDetails`

### Orders

- **File**: `orders.csv`
- **Endpoint**: `api/Import/Order`

## Note

- Ensure that the files are uploaded to their respective endpoints to guarantee the successful import of data.
- Check the Swagger documentation for detailed information about the API endpoints and their usage.
