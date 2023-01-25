using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace Brewery_and_wholesale_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly IBeerRepository _context;
        private readonly BeerDbContext _repo;

        public BeersController(IBeerRepository context, BeerDbContext repo)
        {
            this._context = context;
            this._repo = repo;
        }
        // FR1- List all the beers by brewery
        [HttpGet("{BrewerId}")]
        public async Task<IReadOnlyList<Beer>> GetBeer(int BrewerId)
        {

            return await _context.GetBeersBybrewerAsync(BrewerId);
        }

        //FR2- A brewer can add new beer
        [HttpPost]
        public async Task<ActionResult> AddBeer([FromBody] Beer beer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brewer = await _repo.Brewers.FindAsync(beer.BrewerId);

            if (brewer == null)
            {
                return NotFound();
            }

            _repo.Beers.Add(beer);
            await _repo.SaveChangesAsync();

            return CreatedAtAction(null, new { id = beer.Id }, beer);

        }
        //FR3- A brewer can delete a beer
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeer(int id)
        {
            var beer = _repo.Beers.Find(id);
            if(beer == null)
            {
                return NotFound();
            }
            _repo.Beers.Remove(beer);
            await _repo.SaveChangesAsync();
            return NoContent();
        }
    }
}
