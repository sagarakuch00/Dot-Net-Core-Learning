namespace CrudUsingAdoNetCore.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}


