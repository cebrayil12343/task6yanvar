using System.ComponentModel.DataAnnotations;

namespace _5yanvardnm5.Models
{
    public class Author
    {
        public int Id { get; set; }
        [StringLength(maximumLength:35, ErrorMessage ="max length error") ]
        public string FullName { get; set; }
        public List<book> books { get; set; }
    }
}
