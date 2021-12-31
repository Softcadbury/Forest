# Forest

## Description

Application and API to handle trees and nodes. Inspired from https://treelib.readthedocs.io/.

## Development

### How to start the application

- Go to /scripts and run the file `resetDatabase.ps1` (it will create the database "Forest" in your local SQL Server)
- Go to /src/Web/ClientApp and run the command `yarn install` (it will install required dependencies to build the front)
- Go to /src/Web and run the command `dotnet run` (build the back and start the applicaation on https://localhost:5001/)

### How to generate a migration

- Go to /src/Repository and run the command `dotnet ef migrations add MigrationName`