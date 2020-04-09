using System;
using System.Collections.Generic;

namespace FantasticPotato.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public IEnumerable<BookModel> Books{ get; set; }
    }
}