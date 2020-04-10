using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasticPotato.Models
{
    [Table ("Users")]
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        [InverseProperty("User")]
        public IEnumerable<FeedbackModel> FeedBacks{ get; set; }
        
        
    }
}