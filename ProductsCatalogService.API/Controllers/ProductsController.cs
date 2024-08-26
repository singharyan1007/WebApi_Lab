using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using ProductsCatalogService.API.Model.Data;
using ProductsCatalogService.API.Model.Entities;

namespace ProductsCatalogService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsDbContext _db;
        public ProductsController(ProductsDbContext productsDbContext)
        {
            _db = productsDbContext;
        }

        //using OData we only need GetAll

        //Desin the endpoint uri
        //   .../api/products/

        [HttpGet]
        [EnableQuery]
        public IQueryable<Product> GiveMeAllProducts()
        {
            return _db.Products.AsQueryable();  //.ToList()
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType<Product>(StatusCodes.Status201Created)]
        [ProducesResponseType<Product>(StatusCodes.Status400BadRequest)]
        //Only being used for documentation purpose
        public IActionResult Add(Product product)
            //product is coming from body
            //in delete -> id is coming from query parameters
        {
            //validate
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Products.Add(product);
            _db.SaveChanges();

            return Created($"/api/products/{product.ProductId}", product);
        }

        // in case there is mixed parameters, specify
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType<Product>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<Product>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<Product>(StatusCodes.Status200OK)]
        public IActionResult Put([FromQuery] int id, [FromBody] Product product)
        {
            var prod = _db.Products.Find(id);
            if (prod == null)
            {
                return NotFound();

            }
            //validate
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //_db.Products.Update(prod);

            //Mapping
            prod.ProductName = product.ProductName;
            prod.ProductDescription = product.ProductDescription;
            prod.Price = product.Price;
            prod.ProductCategory = product.ProductCategory;
            prod.Country = product.Country;
            prod.IsAvailable = product.IsAvailable;

            _db.SaveChanges();

            return Ok();
        }



        //Delete products
        [HttpDelete]
        [Consumes("application/json")]
        [ProducesResponseType<Product>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<Product>(StatusCodes.Status200OK)]

        public IActionResult Delete(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null)
            {
                return NotFound();

            }

            _db.Products.Remove(product);
            _db.SaveChanges();
            return Ok();
        }


        //PATCH work

        [HttpPatch("{id:int}")]
        [Consumes("application/json")]
        [ProducesResponseType<Product>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<Product>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<Product>(StatusCodes.Status204NoContent)]

        public IActionResult Patch([FromQuery] int id, JsonPatchDocument<Product> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest(); 
            }

            var proc=_db.Products.Find(id);
            if (proc == null)
            {
                return NotFound();
            }
            patchDoc.ApplyTo(proc, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.SaveChanges();

            return NoContent();
        }






        // ...api/products/{placeholder}
        //[HttpGet]
        //[Route("{id:int}")]
        //public IActionResult Get(int id)
        //{
        //    var prod= _db.Products.Find(id);
        //    if (prod == null)
        //    {
        //        //return 404
        //        return NotFound();
        //    }
        //    else { 
        //        return Ok(prod);
        //    }
        //}


        ////Filter

        //[HttpGet]
        //[Route("{category:alpha}")]
        //public IActionResult Get(string category)
        //{
        //    var prod = from p in _db.Products
        //               where p.ProductCategory == category
        //               select p ;
        //    if (prod.Count() ==0)
        //    {
        //        //return 404
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(prod.ToList());
        //    }
        //}

        ////Country filter
        //[HttpGet]
        //[Route("country")]
        //public IActionResult GetCountry([FromQuery] string country)
        //{
        //    var prod = from p in _db.Products
        //               where p.Country == country
        //               select p;
        //    if (prod.Count() == 0)
        //    {
        //        //return 404
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(prod.ToList());
        //    }
        //}

        ////Get all products in stock

        //[HttpGet("stock/available")]
        //public IActionResult GetInStock()
        //{
        //    var prod = _db.Products.Where(p => p.IsAvailable == true).ToList();
        //    if (!prod.Any())
        //    {
        //        return NotFound();
        //    }
        //    return Ok(prod);
        //}
        ////Get all products out of stock
        //[HttpGet("stock/unavailable")]
        //public IActionResult GetOutOfStock()
        //{
        //    var prod = _db.Products.Where(p => p.IsAvailable == false).ToList();
        //    if (!prod.Any())
        //    {
        //        return NotFound();
        //    }
        //    return Ok(prod);
        //}
        ////Get product by name
        //[HttpGet("name")]
        //public IActionResult GetByName([FromQuery] string productName)
        //{
        //    var prod = _db.Products.Where(p => p.ProductName == productName).ToList();
        //    if (!prod.Any())
        //    {
        //        return NotFound();
        //    }
        //    return Ok(prod);
        //}
        ////get costliest product
        //[HttpGet("products/highest")]
        //public IActionResult GetCostliestProduct()
        //{
        //    var prod = _db.Products.OrderByDescending(p => p.Price).FirstOrDefault();
        //    if (prod == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(prod);
        //}
        ////get cheapest product
        //[HttpGet("products/cheapest")]
        //public IActionResult GetCheapestProduct()
        //{
        //    var prod = _db.Products.OrderBy(p => p.Price).FirstOrDefault();
        //    if (prod == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(prod);
        //}


        ////get product price between min and max
        //[HttpGet("price/range")]
        //public IActionResult GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        //{
        //    var prod = _db.Products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
        //    if (!prod.Any())
        //    {
        //        return NotFound();
        //    }
        //    return Ok(prod);
        //}

        //// Get products by brand
        //[HttpGet("brand/{brandName:alpha}")]
        //public IActionResult GetByBrand(string brandName)
        //{
        //    var prod = _db.Products.Where(p => p.Brand == brandName).ToList();
        //    if (!prod.Any())
        //    {
        //        return NotFound();
        //    }
        //    return Ok(prod);
        //}




    }
}
