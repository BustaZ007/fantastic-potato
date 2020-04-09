namespace FantasticPotato.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OrigLanguage { get; set; }
        public string Genre { get; set; }
        public AuthorModel Author { get; set; }
    }
}