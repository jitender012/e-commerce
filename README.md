# E-Commerce Website

This is an E-commerce website developed using ASP.NET MVC 5. The project follows the Repository Pattern and incorporates various modern web development practices and technologies.

## Table of Contents
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Features
- User Authentication and Authorization using ASP.NET Identity
- Product Catalog with Search and Filtering
- Shopping Cart functionality
- Order Management
- Admin Dashboard for Product Management
- Responsive design using Bootstrap 5
- AJAX for dynamic content updates

## Technologies Used
- **ASP.NET MVC 5**: Framework for building web applications.
- **Entity Framework**: ORM for database operations.
- **ASP.NET Identity**: Authentication and authorization.
- **Repository Pattern**: For data access logic.
- **Unity**: Dependency Injection.
- **AutoMapper**: Mapping between models.
- **jQuery**: JavaScript library for DOM manipulation and AJAX requests.
- **Bootstrap 5**: CSS framework for responsive design.

## Getting Started

### Prerequisites
- Visual Studio 2019 or later
- .NET Framework 4.7.2 or later
- SQL Server (Express or any other edition)

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/e-commerce.git
    cd e-commerce
    ```

2. Open the solution in Visual Studio:
    ```sh
    e-commerce.sln
    ```

3. Restore NuGet packages:
    ```sh
    Update-Package -reinstall
    ```

4. Update the database connection string in `Web.config`:
    ```xml
    <connectionStrings>
        <add name="DefaultConnection" connectionString="your_connection_string" providerName="System.Data.SqlClient" />
    </connectionStrings>
    ```

5. Run the Entity Framework migrations to set up the database:
    ```sh
    Update-Database
    ```

6. Build and run the project.

## Usage

- **User Registration and Login**: Users can register and log in to their accounts.
- **Product Catalog**: Browse products, search by keyword, and filter by categories.
- **Shopping Cart**: Add products to the cart, update quantities, and proceed to checkout.
- **Admin Dashboard**: Admin users can manage products, categories, and view orders.

## Project Structure

- `Business Logic Project`:
  - Contains business logic and service classes.
- `Domain Model`:
  - Contains entity classes and data models.
- `Data Access Logic Project`:
  - Contains repository classes for data access.
- `eShop`:
  - Main web application project containing controllers, views, and configurations.

## Contributing
Contributions are welcome! Please follow these steps to contribute:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/YourFeature`).
3. Commit your changes (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature/YourFeature`).
5. Open a pull request.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

