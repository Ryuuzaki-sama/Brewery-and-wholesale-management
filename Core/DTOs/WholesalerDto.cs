namespace Brewery_and_wholesale_management.DTOs;

public class WholesalerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<BeerDTO> Beers { get; set; }
    
}
