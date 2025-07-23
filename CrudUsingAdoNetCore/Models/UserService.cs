
using System.Reflection;
using Microsoft.Data.SqlClient;

namespace CrudUsingAdoNetCore.Models
{
    public class UserService : IUserService
    {
        private readonly string _connectionString;
       

        private readonly IDatabaseService _dbService;

        public UserService(IConfiguration config, IDatabaseService dbService)
        {
            _connectionString = config.GetConnectionString("B25ADONETCOREDB");
            _dbService = dbService;
        }

        public bool Create(Users model)
        {
            #region old code

            //using (SqlConnection con = new SqlConnection(_connectionString))
            //{
            //    string query =
            //    $"insert into users values ('{model.Name}', '{model.Email}', {model.Age}," +
            //    $"'{model.DateOfBirth}', '{DateTime.Now}', null, null)";
            //    SqlCommand cmd = new SqlCommand(query, con);
            //    con.Open();

            //    int rows = cmd.ExecuteNonQuery();

            //    return rows > 0;

            //    string query =
            //    $"insert into users values ('{model.Name}', '{model.Email}', {model.Age}," +
            //    $"'{model.DateOfBirth}', '{DateTime.Now}', null, null)";

            #endregion old code

            using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query =
               $"insert into users values (@Name, @Email, @Age," +
               $"@DateOfBirth, @AddedDate, @ModifiedDate, @DeletedDate)";


                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter(){ParameterName = "@Name", Value = model.Name},
                    new SqlParameter(){ParameterName = "@Email", Value = model.Email},
                    new SqlParameter(){ParameterName = "@Age", Value = model.Age},
                    new SqlParameter(){ParameterName = "@DateOfBirth", Value = model.DateOfBirth},
                    new SqlParameter(){ParameterName = "@AddedDate", Value = model.AddedDate},
                    new SqlParameter(){ParameterName = "@ModifiedDate", Value = DBNull.Value},
                    new SqlParameter(){ParameterName = "@DeletedDate", Value = DBNull.Value},


                };
                int rows = _dbService.ExecuteNonQuery(query, parameters);

                return rows > 0;

            }
        }

        public bool Delete(int id)
        {
            #region old code
            //using (SqlConnection con = new SqlConnection(_connectionString))
            //{
            //    string query = $"update Users set DeletedDate = '{DateTime.Now}' " +
            //        $"where Id = {id}";
            //    SqlCommand cmd = new SqlCommand(query, con);

            //    con.Open();

            //    int rows = cmd.ExecuteNonQuery();

            //    return rows > 0;
            //}

            #endregion old code

            string query = $"update Users set DeletedDate = @DeletedDate " +
                              $"where Id = @Id";

           
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(){ ParameterName = "@Id", Value = id},
                new SqlParameter(){ ParameterName = "@DeletedDate", Value = DateTime.Now}
            };
            int rows = _dbService.ExecuteNonQuery(query, parameters);

            return rows > 0;

        }

        public List<Users> GetAll()
        {
            #region old code
            //List<Users> users = new List<Users>();

            //using (SqlConnection con = new SqlConnection(_connectionString))
            //{

            //    string query = "select * from Users";

            //    SqlCommand cmd = new SqlCommand(query, con);

            //    con.Open();

            //    SqlDataReader reader = cmd.ExecuteReader();

            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            Users users1 = new Users()
            //            {

            //                Id = (int)reader["id"],
            //                Name = reader["Name"].ToString(),
            //                Email = reader["Email"].ToString(),
            //                Age = (reader["Age"] == DBNull.Value) ? null : (int?)reader["Age"],
            //                DateOfBirth = (reader["DateOfBirth"] == DBNull.Value) ? null : (DateTime?)reader["DateOfBirth"],
            //                AddedDate = (reader["AddedDate"] == DBNull.Value) ? null : (DateTime?)reader["AddedDate"],
            //                ModifiedDate = (reader["ModifiedDate"] == DBNull.Value) ? null : (DateTime?)reader["ModifiedDate"],
            //                DeletedDate = (reader["DaletedDate"] == DBNull.Value) ? null : (DateTime?)reader["DeletedDate"]

            //            };
            //        } 

            //    }

            #endregion old code

            List<Users> users = new List<Users>();

            string query = "select * from Users";
            users = _dbService.ExecuteReader<Users>(query, null);

            return users;               
            
        }

        public Users GetById(int id)
        {
            #region old code

            //Users user = new Users();

            //using (SqlConnection con = new SqlConnection(_connectionString))
            //{
            //    string query = $"select * from Users where id = {id}";
            //    SqlCommand cmd = new SqlCommand(query, con);

            //    con.Open();

            //    SqlDataReader reader = cmd.ExecuteReader();

            //    if (reader.Read())
            //    {
            //        while (reader.Read())
            //        {
            //            user = new Users()
            //            {
            //                Id = (int)reader["Id"],
            //                Name = reader["Name"].ToString(),
            //                Email = reader["Email"].ToString(),
            //                Age = (reader["Age"] == DBNull.Value) ? null : (int?)reader["Age"],
            //                DateOfBirth = (reader["DateOfBirth"] == DBNull.Value) ? null : (DateTime?)reader["DateOfBirth"],
            //                AddedDate = (reader["AddedDate"] == DBNull.Value) ? null : (DateTime?)reader["AddedDate"],
            //                ModifiedDate = (reader["ModifiedDate"] == DBNull.Value) ? null : (DateTime?)reader["ModifiedDate"],
            //                DeletedDate = (reader["DeletedDate"] == DBNull.Value) ? null : (DateTime?)reader["DeletedDate"]
            //            };
            //            break;
            //        }
            //    }
            //    return user;
            //}

            #endregion old code

            string query = "select * from Users where Id = @id";

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter(){ ParameterName = "@id", Value = id}
            };

            List<Users> users = _dbService.ExecuteReader<Users>(query, parameter);

            return users?.FirstOrDefault();
        }

        public bool Update( Users user)
        {
            #region old code

            //using (SqlConnection con = new SqlConnection(_connectionString))
            //{
            //    string query = $"update Users set Name = {user.Name},Email = {user.Email}," +
            //        $"Age = {user.Age},DateOfBirth = '{user.DateOfBirth}'," +
            //        $" ModifiedDate = '{DateTime.Now}' where id = {user.Id}";

            //    SqlCommand cmd = new SqlCommand(query, con);
            //    con.Open();

            //    int rows = cmd.ExecuteNonQuery();

            //    return rows > 0;
            //}

            #endregion old code

            string query = $"update Users set Name = @Name, Email = @Email," +
                   $"Age = @Age, DateOfBirth = @DateOfBirth," +
                   $" ModifiedDate = @ModifiedDate where id = @Id";


            SqlParameter[] parameters = new SqlParameter[]
           {
                    new SqlParameter(){ParameterName = "@Id", Value = user.Id},
                    new SqlParameter(){ParameterName = "@Name", Value = user.Name},
                    new SqlParameter(){ParameterName = "@Email", Value = user.Email},
                    new SqlParameter(){ParameterName = "@Age", Value = user.Age},
                    new SqlParameter(){ParameterName = "@DateOfBirth", Value = user.DateOfBirth},
                    new SqlParameter(){ParameterName = "@ModifiedDate", Value = DateTime.Now}

           };
            int rows = _dbService.ExecuteNonQuery(query, parameters);

            return rows > 0;


        }

        
    }
}
