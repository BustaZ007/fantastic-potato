using System.Collections.Generic;
using System.Linq;
using FantasticPotato.Interfaces;
using FantasticPotato.Models;
using FantasticPotato.Models.DBModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace FantasticPotato.DB.Repository
{
    
    //https://alekseev74.ru/lessons/show/aspnet-core-mvc/entity-framework-core информация, которая поможет
    public class UserModelRepository : IUserModelRepository

    {
        private readonly AppDbContext _appDbContext;

        public UserModelRepository()
        {
            _appDbContext = new AppDbContext();
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
        
        public UserModel GetByLogin(string login) => _appDbContext.UserModels.FirstOrDefault(p => p.Login == login);
        
        public UserModel GetByEmail(string mail) => _appDbContext.UserModels.FirstOrDefault(p => p.Mail == mail);


        public void DeleteById(int id)
        {
            _appDbContext.UserModels.Remove(GetById(id));
            _appDbContext.SaveChanges();
        }

        public IEnumerable<UserModel> GetAllUser => _appDbContext.UserModels;
    }
}