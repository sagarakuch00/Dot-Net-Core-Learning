namespace CrudUsingAdoNetCore.Models
{
    public interface IUserService
    {
        List<Users> GetAll();
        Users GetById(int id);
        bool Create(Users user);
        bool Update(Users user);
        bool Delete(int id);
    }
}
