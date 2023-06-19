using BreweryAPI.Models;
using BreweryAPI.ResponseModel;

namespace BreweryAPI.Services
{
    public interface IBarAndBeerInfoService
    {
        //POST /bar/beer - Insert a single bar beer link
        Task<BarAndBeerInfo> InsertBarAndBeerInfo(BarAndBeerInfo objBarAndBeerInfo);

        //GET /bar/{barId}/beer - Get a single bar with associated beers
        Task<BarAndBeerInfoResponse> GetBarAndBeerInfoById(int BeerId);

        //GET /bar/beer - Get all bars with associated beers
        Task<IEnumerable<BarAndBeerInfoResponse>> GetBarAndBeerInfo();


    }
}
