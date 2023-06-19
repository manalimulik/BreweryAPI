using BreweryAPI.Models;
using BreweryAPI.ResponseModel;
using Microsoft.EntityFrameworkCore;

namespace BreweryAPI.Services
{
    public class BarAndBeerInfoService : IBarAndBeerInfoService
    {
        private readonly DataContext _appDBContext;
        private ILogger _logger;
        public BarAndBeerInfoService(DataContext context, ILogger logger)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }
        public async Task<IEnumerable<BarAndBeerInfoResponse>> GetBarAndBeerInfo()
        {
            try
            {
                var listofdata = (from bb in _appDBContext.BarAndBeerInfo
                                  join br in _appDBContext.Bar
                                  on bb.BarId equals br.BarId
                                  join b in _appDBContext.Beer
                                  on bb.BeerId equals b.BeerId
                                  select new BarAndBeerInfoResponse
                                  {
                                      BarAndBeerInfoId = bb.BarAndBeerInfoId,
                                      BarName = br.BarName,
                                      BeerName = b.BeerName,
                                      BeerId = b.BeerId,
                                      BarId = bb.BarId,

                                  }).OrderBy(ow => ow.BarAndBeerInfoId).ToListAsync();
                return await listofdata;


            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BarAndBeerInfoResponse> GetBarAndBeerInfoById(int BeerId)
        {
            BarAndBeerInfoResponse objBarAndBeerInfo = new BarAndBeerInfoResponse();
            try
            {
                if (BeerId != 0)
                {
                    objBarAndBeerInfo = await (from bb in _appDBContext.BarAndBeerInfo
                                               join br in _appDBContext.Bar
                                               on bb.BarId equals br.BarId
                                               join b in _appDBContext.Beer
                                               on bb.BeerId equals b.BeerId
                                               where bb.BeerId == BeerId
                                               select new BarAndBeerInfoResponse
                                               {
                                                   BarAndBeerInfoId = bb.BarAndBeerInfoId,
                                                   BarName = br.BarName,
                                                   BeerName = b.BeerName,
                                                   BeerId = bb.BeerId,
                                                   BarId = bb.BarId,

                                               }).FirstOrDefaultAsync();
                    
                    if (objBarAndBeerInfo == null)
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
            return  objBarAndBeerInfo;
        }

        public async Task<BarAndBeerInfo> InsertBarAndBeerInfo(BarAndBeerInfo objBarAndBeerInfo)
        {
            try
            {
                if (objBarAndBeerInfo == null)
                {
                    _logger.LogError("Model is empty");
                    throw new Exception("Model does not contain any data");
                }
                else
                {
                    _appDBContext.BarAndBeerInfo.Add(objBarAndBeerInfo);
                    await _appDBContext.SaveChangesAsync();
                }

            }
            catch
            {
                throw;
            }
            return objBarAndBeerInfo;
        }
    }
}
