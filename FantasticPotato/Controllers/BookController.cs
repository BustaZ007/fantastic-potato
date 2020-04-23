using System.Collections;
using FantasticPotato.DB.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FantasticPotato.Controllers
{
    public class BookController
    {
        private readonly BookModelRepository _bookModelRepository;

        public BookController(BookModelRepository BMR)
        {
            _bookModelRepository = BMR;
        }

        [HttpGet]
        public IEnumerable GetAllBooks()
        {
            return _bookModelRepository.GetAllBooks;
        }
    }
}