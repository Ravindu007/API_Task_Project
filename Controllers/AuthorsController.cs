using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAPIProject.Services.Authors;

namespace TaskAPIProject.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _service;
        public AuthorsController(IAuthorRepository service)
        {
            _service = service;
        }

        //Get all Authors
        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = _service.GetAllAuthors();
            return Ok(authors);
        }

        //Get Single Authors
        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id)
        {
            var author = _service.GetAuthor(id);
            if(author is null) return NotFound();

            return Ok(author);
        }
    }
}
