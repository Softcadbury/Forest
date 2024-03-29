# Forest

## Description

Application and API to handle trees and nodes. Inspired from https://treelib.readthedocs.io/.

## Screenshot

![alt tag](https://raw.githubusercontent.com/Softcadbury/Forest/master/assets/screenshot1.png)

![alt tag](https://raw.githubusercontent.com/Softcadbury/Forest/master/assets/screenshot2.png)

## Development

### How to start the application

-   Run the script `scripts/resetDatabase.ps1` (it will create or recreate the database "Forest" in your local SQL Server)
-   Go to /src/Client and run the command `yarn install` (it will install required dependencies to build the front)
-   Go to /src/Client and run the command `yarn dev` (it will start the front server)
-   Go to /src/Web and run the command `dotnet run` (it will start the back server at https://localhost:5001)

ℹ️ Those 3 last commands can be run using the script `scripts/startDevelopment.cmd`

### How to generate an Entity Framework migration

-   Go to /src/Repository and run the command `dotnet ef migrations add MigrationName`
