using System.Collections.Generic;
using System.Linq;
using FantasticPotato.Interfaces;
using FantasticPotato.Models;
using FantasticPotato.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace FantasticPotato.DB.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        
        private readonly AppDbContext _appDbContext;

        public FeedbackRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddNew(FeedbackModel feedback)
        {
            _appDbContext.Entry(feedback).State = EntityState.Added;
            _appDbContext.SaveChanges();
        }

        public void Update(int id)
        {
            throw new System.NotImplementedException();
        }

        public BookModel GetBookById(int id) =>_appDbContext.BookModels.FirstOrDefault(p => p.Id == id);

        public UserModel GetUserById(int id) => _appDbContext.UserModels.FirstOrDefault(p => p.Id == id);

        public FeedbackModel GetFeedbackById(int id) => _appDbContext.FeedbackModels.FirstOrDefault(p => p.Id == id);

        public void DeleteById(int id)
        {
            _appDbContext.FeedbackModels.Remove(GetFeedbackById(id));
            _appDbContext.SaveChanges();
        }

        public IEnumerable<FeedbackModel> GetAllFeedback => _appDbContext.FeedbackModels;
    }
}