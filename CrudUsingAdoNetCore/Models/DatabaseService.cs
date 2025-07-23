using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Reflection;

namespace CrudUsingAdoNetCore.Models
{
    public class DatabaseService : IDatabaseService
    {
        
        private readonly string _connectionString;

        public DatabaseService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("B25ADONETCOREDB");
           
        }
        public int ExecuteNonQuery(string command, SqlParameter[] parameters, CommandType commandType = CommandType.Text)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(command, con);

                cmd.CommandType = commandType;

                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public List<T> ExecuteReader<T>(string command, SqlParameter[] parameters, CommandType commandType = CommandType.Text) where T : new()
        {
            var resultList = new List<T>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(command, con);

                cmd.CommandType = commandType;

                if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                while (reader.Read())
                {
                    T obj = new();

                    foreach (var prop in props)
                    {
                        if (reader[prop.Name] is DBNull) 
                        continue;
                        
                        var val = reader[prop.Name];
                        prop.SetValue(obj, val);
                    }
                    resultList.Add(obj);
                }
            }
            return resultList;
        }
    }
}
