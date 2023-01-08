using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _5yanvardnm5.Models
{
    public class book
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        [StringLength(maximumLength: 30, ErrorMessage = "max length error")]
        public string Name { get; set; }
        public double CostPrice { get; set; }
        public double SalePrice { get; set; }
        public double DiscountPrice { get; set; }
        [StringLength(maximumLength: 10, ErrorMessage = "max length error")]
        public string Code { get; set; }
        [StringLength(maximumLength: 300, ErrorMessage = "max length error")]
        public string Desc { get; set; }
        public bool IsAviable { get; set; }
        public Genre? Genre { get; set; }
        public Author? Author { get; set; }

    }
}
