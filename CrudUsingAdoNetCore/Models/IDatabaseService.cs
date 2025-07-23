using System.Data;
using Microsoft.Data.SqlClient;

namespace CrudUsingAdoNetCore.Models
{
    public interface IDatabaseService
    {
       
        int ExecuteNonQuery(string query, SqlParameter[] parameters, 
            CommandType commandType = CommandType.Text);
        List<T> ExecuteReader<T>(string command, SqlParameter[] parameters,
            CommandType commandType = CommandType.Text) where T : new();

    }
}
