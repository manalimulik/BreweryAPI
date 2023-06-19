using BreweryAPI.Models;
using BreweryAPI.ResponseModel;

namespace BreweryAPI.Services
{
    public interface IBreweryAndBeerInfoService
    {
        //POST /brewery/beer - Insert a single brewery beer link
        Task<BreweryAndBeerInfo> InsertBreweryAndBeerInfo(BreweryAndBeerInfo objBreweryAndBeerInfo);

        //GET /brewery/{breweryId}/beer - Get a single brewery by Id with associated beers
        Task<BreweryAndBeerInfoResponse> GetBreweryAndBeerInfoById(int BreweryId);

        //GET /brewery/beer - Get all breweries with associated beers
        Task<IEnumerable<BreweryAndBeerInfoResponse>> GetBreweryAndBeerInfo();
    }
}
