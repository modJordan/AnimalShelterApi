# Animal Shelter API

#### By Jordan K

## Overview

This project involves creating an API for a local animal shelter. It focuses on listing available cats and dogs, aiding in their adoption process. Built with .NET 5.0 and ASP.NET Core, the API offers full CRUD functionality and includes pagination for efficient data management.  Pagination has been added to the Swagger page, allowing the viewer to choose how many responses and pages are seen at a time.

## Technologies Used


- .NET 6.0
- ASP.NET Core MVC
- Entity Framework Core
- Bootstrap
- C#
- HTML
- Swashbuckle
- CSS

## Description

The Animal Shelter API serves as a digital platform for the shelter, providing detailed information about the cats and dogs in need of homes. It supports adding new animals, updating their details, retrieving information, and removing listings as animals are adopted.


## Setup/Installation Requirements

If you have not already, install the dotnet-ef tool by running the following command in your terminal:

```dotnet tool install --global dotnet-ef --version 6.0.0```

Also, Install these tools for the implimentation of Pagination:

```dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.0
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.0```



- Clone this repository to your local machine.
- Navigate to the application's directory in your terminal.

<details>
<summary>Set up the required database:</summary>

1. Create an `appsettings.json` file in the application's root directory with the following content (adjust the connection string as needed based on your SQL setup):

```appsettings.json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=AnimalShelter;uid=UOUR_USERNAME;pwd=YOUR_PASSWORD;"
  }
}

```

2. Create an appsettings.Development.json file and insert the following code:
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Trace",
      "Microsoft.AspNetCore": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```

3. Replace YOUR_USERNAME and YOUR_PASSWORD with your SQL server's username and password.
</details>
<br>

- Run the command ```dotnet restore``` to install necessary packages.
- Run the command ```dotnet build``` to compile the application.
- Run ```dotnet run``` to start the server and application.
- Visit ```localhost:5000``` in your browser to access the Animal Shelter API.

### CRUD Operations

- Add (POST), View (GET), Update (PUT), and Remove (DELETE) pet records.

### Pagination

- Optimizes large data handling with page-wise access.
- Example: `/pets?page=2` retrieves the second page of pet listings.

### Documentation

- Detailed endpoint descriptions with usage examples.
- Clear guidelines on implementing pagination and other API features.


## User Stories

- As a user, I want to view all available pets.
- As a shelter manager, I need to add new pets to the database.
- As an adopter, I wish to retrieve details about specific pets.
- As an admin, I need to update or remove pet listings as needed.

## Objectives


- Complete CRUD functionality for pet records.
- Efficient data retrieval through pagination.
- Secure handling of sensitive data and configuration files.

## Known Bugs

No known bugs at the moment.
Feedback and bug reports are always welcome.

### License

Feel free to reach out if you have any concerns, feedback, or wish to make contributions to the code. 

Copyright (c) 2023 [Jordan K]