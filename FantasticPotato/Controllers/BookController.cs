using System.Collections;
using System.Diagnostics;
using FantasticPotato.DB.Repository;
using FantasticPotato.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FantasticPotato.Controllers
{
    [Route("[controller]")]
    [ApiController]
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