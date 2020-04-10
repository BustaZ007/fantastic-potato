using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasticPotato.Models
{
    
    [Table("Authors")]
    public class AuthorModel
    {
        [Key]public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        [InverseProperty("Author")]
        public IEnumerable<BookModel> Books{ get; set; }
    }
}