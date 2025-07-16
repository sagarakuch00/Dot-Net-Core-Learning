using CrudUsingAdoNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace CrudUsingAdoNetCore.Controllers
{
    public class UsersController : Controller
    {
        private readonly string _connectionString;
        private readonly IUserService _userService;

        public UsersController(IConfiguration config, IUserService userSerVice)
        {
            _connectionString = config.GetConnectionString("B25ADONETCOREDB");
            _userService = userSerVice;
        }

        [HttpGet]
        public IActionResult Index()
        {

            //List<Users> users = new List<Users>();

           // string cs = "server=.\\SQLEXPRESS;database=ADONETDBCORE;integrated security=true;";

            var users = _userService.GetAll();
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
                if (_userService.Create(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpGet]

        public IActionResult Details(int? id)
        {
            Users user = _userService.GetById(id ?? 0);
            return View(user);
        }

        private Users  GetUserById(int id)
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
                            Id = (int)reader["id"],
                            Name = reader["name"].ToString(),
                            Email = reader["Email"].ToString(),
                            Age = (int)reader["reader"],
                            DateOfBirth = (reader["DateOfBirth"] == DBNull.Value) ? null : (DateTime?)(reader["DateOfBirth"]),
                            AddedDate = (reader["AddedDate"] == DBNull.Value) ? null : (DateTime?)(reader["AddedDate"]),
                            ModifiedDate = (reader["ModifiedDate"] == DBNull.Value) ? null : (DateTime?)(reader["ModifiedDate"]),
                            DeletedDate = (reader["DeletedDate"] == DBNull.Value) ? null : (DateTime?)(reader["DeletedDate"])
                         
                        };
                        break;
                    }
                }
                return user;

            }
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Users user = GetUserById(id ?? 0);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(Users user)
        {
            if (ModelState.IsValid)
            {
                if (_userService.Update(user))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Users user = GetUserById(id ?? 0);
            return View(user);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            if (_userService.Delete(Id ?? 0))
            {
                return RedirectToAction("Index");
            }

            Users user = GetUserById(Id ?? 0);
             return View(user);
        }


    }
}
