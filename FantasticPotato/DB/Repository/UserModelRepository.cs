using System.Collections.Generic;
using System.Linq;
using FantasticPotato.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FantasticPotato.Models.DBModels.Repository
{
    public class UserModelRepository : IUserModelRepository

    {
        private readonly AppDbContent _appDbContent;

        public UserModelRepository(AppDbContent appDbContent)
        {
            _appDbContent = appDbContent;
        }
        
        public void AddNew(UserModel user)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int userId)
        {
            throw new System.NotImplementedException();
        }

        public UserModel GetById(int id) => _appDbContent.UserModels.FirstOrDefault(p => p.Id == id);


        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserModel> GetAllUser => _appDbContent.UserModels;
    }
}