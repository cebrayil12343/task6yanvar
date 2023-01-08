using System.ComponentModel.DataAnnotations;

namespace _5yanvardnm5.ViewModels
{
    public class BookViewModel
    {
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
    }
}
