using BookCatalogService.API.Model.Data;
using BookCatalogService.API.Model.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly BookDbContext _db;

        public CategoriesController(BookDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<Category> GetAuthors()
        {
            return _db.Categories.AsQueryable();
        }


        //Updating a Category
        //PUT : api/books/{id}
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType<Author>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<Author>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<Author>(StatusCodes.Status200OK)]
        public IActionResult Update([FromQuery] int id, [FromBody] Category cat)
        {
            var b = _db.Categories.Find(id);
            if (b == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Auto mapping to both the objects
            b.Id=cat.Id;
            b.Name=cat.Name;

            _db.SaveChanges();
            return Ok();

        }



        //Deleting a Category

        [HttpDelete]
        [Consumes("application/json")]
        [ProducesResponseType<Author>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<Author>(StatusCodes.Status200OK)]

        public IActionResult Delete(int id)
        {
            var b = _db.Categories.Find(id);
            if (b == null)
            {
                return NotFound();

            }

            _db.Categories.Remove(b);
            _db.SaveChanges();
            return Ok();
        }

    }
}
