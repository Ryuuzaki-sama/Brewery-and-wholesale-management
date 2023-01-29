using Brewery_and_wholesale_management.Core.Interfaces;
using Brewery_and_wholesale_management.DTOs;
using Core.Entities;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class WholesalerRepository : IWholesalerService
    {
        private readonly IWholesalerService _wholesalerRepository;
        private readonly BeerDbContext _context;

        public WholesalerRepository(IWholesalerService wholesalerRepository, BeerDbContext context)
        {
            _wholesalerRepository = wholesalerRepository;
            this._context = context;
        }
        public Task<bool> AddSale(BeerDTO beer, WholesalerDto wholesaler)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BeerDTO>> GetBeersByWholesaler(int wholesalerId)
        {
            var beers = await _context.Beers
                .Where(b => b.WholesalerId == wholesalerId)
                .Select(b => new BeerDTO
                {
                    Id = b.Id,
                    Name = b.Name,
                    Price = b.Price,
                    Quantity = b.QuantityLimit,
                    WholesalerId = b.WholesalerId
                })
                .ToListAsync();

            return beers;
        }

        public async Task<Quote> RequestQuote(List<BeerDTO> beers, WholesalerDto wholesaler, int quantity)
        {
            // Check if the order is not empty
            if (beers == null || beers.Count == 0)
            {
                throw new Exception("The order cannot be empty");
            }

            // Check if the wholesaler exist
            if (wholesaler == null)
            {
                throw new Exception("The wholesaler must exist");
            }

            // Check if there are any duplicate in the order
            if (beers.GroupBy(b => b.Id).Any(g => g.Count() > 1))
            {
                throw new Exception("There can't be any duplicate in the order");
            }

            // Check if the number of beers ordered is greater than the wholesaler's stock
            if (beers.Sum(b => b.Quantity) > quantity)
            {
                throw new Exception("The number of beers ordered cannot be greater than the wholesaler's stock");
            }

            // Check if the beer are sold by the wholesaler
            var beerIds = beers.Select(b => b.Id).ToList();
            var wholesalerBeers = await GetBeersByWholesaler(wholesaler.Id);
            if (!wholesalerBeers.Any(wb => beerIds.Contains(wb.Id)))
            {
                throw new Exception("The beer must be sold by the wholesaler");
            }

            // Calculate the price
            var Discount = 0;
            if (beers.Sum(b => b.Quantity) > 10)
            {
                Discount = Convert.ToInt32(0.1);
            }
            if (beers.Sum(b => b.Quantity) > 20)
            {
                Discount = Convert.ToInt32(0.1);
            }

            // Return the quote
            var quote = new Quote
            {
                Discount = Discount,
                Price = quantity * beers.Sum(b => b.Price),
                Summary = "Your Quote has been generated successfully."
            };

            return quote;
        }

        public Task<bool> UpdateStock(BeerDTO beer, WholesalerDto wholesaler)
        {
            throw new NotImplementedException();
        }

        Task IWholesalerService.GetBeersByWholesaler(int id)
        {
            throw new NotImplementedException();
        }
    }
}
