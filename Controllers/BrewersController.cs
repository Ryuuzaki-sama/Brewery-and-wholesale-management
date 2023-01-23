using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Brewery_and_wholesale_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrewersController : ControllerBase
    {
        private readonly BeerDbContext _context;

        public BrewersController(BeerDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task< ActionResult<List <Brewer>>> getBrewerys()
        {
            var brewer = await _context.Brewers.ToListAsync();
            return Ok(brewer);
        }

        [HttpGet]
        public async Task<ActionResult<Beer>> GetBeersByBrewery(int breweryId)
        {
            //return _context.GetBeersByBrewery(breweryId);
            return await _context.Beers.FindAsync(breweryId);
        }

        [HttpPost]
        public ActionResult<Brewer> AddBrewery([FromBody] Brewer brewer)
        {
            _context.Brewers.Add(brewer);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getBrewerys), new { id = brewer.Id }, brewer);
        }
        /*
        [HttpPost]
        public IHttpActionResult AddBeer(Beer beer)
        {
            _context.AddBeer(beer);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteBeer(int beerId)
        {
            _context.DeleteBeer(beerId);
            return Ok();
        }
        */

    }
}
