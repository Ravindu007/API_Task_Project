using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAPIProject.Models;
using TaskAPIProject.Services.Authors;
using TaskAPIProject.Services.Models;

namespace TaskAPIProject.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _service;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepository service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //Get all Authors
        [HttpGet]
        public ActionResult<ICollection<AuthorDto>> GetAllAuthors(string? job, string? search)
        {

            var authors = _service.GetAllAuthors(job, search);

            var mappedAuthors =  _mapper.Map<ICollection<AuthorDto>>(authors);
            
            return Ok(mappedAuthors);
        }

        //Get Single Authors
        [HttpGet("{id}", Name = "GetAuthor")] 
        public IActionResult GetAuthor(int id)
        {
            var author = _service.GetAuthor(id);
            if(author is null) return NotFound();

            var mappedAuthor = _mapper.Map<AuthorDto>(author);

            return Ok(mappedAuthor);
        }

        // Create Author 
        [HttpPost]
        public ActionResult<AuthorDto> CreateAuthor(CreateAuthorDto author)
        {
            var authorEntity = _mapper.Map<Author>(author);
            var newAuthor = _service.AddAuthor(authorEntity);

            var authorForReturn = _mapper.Map<AuthorDto>(newAuthor);

            return CreatedAtRoute("GetAuthor", new { id = authorForReturn.Id }, authorForReturn);
        }
    }
}
