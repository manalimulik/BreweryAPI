using BreweryAPI.Models;
using BreweryAPI.ResponseModel;
using BreweryAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreweryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarAndBeersController : ControllerBase
    {
        private ILogger _logger;
        private readonly IBarAndBeerInfoService _barAndBeerInfoService;
        public BarAndBeersController(IBarAndBeerInfoService barAndBeerInfoService, ILogger logger)
        {
            _barAndBeerInfoService = barAndBeerInfoService ??
                throw new ArgumentNullException(nameof(barAndBeerInfoService));
            _logger = logger;
        }

        // GET: api/<BarAndBeersController>
        [HttpGet]
        [Route("/bar/beer")]
        public IActionResult Get()
        {
            try
            {
                IList<BarAndBeerInfoResponse> barAndBeerInfos = new List<BarAndBeerInfoResponse>();
                var result = _barAndBeerInfoService.GetBarAndBeerInfo();
                if (result.Exception == null)
                {
                    _logger.LogInformation($"Returned all data from database.");
                    barAndBeerInfos = result.Result.ToList();
                }
                else
                {
                    _logger.LogError($"Something went wrong inside GetBarAndBeerInfo action: {result.Exception.InnerException}");
                    return BadRequest($"{result.Exception.InnerException}");
                }

                return Ok(barAndBeerInfos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetBarAndBeerInfo action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<BarAndBeersController>/5
        [HttpGet]
        [Route("/bar/{barId}/beer")]
        public IActionResult Get(int barId)
        {
            try
            {
                BarAndBeerInfoResponse barAndBeerInfo = new BarAndBeerInfoResponse();
                var result = _barAndBeerInfoService.GetBarAndBeerInfoById(barId);
                if (result.Exception == null)
                {
                    _logger.LogInformation($"Returned data by id from database.");
                    barAndBeerInfo = result.Result;
                }
                else
                {
                    _logger.LogError($"Something went wrong inside GetBarAndBeerInfoById action: {result.Exception.InnerException}");
                    return BadRequest($"{result.Exception.InnerException}");
                }

                return Ok(barAndBeerInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetBarAndBeerInfoById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/<BarAndBeersController>
        [HttpPost]
        [Route("/bar/beer")]
        public IActionResult Post(BarAndBeerInfo objBarAndBeerInfo)
        {
            try
            {
                BarAndBeerInfo barAndBeerInfo = new BarAndBeerInfo();
                var result = _barAndBeerInfoService.InsertBarAndBeerInfo(objBarAndBeerInfo);
                if (result.Exception == null)
                {
                    _logger.LogInformation($"inserted data in database.");
                    barAndBeerInfo = result.Result;
                }
                else
                {
                    _logger.LogError($"Something went wrong inside InsertBarAndBeerInfo action: {result.Exception.InnerException}");
                    return BadRequest($"{result.Exception.InnerException}");
                }

                return Ok(barAndBeerInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside InsertBarAndBeerInfo action: {ex.Message}");
                return StatusCode(500, $"Internal server error :{ex.Message}");
            }
        }
    }
}
