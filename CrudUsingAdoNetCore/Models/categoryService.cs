
using Microsoft.Data.SqlClient;
using NuGet.Protocol;
using System.Data;
using System.Linq;

namespace CrudUsingAdoNetCore.Models
{
    public class CategoryService : ICategoryService
    {
        private readonly IDatabaseService _dbService;

        public CategoryService(IDatabaseService dbService)
        {
            _dbService = dbService;
        }

        public bool Create(Category category)
        {
            string query = "UspCreateCategory";

            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter(){ParameterName = "@Name", Value = category.Name},
                    new SqlParameter(){ParameterName = "@Rating", Value = category.Rating}
            };
            int rows = _dbService.ExecuteNonQuery(query, parameters, CommandType.StoredProcedure);

            return rows > 0;
        }
        public bool Delete(int id)
        {
            string query = "uspDeleteCategory";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(){ ParameterName = "@Id", Value = id},
            };

            int rows = _dbService.ExecuteNonQuery(query, parameters,CommandType.StoredProcedure);

            return rows > 0;

        }

        public List<Category> GetAll()
        {
            return _dbService.ExecuteReader<Category>("uspGetAll", null);
        }

        public Category GetById(int id)
        {
            string query = "uspGetCategoryByid";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(){ ParameterName = "@Id", Value= id}
            };

            Category category = _dbService.ExecuteReader<Category>(query, parameters, CommandType.StoredProcedure)?.FirstOrDefault();
            
            return category;
        }

        public bool Update(Category category)
        {
            string query = "uspUpdateCategory";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(){ ParameterName = "@Id", Value = category.Id},
                new SqlParameter(){ ParameterName = "@Name", Value = category.Name},
                new SqlParameter(){ ParameterName = "@Rating", Value = category.Rating},
            };

            int rows = _dbService.ExecuteNonQuery(query, parameters, CommandType.StoredProcedure);

            return rows > 0;
        }
    }
}


