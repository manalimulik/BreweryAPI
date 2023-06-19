using BreweryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryAPI.Services
{
    public class BeerService : IBeerService
    {
        private readonly DataContext _appDBContext;
        private ILogger _logger;
        public BeerService(DataContext context, ILogger logger)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }
        public async Task<IEnumerable<Beer>> GetBeer(double gtAlcoholByVolume = 5.0, double ltAlcoholByVolume = 8.0)
        {
            try
            {
                return await _appDBContext.Beer
                    .Where(m => m.PercentageAlchoholByVolume > Convert.ToDecimal(gtAlcoholByVolume) && m.PercentageAlchoholByVolume < Convert.ToDecimal(ltAlcoholByVolume))
                    .OrderBy(ow => ow.BeerId)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Beer> GetBeerById(int BeerId)
        {
            Beer beer = new Beer();
            try
            {
                if (BeerId != 0)
                {
                    beer = await _appDBContext.Beer.FindAsync(BeerId);
                    if (beer == null)
                    {
                        throw new Exception($"BeerId does not exists in Database");
                    }
                }
                else
                {
                    _logger.LogError($"BeerId should not be zero");
                    throw new Exception("BeerId should not be zero");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return beer; 
        }

        public async Task<Beer> InsertBeer(Beer objBeer)
        {
            try
            {
                if (objBeer == null)
                {
                    _logger.LogError("Model is empty");
                    throw new Exception("Model does not contain any data");
                }
                else
                {
                    _appDBContext.Beer.Add(objBeer);
                    await _appDBContext.SaveChangesAsync();
                }

            }
            catch
            {
                throw;
            }
            return objBeer;
        }

        public async Task<Beer> UpdateBeerById(int BeerId, Beer objBeer)
        {
            try
            {
                if (BeerId != objBeer.BeerId)
                {
                    _logger.LogError($"BeerId is not matching");
                    throw new Exception("BeerId is not matching");
                }
                var beerToUpdate = await GetBeerById(BeerId);
                if (beerToUpdate != null)
                {
                    beerToUpdate.BeerName = objBeer.BeerName;
                    beerToUpdate.PercentageAlchoholByVolume = objBeer.PercentageAlchoholByVolume;
                    await _appDBContext.SaveChangesAsync();
                }
                else
                {
                    _logger.LogError($"Beer with Id = {BeerId} not found");
                    throw new Exception($"Beer with Id = {BeerId} not found");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return objBeer;

        }
    }
}
