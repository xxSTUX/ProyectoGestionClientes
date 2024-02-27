Se puede generar el DbContext y las clases asociadas mediante el siguiente comando:

dotnet ef dbcontext scaffold "Server=HL-5CD9271V3S\SQLEXPRESS;Database=GestionClientes_DB;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer --project HManagementLead.Data -c ApplicationDbContext --schema dbo