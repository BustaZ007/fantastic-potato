using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasticPotato.Models
{
    [Table("Books")]
    public class BookModel
    {
        public BookModel(int id, string name, string origLanguage, string genre, int authorId)
        {
            Id = id; 
            Name = name;
            OrigLanguage = origLanguage;
            Genre = genre;
            AuthorID = authorId;
        }

        public BookModel()
        {
        }

        [Key]public int Id { get; set; }
        public string Name { get; set; }
        public string OrigLanguage { get; set; }
        public string Genre { get; set; }
        public int AuthorID { get; set; }

        [ForeignKey("AuthorID")] public AuthorModel Author { get; set; }
    }
}