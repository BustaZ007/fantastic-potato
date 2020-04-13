using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasticPotato.Models
{
    
    [Table("Authors")]
    public class AuthorModel
    {
        public AuthorModel(int id, string name, string surname, DateTime dateOfBirth, string country)
        {
            Id = id;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Country = country;
        }

        [Key]public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        [InverseProperty("Author")]
        public IEnumerable<BookModel> Books{ get; set; }
    }
}