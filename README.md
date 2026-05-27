Company Attendance API
A simple ASP.NET Core Web API for managing company employees and attendance records. The project demonstrates a layered backend structure using Entity Framework Core, SQL Server, AutoMapper, repository/service layers, and Swagger for API documentation.
> This repository is best presented as an educational or portfolio backend project, not as a production-ready attendance system.
Overview
The API provides basic CRUD operations for two main resources:
Employees: create, read, update, and delete employee records.
Attendance Records: register and manage employee entry and exit times.
The project is organized into separate layers for entities, data access, shared utilities, and the Web API.
Tech Stack
ASP.NET Core Web API
.NET 7
Entity Framework Core
SQL Server
AutoMapper
Swagger / OpenAPI
Repository Pattern
Service Layer Pattern
Project Structure
```text
Company_attendance-master/
├── CompanyatendanceApi/     # ASP.NET Core Web API layer
│   ├── Controllers/          # API controllers
│   ├── DTO/                  # Data Transfer Objects
│   ├── servece/              # Service layer implementation
│   ├── AutoMapper/           # AutoMapper profile
│   └── Program.cs            # Application configuration
├── data/                     # Database context, migrations, repository
│   ├── ApplicationDbContext.cs
│   ├── Migrations/
│   └── Repository/
├── Entity/                   # Domain entities
│   ├── Employee.cs
│   ├── Attendance.cs
│   └── BaseEntity.cs
├── common/                   # Shared extensions and utilities
└── Company attendance.sln    # Visual Studio solution file
```
Main Features
Employee CRUD operations
Attendance CRUD operations
SQL Server database integration
Entity Framework Core migrations
Generic repository implementation
Service layer for business logic separation
AutoMapper-based entity/DTO mapping
Swagger UI for testing API endpoints
Database Model
Employee
Field	Type	Description
Id	int	Primary key
FirstName	string	Employee first name
LastName	string	Employee last name
Attendances	collection	Related attendance records
Attendance
Field	Type	Description
Id	int	Primary key
EmployeeId	int	Foreign key to Employee
EntryTime	DateTime	Employee entry/check-in time
ExitTime	DateTime	Employee exit/check-out time
Employee	Employee	Related employee object
API Endpoints
Employee Endpoints
Method	Endpoint	Description
GET	`/api/Employee`	Get all employees
GET	`/api/Employee/{id}`	Get employee by ID
POST	`/api/Employee`	Create a new employee
PUT	`/api/Employee/{id}`	Update an employee
DELETE	`/api/Employee/{id}`	Delete an employee
Attendance Endpoints
Method	Endpoint	Description
GET	`/CompanyatendanceApi/Attendance`	Get all attendance records
GET	`/CompanyatendanceApi/Attendance/{id}`	Get attendance record by ID
POST	`/CompanyatendanceApi/Attendance`	Create a new attendance record
PUT	`/CompanyatendanceApi/Attendance/{id}`	Update an attendance record
DELETE	`/CompanyatendanceApi/Attendance/{id}`	Delete an attendance record
Getting Started
Prerequisites
Make sure the following tools are installed:
.NET SDK
SQL Server
Visual Studio, Rider, or VS Code
Entity Framework Core CLI tools
1. Clone the Repository
```bash
git clone https://github.com/your-username/Company_attendance.git
cd Company_attendance
```
2. Configure the Database Connection
The current project uses a local SQL Server connection string in `CompanyatendanceApi/Program.cs`.
Replace it with your own SQL Server configuration before running the project:
```csharp
oBuilder.UseSqlServer("Server=localhost;Database=Company_attendance;User Id=YOUR_USER;Password=YOUR_PASSWORD;encrypt=false;");
```
For a cleaner setup, move the connection string to `appsettings.json` or use user secrets instead of hard-coding credentials in source code.
3. Restore Dependencies
```bash
dotnet restore
```
4. Apply Database Migrations
```bash
dotnet ef database update --project data --startup-project CompanyatendanceApi
```
5. Run the API
```bash
dotnet run --project CompanyatendanceApi
```
Then open Swagger UI in the browser. Depending on the launch profile, it should be available at a local URL similar to:
```text
https://localhost:7141/swagger
http://localhost:5165/swagger
```
Example Request Body
Create Employee
```json
{
  "firstName": "John",
  "lastName": "Doe"
}
```
Create Attendance Record
```json
{
  "employeeId": 1,
  "entryTime": "2023-07-12T08:30:00",
  "exitTime": "2023-07-12T17:00:00"
}
