using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasticPotato.Models
{
    [Table ("Users")]
    public class UserModel
    {
        public UserModel(int id, string name, string surname, string mail, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Mail = mail;
            DateOfBirth = dateOfBirth;
        }

        public UserModel()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        [InverseProperty("User")]
        public IEnumerable<FeedbackModel> FeedBacks{ get; set; }
        
        
    }
}