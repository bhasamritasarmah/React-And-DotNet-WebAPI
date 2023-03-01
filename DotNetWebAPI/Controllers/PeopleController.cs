using Microsoft.AspNetCore.Mvc;
using React_and_WebAPI.Models;
using React_and_WebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace React_and_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService service)
        {
            _peopleService = service;
        }
        // GET: api/<PeopleController>
        [HttpGet]
        public ActionResult<List<People>> Get()
        {
            return _peopleService.Get();
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public ActionResult<People> Get(string id)
        {
            var person = _peopleService.Get(id);    

            if (person == null)
            {
                return NotFound($"The person with id = {id} not found");
            }

            return person;
        }

        // POST api/<PeopleController>
        [HttpPost]
        public ActionResult<People> Post([FromBody] People person)
        {
            _peopleService.Create(person);

            return CreatedAtAction(nameof(Get), new { id = person.Id}, person);
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public ActionResult<People> Put(string id, [FromBody] People person)
        {
            var existingPerson = _peopleService.Get(id);

            if (existingPerson == null)
            {
                return NotFound($"The person with id = {id} not found.");
            }

            _peopleService.Update(id, person);

            return NoContent();
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public ActionResult<People> Delete(string id)
        {
            var personToBeDeleted = _peopleService.Get(id);

            if (personToBeDeleted == null)
            {
                return NotFound($"The person with id = {id} not found");
            }

            _peopleService.Remove(id);

            return NoContent();
        }
    }
}
