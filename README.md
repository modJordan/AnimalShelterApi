# API TEMPLATE

#### By **[Jordan K]**

[BRIEF DESCRIPTION]

## Technologies Used

- .NET 5.0
- ASP.NET Core MVC
- Entity Framework Core
- Bootstrap
- C#
- HTML
- CSS

## Description

FULL DESCRIPTION

## Setup/Installation Requirements

- Ensure .NET SDK and runtime are installed on your machine.
- Clone this repository to your local machine.
- Navigate to the application's directory in your terminal.

<details>
<summary>Set up the required database:</summary>

1. Create an `appsettings.json` file in the application's root directory with the following content (adjust the connection string as needed based on your SQL setup):

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=treatdb;uid=YOUR_USERNAME;pwd=YOUR_PASSWORD;"
  }
}

```

2. Replace YOUR_USERNAME and YOUR_PASSWORD with your SQL server's username and password.
</details>
<br>

- Run the command ```dotnet restore``` to install necessary packages.
- Run the command ```dotnet build``` to compile the application.
- Run ```dotnet run``` to start the server and application.
- Visit ```localhost:5000``` in your browser to access Pierre's Sweet and Savory Treats.

## Pagination in API
The API Template has been enhanced to handle large volumes of records through pagination. This allows for efficient data retrieval and better user experience.

# Feature Description

    - The API supports query parameters for pagination, such as /object?page=2 to access different pages of book records.
    - This feature ensures performance optimization by loading only a subset of data per request.

## User Stories

   - User
   - Stories 
   - Here

## Objectives

  - CRUD functionality implemented for at least one class.
  - Create, Update, and Delete functionalities limited to authenticated users.
  - Secure handling of build files and sensitive information.

## Known Bugs

No known bugs at the moment.
Feedback and bug reports are always welcome.

### License

Feel free to reach out if you have any concerns, feedback, or wish to make contributions to the code. 

Copyright (c) 2023 [Jordan K]