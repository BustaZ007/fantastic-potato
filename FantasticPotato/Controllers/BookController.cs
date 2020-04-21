using System.Collections;
using FantasticPotato.DB.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FantasticPotato.Controllers
{
    public class BookController
    {
        private readonly BookModelRepository _bookModelRepository;

        public BookController()
        {
            _bookModelRepository = new BookModelRepository();
        }

        [HttpGet]
        public IEnumerable GetAllBooks()
        {
            return _bookModelRepository.GetAllBooks;
        }
    }
}