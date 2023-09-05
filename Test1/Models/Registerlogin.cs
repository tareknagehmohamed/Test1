using System.ComponentModel.DataAnnotations;

namespace Test1.Models
{
    public class Registerlogin
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="ThIS field is Empty")]
        public string? username { get; set; }
        [Required(ErrorMessage = "ThIS field is Empty")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "ThIS field is Empty")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "ThIS field is Empty")]
        [EmailAddress]
        public string? Email { get; set; }
       
        public string? imgpath { get; set; }
    }
}
