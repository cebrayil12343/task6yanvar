using _5yanvardnm5.Models;

namespace _5yanvardnm5.ViewModels
{
    public class BookDetailViewModel
    {
        public book book { get; set; }
        public List<book> RelatedBooks { get; set; }
    }
}
