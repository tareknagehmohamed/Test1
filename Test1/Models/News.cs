using System.ComponentModel.DataAnnotations;

namespace Test1.Models
{
    public class News
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter what you want Search about")]
        public string? Name { get; set; }
        public string? address { get; set; }
        public string? imgpath { get; set; }
        public int categoryId { get; set; }
        public Category? category { get; set; } 
    }
}
