using System.Collections.Generic;
using System.Linq;
using FantasticPotato.Interfaces;
using FantasticPotato.Models;
using FantasticPotato.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace FantasticPotato.DB.Repository
{
    
    //https://alekseev74.ru/lessons/show/aspnet-core-mvc/entity-framework-core информация, которая поможет
    public class UserModelRepository : IUserModelRepository

    {
        private readonly AppDbContext _appDbContext;

        public UserModelRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public void AddNew(UserModel user)
        {
            _appDbContext.Entry(user).State = EntityState.Added;
            _appDbContext.SaveChanges();
        }

        public void Update(int userId)
        {
            _appDbContext.Entry(GetById(userId)).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }

        public UserModel GetById(int id) => _appDbContext.UserModels.FirstOrDefault(p => p.Id == id);


        public void DeleteById(int id)
        {
            _appDbContext.UserModels.Remove(GetById(id));
            _appDbContext.SaveChanges();
        }

        public IEnumerable<UserModel> GetAllUser => _appDbContext.UserModels;
    }
}