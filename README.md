# About
Sample project to explore Blazor capabilities

## Stack
 - .NET
 - C#
 - MSSQL
 - Blazor WebAssembly App

# Build
After cloning project from repository:
 - Rebuild project
 - In Package Manager Console run: PM> update-database
 - Run SalesOrderDataWebApp.Server

Important>
Project is configured to be run on MSSQL database, Server=localhost. 
In case your server is different:
 - Change server name in ConnectionStrings (SalesOrderDataWebApp.Server => appsettings.json file)
 - Delete Migrations folder (SalesOrderDataWebApp.Server => Migrations)
 - In Package Manager Console run: PM> add-migration Init
 - Change ReferentialAction in Windows and Elements constraints to - onDelete: ReferentialAction.NoAction
 - In Package Manager Console run: PM> update-database
