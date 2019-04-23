# TherapyDashboard
Multiple user types. Conduct CFARS, PPS-R, and PCL assessments. See reports based on those results.

# Installing on a new server
This web app uses .NET Core 2.2 (MVC) and SQL Server. To prep a server after program has been installed, migrate the database from the appropriate directory:
1. dotnet ef migrations add CreateIdentitySchema
2. dotnet ef database update
