using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNet5.Model;
using RestWithASPNet5.Bussiness;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNet5.Repository;

namespace RestWithASPNet5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        private IBookBussiness _bookBussiness;

        public BookController(ILogger<BookController> logger, IBookBussiness bookBussiness)
        {
            _logger = logger;
            _bookBussiness = bookBussiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBussiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = _bookBussiness.FindById(id);

            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null) BadRequest();

            return Ok(_bookBussiness.Create(book));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            if (book == null) BadRequest();

            return Ok(_bookBussiness.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var book = _bookBussiness.FindById(id);

            if (book == null) return NotFound();

            _bookBussiness.Delete(id);

            return NoContent();
        }
    }
}
