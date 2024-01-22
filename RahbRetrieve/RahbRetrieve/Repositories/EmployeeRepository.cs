using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

public class EmployeeRepository
{
    private readonly IConfiguration _configuration;

    public EmployeeRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public List<Employee> GetAllEmployees()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        using System.Data.IDbConnection dbConnection = new SqlConnection(connectionString);
        dbConnection.Open();

        return dbConnection.Query<Employee>("SELECT * FROM EmployeeData").ToList();
    }
}