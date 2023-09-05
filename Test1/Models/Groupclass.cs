using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Test1.Models
{
    public class Groupclass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
     
        public string? Categoryname { get; set; }
        public int Count { get; set; }
        public int Sum { get; set; }
        public double Average { get; set; }
    }
}
