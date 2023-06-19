using BreweryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryAPI.Services
{
    public class BarService : IBarService
    {
        private readonly DataContext _appDBContext;
        private ILogger _logger;
        public BarService(DataContext context, ILogger logger)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }
        public async Task<IEnumerable<Bar>> GetAllBars()
        {
            try
            {
                return await _appDBContext.Bar
                    .OrderBy(ow => ow.BarId)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Bar> GetBarById(int BarId)
        {
            Bar bar = new Bar();
            try
            {
                if (BarId != 0)
                {
                    bar = await _appDBContext.Bar.FindAsync(BarId);
                    if (bar == null)
                    {
                        throw new Exception($"BarId does not exists in Database");
                    }
                }
                else
                {
                    _logger.LogError($"BarId should not be zero");
                    throw new Exception("BarId should not be zero");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return bar;
        }

        public async Task<Bar> InsertBar(Bar objBar)
        {
            try
            {
                if (objBar == null)
                {
                    _logger.LogError("Model is empty");
                    throw new Exception("Model does not contain any data");
                }
                else
                {
                    _appDBContext.Bar.Add(objBar);
                    await _appDBContext.SaveChangesAsync();
                }

            }
            catch
            {
                throw;
            }
            return objBar;
        }

        public async Task<Bar> UpdateBarById(int BarId, Bar objBar)
        {
            try
            {
                if (BarId != objBar.BarId)
                {
                    _logger.LogError($"BarId is not matching");
                    throw new Exception("BarId is not matching");
                }
                var barToUpdate = await GetBarById(BarId);
                if (barToUpdate != null)
                {
                    barToUpdate.BarName = objBar.BarName;
                    barToUpdate.BarAddress = objBar.BarAddress;
                    await _appDBContext.SaveChangesAsync();
                }
                else
                {
                    _logger.LogError($"Bar with Id = {BarId} not found");
                    throw new Exception($"Bar with Id = {BarId} not found");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return objBar;
        }
    }
}
