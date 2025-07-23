namespace CrudUsingAdoNetCore.Models
{
    public interface ICategoryService
    {
        List<Category> GetAll();

        Category GetById(int id);
        bool Create(Category category);
        bool Update(Category category);
        bool Delete(int id);
    }
}
