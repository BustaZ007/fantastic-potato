using System.Collections.Generic;
using FantasticPotato.Models;

namespace FantasticPotato.Interfaces
{
    public interface IBooksModelRepository
    {
        void AddNew(BookModel book);
        void Update(int id);
        BookModel GetById(int id);
        void DeleteById(int id);
        AuthorModel GetAuthorById(int id);
        IEnumerable<BookModel> GetAllBooks { get; }
    }
}