using BreweryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryAPI.Services
{
    public class BreweryService : IBreweryService
    {
        private readonly DataContext _appDBContext;
        private ILogger _logger;
        public BreweryService(DataContext context, ILogger logger)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }
        public async Task<IEnumerable<Brewery>> GetAllBreweries()
        {
            try
            {
                return await _appDBContext.Brewery
                    .OrderBy(ow => ow.BreweryId)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Brewery> GetBreweryById(int BreweryId)
        {

            Brewery brewery = new Brewery();
            try
            {
                if (BreweryId != 0)
                {
                    brewery = await _appDBContext.Brewery.FindAsync(BreweryId);
                    if (brewery == null)
                    {
                        throw new Exception($"BreweryId does not exists in Database");
                    }
                }
                else
                {
                    _logger.LogError($"BreweryId should not be zero");
                    throw new Exception("BreweryId should not be zero");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return brewery;
        }

        public async Task<Brewery> InsertBrewery(Brewery objBrewery)
        {
            try
            {
                if (objBrewery == null)
                {
                    _logger.LogError("Model is empty");
                    throw new Exception("Model does not contain any data");
                }
                else
                {
                    _appDBContext.Brewery.Add(objBrewery);
                    await _appDBContext.SaveChangesAsync();
                }

            }
            catch
            {
                throw;
            }
            return objBrewery;
        }

        public async Task<Brewery> UpdateBreweryById(int BreweryId, Brewery objBrewery)
        {
            try
            {
                if (BreweryId != objBrewery.BreweryId)
                {
                    _logger.LogError($"BreweryId is not matching");
                    throw new Exception("BreweryId is not matching");
                }
                var breweryToUpdate = await GetBreweryById(BreweryId);
                if (breweryToUpdate != null)
                {
                    breweryToUpdate.BreweryName = objBrewery.BreweryName;
                    await _appDBContext.SaveChangesAsync();
                }
                else
                {
                    _logger.LogError($"Brewery with Id = {BreweryId} not found");
                    throw new Exception($"Brewery with Id = {BreweryId} not found");

                }

            }
            catch (Exception)
            {
                throw;
            }

            return objBrewery;
        }
    }
}
