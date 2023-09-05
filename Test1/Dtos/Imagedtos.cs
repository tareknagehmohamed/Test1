using Test1.Models;

namespace Test1.Dtos
{
    public class Imagedtos
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? address { get; set; }
        public byte[]? newimage { get; set; }
        public string? imgpath { get; set; }
        public int categoryId { get; set; }
       // public Category? category { get; set; }
    }
}
