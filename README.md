﻿# DanFlavPlayground


dotnet tool install --global dotnet-ef --version 7.0.16

dotnet ef migrations add 'yourName' dotnet ef database update

AnotherTest Project

dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FlatDanTestDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -o Models -c DatabaseContext --force
