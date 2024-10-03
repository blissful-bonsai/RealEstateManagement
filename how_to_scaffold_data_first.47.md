# Scaffold command to create class models based on pre existing database:

## Necessary packages
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools

### Remember to create a ps script for this #
dotnet ef dbcontext scaffold "Server=localhost,1433;Database=RealEstateDb;User Id=sa;Password=EasyPass123;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer
