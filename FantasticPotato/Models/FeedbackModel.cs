namespace FantasticPotato.Models
{
    public class FeedbackModel
    {
        public int Id { get; set; }
        public BookModel Book { get; set; }
        public UserModel User { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
    }
}