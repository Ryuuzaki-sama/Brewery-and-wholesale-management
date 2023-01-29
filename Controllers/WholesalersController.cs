using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Core.DTOs;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Brewery_and_wholesale_management.DTOs;
using Brewery_and_wholesale_management.Core.Interfaces;
using Core.Interfaces;

namespace Brewery_and_wholesale_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WholesalersController : BaseApiController
    {
        private readonly BeerDbContext _context;
        private readonly IBeerRepository _Beercontext;
        private readonly IMapper _mapper;

        private readonly IWholesalerService _wholesalerService;

        public WholesalersController(BeerDbContext context, IMapper mapper, IBeerRepository Beercontext, IWholesalerService wholesalerService)
        {
            this._context = context;
            this._mapper = mapper;
            this._Beercontext = Beercontext;
            _wholesalerService = wholesalerService;
        }

        [HttpGet]

        public async Task<IReadOnlyList<Wholesaler>> GetWholesalers()
        {

            return await _context.Wholesalers.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> AddWholesaler([FromBody] Wholesaler wholesaler)
        {
            _context.Wholesalers.Add(wholesaler);
            await _context.SaveChangesAsync();
            return CreatedAtAction(null, new { id = wholesaler.Id }, wholesaler);
        }

        [HttpGet("sales/{WholesalerId}")]
        public ActionResult<SalesDto> GetSales(int WholesalerId)
        {
            //.Where(x => x.WholesalerId == WholesalerId)
            return Ok(_context.Sales.ToList());
        }
        // FR4- Add the sale of an existing beer to an existing wholesaler
        [HttpPost("addsale/{wholesalerId}/{beerId}"), Authorize(Roles = "Brewer")]
        public async Task<ActionResult> AddSale([FromBody] Sale sale, int beerId, int wholesalerId)
        {
            // Find the beer and the wholesaler in the database
            var dbStock = _context.Stocks.FirstOrDefault(s => s.WholesalerId == wholesalerId && s.BeerId == beerId);
            var dbbeer = _context.Beers.FirstOrDefault(b => b.Id == beerId);
            var dbWholesaler = _context.Wholesalers.Include(w => w.Beers).FirstOrDefault(w => w.Id == wholesalerId);

            // Check if the beer and the wholesaler exist
            if (dbStock == null || dbWholesaler == null)
            {
                return BadRequest("Wholesaler or beer does not exist in the stock");
            }

            // Check if the wholesaler already sells the beer
            if (!dbWholesaler.Beers.Any(b => b.Id == beerId))
            {
                return BadRequest("The wholesaler does not have");
            }

            // Check if the wholesaler has enough stock
            if (dbStock.QuantityStock < sale.QuantitySale)
            {
                return BadRequest("The quantity requesting is above the quantity in the wholesaler's stock");
            }

            // Update the stock and add the sale
            dbStock.QuantityStock -= sale.QuantitySale;
            sale = new Sale
            {
                WholesalerId = wholesalerId,
                BeerId = beerId,
                QuantitySale = sale.QuantitySale,
                PriceSale = dbbeer.Price * sale.QuantitySale,
            };
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSales), new { id = sale.Id }, sale);
        }

        // FR5- A wholesaler can update the remaining quantity of a beer in his stock.


        [HttpPut("updatestock/{wholesalerId}/{beerId}"), Authorize(Roles = "Wholesaler")]
        public async Task<ActionResult> UpdateStock(int beerId, int wholesalerId, int newquantity)
        {
            // Find the beer and the wholesaler in the database
            var dbBeer = _context.Beers.FirstOrDefault(b => b.Id == beerId);
            var dbStock = _context.Stocks.FirstOrDefault(s => s.WholesalerId == wholesalerId && s.BeerId == beerId);
            var dbWholesaler = _context.Wholesalers.Include(w => w.Beers).FirstOrDefault(w => w.Id == wholesalerId);
            // Check if the beer and the wholesaler exist
            if (dbBeer == null || dbWholesaler == null)
            {
                return BadRequest("The beer or wholesalers does not exist"); ;
            }
            // Check if the wholesaler already sells the beer
            if (!dbWholesaler.Beers.Any(b => b.Id == dbBeer.Id))
            {
                return BadRequest("The wholesaler does not have the chosen beer in the stock"); ;
            }
            // Update the stock
            dbStock.QuantityStock = newquantity;
            _context.Stocks.Update(dbStock);
            await _context.SaveChangesAsync();

            return Ok(dbStock);

        }

        // FR6- A client can request a quote from a wholesaler, 2 scenarios:
        [HttpGet("requestQuote/quote/{wholesalerId}"), Authorize()]
        public async Task<ActionResult> RequestQuote(List<BeerDTO> beers, int quantity, List<OrderItem> orderItems, int wholesalerId, WholesalerDto wholesalerdto)
        {
            var wholesaler = _context.Wholesalers.Find(wholesalerId);

            if (beers.Count() == 0)
            {
                return BadRequest("Order cannot be empty");
            }

            if (beers.GroupBy(x => x.Id).Any(g => g.Count() > 1))
            {
                return BadRequest("There can't be any duplicate in the order");
            }

            //The wholesaler must exist

            if (wholesaler == null)
            {
                return NotFound("The wholesaler does not exist.");

            }
            // The order cannot be empty
            if (!orderItems.Any())
            {
                return BadRequest("The order cannot be empty");
            }

            //There can't be any duplicate in the order
            var distinctItems = orderItems.GroupBy(x => x.BeerId).Select(g => g.First()).ToList();

            if (distinctItems.Count != orderItems.Count)
            {
                return BadRequest("There can't be any duplicate in the order");
            }

            var quote = await _wholesalerService.RequestQuote(beers, wholesalerdto, quantity);


            float totalPrice = 0;
            float discount = 0;


            quote = new Quote() { Price = Convert.ToInt32(totalPrice * quote.Discount), Discount = quote.Discount, Summary = "Your Quote has been generated successfully." };

            return Ok(quote);
        }
    }
}
