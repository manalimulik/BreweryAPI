using BreweryAPI.Models;

namespace BreweryAPI.Services
{
    public interface IBarService
    {

        //POST /bar - Insert a single bar
        Task<Bar> InsertBar(Bar objBar);

        // PUT /bar/{id} - Update a bar by Id
        Task<Bar> UpdateBarById(int BarId, Bar objBar);

        //GET /bar - Get all bars
        Task<IEnumerable<Bar>> GetAllBars();

        //GET /bar/{id} - Get bar by Id
        Task<Bar> GetBarById(int BarId);
    }
}
