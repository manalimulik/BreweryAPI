using BreweryAPI.Models;

namespace BreweryAPI.Services
{
    public interface IBreweryService
    {
        //POST /brewery - Insert a single brewery
        Task<Brewery> InsertBrewery(Brewery objBrewery);

        // PUT /brewery/{id} - Update a brewery by Id
        Task<Brewery> UpdateBreweryById(int BreweryId, Brewery objBrewery);

        //GET /brewery - Get all breweries
        Task<IEnumerable<Brewery>> GetAllBreweries();

        //GET /brewery/{id} - Get brewery by Id
        Task<Brewery> GetBreweryById(int BreweryId);
    }
}
