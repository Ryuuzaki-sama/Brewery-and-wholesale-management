using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Core.DTOs;
using Brewery_and_wholesale_management.DTOs;
using AutoMapper;

namespace Brewery_and_wholesale_management.Controllers
{
    public class BeersController : BaseApiController
    {
        private readonly IBeerRepository _context;
        private readonly BeerDbContext _repo;
        private readonly IMapper _mapper;

        public BeersController(IBeerRepository context, BeerDbContext repo, IMapper mapper)
        {
            this._context = context;
            this._repo = repo;
            _mapper = mapper;
        }
        // FR1- List all the beers by brewery
        [HttpGet("{BrewerId}")]
        public async Task<ActionResult<IReadOnlyList<BeerDTO>>> GetBeer(int BrewerId)
        {

            var listBeerByBrewer = await _context.GetBeersBybrewerAsync(BrewerId);

            return Ok(_mapper.Map<IReadOnlyList<Beer>, IReadOnlyList<BeerDTO>>(listBeerByBrewer));
        }

        //FR2- A brewer can add new beer
        [HttpPost, Authorize(Roles = "Brewer")]
        public async Task<ActionResult<Beer>> AddBeer([FromBody] Beer beer)
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
        [HttpDelete("{id}"), Authorize(Roles = "Brewer")]
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
