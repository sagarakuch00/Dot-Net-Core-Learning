using CrudUsingAdoNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace CrudUsingAdoNetCore.Controllers
{
    public class UsersController : Controller
    {
        private readonly string _connectionString;

        public UsersController(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("B25ADONETCOREDB");
        }

        [HttpGet]
        public IActionResult Index()
        {

            List<Users> users = new List<Users>();

           // string cs = "server=.\\SQLEXPRESS;database=ADONETDBCORE;integrated security=true;";

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
                        Users user = new Users()
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
                        users.Add(user);

                    }

                }
            }
            return View(users);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Users model)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = $"insert into users values ('{model.Name}', '{model.Email}', {model.Age}," +
                        $"'{model.DateOfBirth}', '{DateTime.Now}', null, null)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(model);
        }

        [HttpGet]

        public IActionResult Details(int? id)
        {
            Users user = new Users();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = $"select 8 from users where {id}";

                SqlCommand cmd = new SqlCommand (query, con);

                con.Open();
                
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user = new Users()
                        {
                            Id = (int)reader["id"],
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

            }
            return View(user);
        }
    }
}
