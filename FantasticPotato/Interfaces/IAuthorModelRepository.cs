using System.Collections.Generic;
using FantasticPotato.Models;

namespace FantasticPotato.Interfaces
{
    public interface IAuthorModelRepository
    {
        void AddNew(AuthorModel author);
        void Update (int id);
        AuthorModel GetById(int id);
        void DeleteById(int id);
        
        IEnumerable<AuthorModel> GetAllAuthors { get; }
        
    }
}