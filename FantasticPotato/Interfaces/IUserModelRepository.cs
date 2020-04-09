using System.Collections;
using System.Collections.Generic;
using FantasticPotato.Models;

namespace FantasticPotato.Interfaces
{
    public interface IUserModelRepository
    {
        void AddNew(UserModel user);
        void Update (int userId);
        UserModel GetById(int id);
        void DeleteById(int id);
        IEnumerable<UserModel> GetAllUser { get; }
        
    }
}