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
    public class BooksController : ControllerBase
    {
        private readonly BookDbContext _db;
        public BooksController(BookDbContext db) { _db = db; }

        //Using the 

        // GET: api/books
        [HttpGet]
        [EnableQuery]
        public IQueryable<Book> GetBooks()
        {
            //var books = _db.Books.ToList();
            //return Ok(books);

            return _db.Books.AsQueryable();
        }



        //POST : api/books/{id}

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType<Book>(StatusCodes.Status201Created)]
        [ProducesResponseType<Book>(StatusCodes.Status400BadRequest)]

        public IActionResult Add(Book book) 
        {
            //Validate
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Books.Add(book);
            _db.SaveChanges();

            return Created($"/api/books/{book.Id}", book);
        }



        //PUT : api/books/{id}
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType<Book>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<Book>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<Book>(StatusCodes.Status200OK)]
        public IActionResult Update([FromQuery] int id,[FromBody]Book book) 
        {
            var b = _db.Books.Find(id);
            if (b == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Auto mapping to both the objects
            b.ISBN = book.ISBN;
            b.PublishedDate = book.PublishedDate;
            b.CategoryId = book.CategoryId;
            b.AuthorId = book.AuthorId;
            b.Title = book.Title;

            _db.SaveChanges();
            return Ok();

        }


        //PATCH : .../api/books/{id}
        [HttpPatch("{id:int}")]
        [Consumes("application/json")]
        [ProducesResponseType<Book>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<Book>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<Book>(StatusCodes.Status204NoContent)]

        public IActionResult Patch([FromQuery] int id, JsonPatchDocument<Book> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var b = _db.Books.Find(id);
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

        //DELETE : .../api/books/{id}

        [HttpDelete]
        [Consumes("application/json")]
        [ProducesResponseType<Book>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<Book>(StatusCodes.Status200OK)]

        public IActionResult Delete(int id)
        {
            var b = _db.Books.Find(id);
            if (b == null)
            {
                return NotFound();

            }

            _db.Books.Remove(b);
            _db.SaveChanges();
            return Ok();
        }






        //// GET: api/books/{id}
        //[HttpGet("{id}")]
        //public IActionResult GetBookById(int id)
        //{
        //    var book = _db.Books.Find(id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(book);
        //}

    }
}
