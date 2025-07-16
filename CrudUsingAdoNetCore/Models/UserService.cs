
using System.Reflection;
using Microsoft.Data.SqlClient;

namespace CrudUsingAdoNetCore.Models
{
    public class UserService : IUserService
    {
        private readonly string _connectionString;

        public UserService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("B25ADONETCOREDB");
        }

        public bool Create(Users model)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query =
                $"insert into users values ('{model.Name}', '{model.Email}', {model.Age}," +
                $"'{model.DateOfBirth}', '{DateTime.Now}', null, null)";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                int rows = cmd.ExecuteNonQuery();

                return rows > 0;
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = $"update Users set DeletedDate = '{DateTime.Now}' " +
                    $"where Id = {id}";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                return rows > 0;
            }
        }

        public List<Users> GetAll()
        {
            List<Users> users = new List<Users>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                string query = "select * from Users";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Users users1 = new Users()
                        {

                            Id = (int)reader["id"],
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            Age = (reader["Age"] == DBNull.Value) ? null : (int?)reader["Age"],
                            DateOfBirth = (reader["DateOfBirth"] == DBNull.Value) ? null : (DateTime?)reader["DateOfBirth"],
                            AddedDate = (reader["AddedDate"] == DBNull.Value) ? null : (DateTime?)reader["AddedDate"],
                            ModifiedDate = (reader["ModifiedDate"] == DBNull.Value) ? null : (DateTime?)reader["ModifiedDate"],
                            DeletedDate = (reader["DaletedDate"] == DBNull.Value) ? null : (DateTime?)reader["DeletedDate"]

                        };
                    } 
                    
                }
                return users;               
            }
        }

        public Users GetById(int id)
        {
            Users user = new Users();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = $"select * from Users where id = {id}";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    while (reader.Read())
                    {
                        user = new Users()
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            Age = (reader["Age"] == DBNull.Value) ? null : (int?)reader["Age"],
                            DateOfBirth = (reader["DateOfBirth"] == DBNull.Value) ? null : (DateTime?)reader["DateOfBirth"],
                            AddedDate = (reader["AddedDate"] == DBNull.Value) ? null : (DateTime?)reader["AddedDate"],
                            ModifiedDate = (reader["ModifiedDate"] == DBNull.Value) ? null : (DateTime?)reader["ModifiedDate"],
                            DeletedDate = (reader["DeletedDate"] == DBNull.Value) ? null : (DateTime?)reader["DeletedDate"]
                        };
                        break;
                    }
                }
                return user;
            }

        }

        public bool Update(Users user)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = $"update Users set Name = {user.Name},Email = {user.Email}," +
                    $"Age = {user.Age},DateOfBirth = '{user.DateOfBirth}'," +
                    $" ModifiedDate = '{DateTime.Now}' where id = {user.Id}";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                int rows = cmd.ExecuteNonQuery();

                return rows > 0;
            }
        }
    }
}
