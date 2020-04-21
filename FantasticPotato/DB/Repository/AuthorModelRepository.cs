using System.Collections.Generic;
using System.Linq;
using FantasticPotato.Interfaces;
using FantasticPotato.Models;
using FantasticPotato.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace FantasticPotato.DB.Repository
{
    public class AuthorModelRepository : IAuthorModelRepository
    {
        private readonly AppDbContext _appDbContext;


        public AuthorModelRepository()
        {
            _appDbContext = new AppDbContext();
        }

        public void AddNew(AuthorModel author)
        {
            _appDbContext.Entry(author).State = EntityState.Added;
            _appDbContext.SaveChanges();
        }

        public void Update(int id)
        {
            throw new System.NotImplementedException();
        }

        public AuthorModel GetById(int id) => _appDbContext.AuthorModels.FirstOrDefault(p => p.Id == id);

        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<AuthorModel> GetAllAuthors => _appDbContext.AuthorModels;
    }
}