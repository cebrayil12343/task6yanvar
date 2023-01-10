using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _5yanvardnm5.Models
{
	public class Slider
	{
		public int Id { get; set; }
		[StringLength(maximumLength:25)]
		public string Title1 { get; set; }
        [StringLength(maximumLength: 25)]
        public string Title2 { get; set; }
        [StringLength(maximumLength: 200)]
        public string Desc { get; set; }
		public string ButonUrl { get; set; }
        [StringLength(maximumLength: 35)]
        public string ButonUrlText { get; set; }
        [StringLength(maximumLength:136)]
		public string? Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
