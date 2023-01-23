using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Brewery_and_wholesale_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly BeerDbContext _context;

        public BeersController(BeerDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public ActionResult<Beer> GetBeer()
        {
           
            return Ok(_context.Beers.ToList());
        }


        [HttpPost]
        public ActionResult<Beer> AddBear([FromBody] Beer beer)
        {
            _context.Beers.Add(beer);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBeer), new { id = beer.Id }, beer);
        }

        [HttpDelete]
        public ActionResult<Beer> DeleteBeer(int id)
        {
            var beer = _context.Beers.Find(id);
            if(beer == null)
            {
                return NotFound();
            }
            _context.Beers.Remove(beer);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
