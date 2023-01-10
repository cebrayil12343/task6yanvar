using System.ComponentModel.DataAnnotations;

namespace _5yanvardnm5.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 30, ErrorMessage = "max length error")]
        public string Name { get; set; }
        public List<book> books { get; set; }
    }
}
