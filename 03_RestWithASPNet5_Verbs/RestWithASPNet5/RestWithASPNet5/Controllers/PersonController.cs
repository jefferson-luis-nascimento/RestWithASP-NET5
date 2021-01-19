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
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        private IPersonBussiness _personBussiness;

        public PersonController(ILogger<PersonController> logger, IPersonBussiness personBussiness)
        {
            _logger = logger;
            _personBussiness = personBussiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBussiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personBussiness.FindById(id);

            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) BadRequest();

            return Ok(_personBussiness.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) BadRequest();

            return Ok(_personBussiness.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var person = _personBussiness.FindById(id);

            if (person == null) return NotFound();

            _personBussiness.Delete(id);

            return NoContent();
        }
    }
}
