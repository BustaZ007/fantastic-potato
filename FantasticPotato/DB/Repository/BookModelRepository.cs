using System.Collections.Generic;
using FantasticPotato.Interfaces;
using FantasticPotato.Models;
using System.Linq;
using FantasticPotato.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace FantasticPotato.DB.Repository
{
    public class BookModelRepository : IBooksModelRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookModelRepository()
        {
            _appDbContext = new AppDbContext();
        }

        public void AddNew(BookModel book)
        {
            _appDbContext.Entry(book).State = EntityState.Added;
            _appDbContext.SaveChanges();
        }

        public void Update(int id)
        {
            throw new System.NotImplementedException();
        }

        public BookModel GetById(int id) => _appDbContext.BookModels.FirstOrDefault(p => p.Id == id);

        public void DeleteById(int id)
        {
            _appDbContext.BookModels.Remove(GetById(id));
            _appDbContext.SaveChanges();
        }

        public AuthorModel GetAuthorById(int id) => _appDbContext.AuthorModels.FirstOrDefault(p => p.Id == id);

        public IEnumerable<BookModel> GetAllBooks => _appDbContext.BookModels;
    }
}