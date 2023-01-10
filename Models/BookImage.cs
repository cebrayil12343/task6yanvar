namespace _5yanvardnm5.Models
{
    public class BookImage
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Image { get; set; }
        public bool? IsPoster { get; set; }
        public book Book { get; set; }
    }
}
