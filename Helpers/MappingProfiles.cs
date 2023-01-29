using AutoMapper;
using Brewery_and_wholesale_management.DTOs;
using Core.DTOs;
using Core.Entities;

namespace Brewery_and_wholesale_management.Helpers
{
    public class MappingProfiles : Profile
    {
        protected MappingProfiles()
        {
            CreateMap<Beer, BeerDTO>()
                .ForMember(br => br.BrewerName, o => o.MapFrom(be => be.Brewer.Name));

            CreateMap<Wholesaler, WholesalerDto>();

            CreateMap<Stock, StockDto>()
                .ForMember(st => st.Beer, o => o.MapFrom(be => be.Beer.Name))
                .ForMember(st => st.Wholesaler, o => o.MapFrom(be => be.wholesaler.Id))
                .ForMember(st => st.PriceStock, o => o.MapFrom(be => be.Beer.Price));

            CreateMap<Sale, SalesDto>()
                .ForMember(st => st.Beer, o => o.MapFrom(be => be.Beer.Name))
                .ForMember(st => st.Wholesaler, o => o.MapFrom(be => be.wholesaler.Id))
                .ForMember(br => br.PriceSale, o => o.MapFrom(be => be.Beer.Price * be.QuantitySale));
        }
    }
}
