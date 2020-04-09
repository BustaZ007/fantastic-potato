using System.Collections.Generic;
using FantasticPotato.Models;

namespace FantasticPotato.Interfaces
{
    public interface IAuthorModelRepository
    {
        void AddNew(AuthorModel author);
        void Update (int id);
        UserModel GetById(int id);
        void DeleteById(int id);
        
        IEnumerable<UserModel> GetAllAuthors { get; }
        
    }
}