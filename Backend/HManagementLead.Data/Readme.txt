Se puede generar el DbContext y las clases asociadas mediante el siguiente comando:

dotnet ef dbcontext scaffold "Server=Servidor;Database=Base de datos;User Id=Usuario;Password=Contrase�a;" Microsoft.EntityFrameworkCore.SqlServer --project HManagementLead.Data -c ApplicationDbContext --schema dbo