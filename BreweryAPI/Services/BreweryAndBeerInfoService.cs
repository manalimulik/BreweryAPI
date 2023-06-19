using BreweryAPI.Models;
using BreweryAPI.ResponseModel;
using Microsoft.EntityFrameworkCore;

namespace BreweryAPI.Services
{
    public class BreweryAndBeerInfoService : IBreweryAndBeerInfoService
    {
        private readonly DataContext _appDBContext;
        private ILogger _logger;
        public BreweryAndBeerInfoService(DataContext context, ILogger logger)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }
        public async Task<IEnumerable<BreweryAndBeerInfoResponse>> GetBreweryAndBeerInfo()
        {
            try
            {
                var listofdata = (from bb in _appDBContext.BreweryAndBeerInfo
                                  join br in _appDBContext.Brewery
                                  on bb.BreweryId equals br.BreweryId
                                  join b in _appDBContext.Beer
                                  on bb.BeerId equals b.BeerId
                                  select new BreweryAndBeerInfoResponse
                                  {
                                      BreweryAndBeerInfoId = bb.BreweryAndBeerInfoId,
                                      BreweryName = br.BreweryName,
                                      BeerName = b.BeerName,
                                      BeerId = bb.BeerId,
                                      BreweryId =bb.BreweryId,
                                      
                                  }).OrderBy(ow => ow.BreweryAndBeerInfoId).ToListAsync();
                return await listofdata;


            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BreweryAndBeerInfoResponse> GetBreweryAndBeerInfoById(int BreweryId)
        {
            BreweryAndBeerInfoResponse breweryAndBeerInfo = new BreweryAndBeerInfoResponse();
            try
            {
                if (BreweryId != 0)
                {
                    breweryAndBeerInfo = await (from bb in _appDBContext.BreweryAndBeerInfo
                                                join br in _appDBContext.Brewery
                                                on bb.BreweryId equals br.BreweryId
                                                join b in _appDBContext.Beer
                                                on bb.BeerId equals b.BeerId
                                                where bb.BreweryId == BreweryId
                                                select new BreweryAndBeerInfoResponse
                                                {
                                                    BreweryAndBeerInfoId = bb.BreweryAndBeerInfoId,
                                                    BreweryName = br.BreweryName,
                                                    BeerName = b.BeerName,
                                                    BeerId = bb.BeerId,
                                                    BreweryId = bb.BreweryId,

                                                }).FirstOrDefaultAsync(); 
                    if (breweryAndBeerInfo == null)
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
            return breweryAndBeerInfo;
        }

        public async Task<BreweryAndBeerInfo> InsertBreweryAndBeerInfo(BreweryAndBeerInfo objBreweryAndBeerInfo)
        {
            try
            {
                if (objBreweryAndBeerInfo == null)
                {
                    _logger.LogError("Model is empty");
                    throw new Exception("Model does not contain any data");
                }
                else
                {
                    _appDBContext.BreweryAndBeerInfo.Add(objBreweryAndBeerInfo);
                    await _appDBContext.SaveChangesAsync();
                }

            }
            catch
            {
                throw;
            }
            return objBreweryAndBeerInfo;
        }
    }
}
