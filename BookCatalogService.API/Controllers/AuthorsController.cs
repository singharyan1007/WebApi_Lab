using BookCatalogService.API.Model.Data;
using BookCatalogService.API.Model.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly BookDbContext _db;

        public AuthorsController(BookDbContext db)
        {
            _db = db;
        }

        // GET: api/authors
        [HttpGet]
        [EnableQuery]
        public IQueryable<Author> GetAuthors()
        {
           return _db.Authors.AsQueryable();
        }


        //POST : .../api/authors/

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType<Author>(StatusCodes.Status201Created)]
        [ProducesResponseType<Author>(StatusCodes.Status400BadRequest)]

        public IActionResult Add(Author auth)
        {
            //Validate
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Authors.Add(auth);
            _db.SaveChanges();

            return Created($"/api/books/{auth.Id}", auth);
        }



        //PATCH : .../api/authors/{id}
        [HttpPatch("{id:int}")]
        [Consumes("application/json")]
        [ProducesResponseType<Author>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<Author>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<Author>(StatusCodes.Status204NoContent)]

        public IActionResult Patch([FromQuery] int id, JsonPatchDocument<Author> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var b = _db.Authors.Find(id);
            if (b == null)
            {
                return NotFound();
            }
            patchDoc.ApplyTo(b, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.SaveChanges();
            return NoContent();

        }
    }
}
