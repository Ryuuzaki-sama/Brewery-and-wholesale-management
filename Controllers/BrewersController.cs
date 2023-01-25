using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Brewery_and_wholesale_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrewerController : ControllerBase
    {
        private readonly BeerDbContext _context;

        public BrewerController(BeerDbContext context)
        {
            this._context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Brewer>>> getBrewerys()
        {
            var brewer = await _context.Brewers.ToListAsync();
            return Ok(brewer);
        }
        /*
        [HttpGet("{breweryId}")]
        public async Task<ActionResult<Brewer>> GetBeersByBrewery(int breweryId)
        {
            //return _context.GetBeersByBrewery(breweryId);
            return await _context.Brewers.FindAsync(breweryId);
        }
        */

        [HttpPost]
        public async Task<IActionResult> AddBrewery([FromBody] Brewer brewer)
        {
            _context.Brewers.Add(brewer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(getBrewerys), new { id = brewer.Id }, brewer);
        }
        /*
        
        [HttpDelete]
        public IHttpActionResult DeleteBeer(int beerId)
        {
            _context.DeleteBeer(beerId);
            return Ok();
        }
        */

    }
}
