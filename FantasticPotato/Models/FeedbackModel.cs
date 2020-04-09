using System;

namespace FantasticPotato.Models
{
    public class FeedbackModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public virtual BookModel Book { get; set; }
        public virtual UserModel User { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime DateOfWriting { get; set; }
    }
}