using System.Collections.Generic;
using FantasticPotato.Models;

namespace FantasticPotato.Interfaces
{
    public interface IFeedbackRepository
    {
        void AddNew(FeedbackModel feedback);
        void Update(int id);
        BookModel GetBookById(int id);
        UserModel GetUserById(int id);
        FeedbackModel GetFeedbackById(int id);
        void DeleteById(int id);
        AuthorModel GetAuthorById(int id);
        IEnumerable<FeedbackModel> GetAllFeedback { get; }
    }
}