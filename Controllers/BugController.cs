using Brewery_and_wholesale_management.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Brewery_and_wholesale_management.Controllers
{
    public class BugController : BaseApiController
    {
        private readonly BeerDbContext _context;

        public BugController(BeerDbContext context)
        {
            this._context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var brewer = _context.Brewers.Find(42);
            if (brewer == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }


        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var brewer = _context.Brewers.Find(42);

            var brewerToReturn = brewer.ToString();
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }
    }
}
