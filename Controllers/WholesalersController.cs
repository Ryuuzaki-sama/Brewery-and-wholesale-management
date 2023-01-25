using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brewery_and_wholesale_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WholesalersController : ControllerBase
    {
        private readonly BeerDbContext _context;

        public WholesalersController(BeerDbContext context)
        {
            this._context = context;
        }

      

        [HttpGet]
        public ActionResult<Wholesaler> GetWholesalers()
        {
            return Ok(_context.Wholesalers.ToList());
        }

        [HttpPost]
        public ActionResult<Wholesaler> AddWholesaler([FromBody] Wholesaler wholesaler)
        {
            _context.Wholesalers.Add(wholesaler);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetWholesalers), new { id = wholesaler.Id }, wholesaler);
        }

        [HttpGet("sales")]
        public ActionResult<Sale> GetSales()
        {
            return Ok(_context.Sales.ToList());
        }
        // FR4- Add the sale of an existing beer to an existing wholesaler
        [HttpPost("sales")]
        public ActionResult<Sale> AddSale([FromBody] Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSales), new { id = sale.Id }, sale);
        }

        // FR5- A wholesaler can update the remaining quantity of a beer in his stock.

        /*
        [HttpPut]
        public IHttpActionResult UpdateBeerStock(int wholesalerId, int beerId, int newQuantity)
        {
            _wholesalerService.UpdateBeerStock(wholesalerId, beerId, newQuantity);
            return Ok();
        }
        */

        // FR6- A client can request a quote from a wholesaler, 2 scenarios:
        [HttpPost("wholesalers/{wholesalerId}/quote")]
        public ActionResult<Quote> RequestQuote(int wholesalerId,[FromBody] List<OrderItem> orderItems)
        {

            // 1- If successful, the method returns a price and a summary of the quote.


            // 10% Discount


            // 20% Discount

            //If there is an error, it returns an exception and a message to explain the reason

            //The wholesaler must exist
            var wholesaler = _context.Wholesalers.Find(wholesalerId);
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

            if(distinctItems.Count != orderItems.Count)
            {
                return BadRequest("There can't be any duplicate in the order");
            }

            // The number of beers ordered cannot be greater than the wholesaler's stock


            //The beer must be sold by the wholesaler


            float totalPrice = 0;
            float discount = 0;
           

            var quote = new Quote() { Price = totalPrice - discount, Discount = discount, Summary = "Your Quote has been generated successfully." };

            return Ok(quote);
        }


        /*
        

        [HttpPost]
        public IHttpActionResult RequestQuote(int wholesalerId, List<OrderItem> orderItems)
        {
            var quote = _wholesalerService.RequestQuote(wholesalerId, orderItems);
            if (quote.Success)
            {
                return Ok(quote);
            }
            else
            {
                return BadRequest(quote.ErrorMessage);
            }
        }
        */
    }
}
