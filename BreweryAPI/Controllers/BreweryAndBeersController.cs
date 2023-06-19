using BreweryAPI.Models;
using BreweryAPI.ResponseModel;
using BreweryAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreweryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweryAndBeersController : ControllerBase
    {

        private ILogger _logger;
        private readonly IBreweryAndBeerInfoService _breweryAndBeerInfoService;
        public BreweryAndBeersController(IBreweryAndBeerInfoService breweryAndBeerInfoService, ILogger logger)
        {
            _breweryAndBeerInfoService = breweryAndBeerInfoService ??
                throw new ArgumentNullException(nameof(breweryAndBeerInfoService));
            _logger = logger;
        }

        // GET: api/<BreweryAndBeersController>
        [HttpGet]
        [Route("/brewery/beer")]
        public IActionResult Get()
        {
            try
            {
                IList<BreweryAndBeerInfoResponse> breweryAndBeerInfo = new List<BreweryAndBeerInfoResponse>();
                var result = _breweryAndBeerInfoService.GetBreweryAndBeerInfo();
                if (result.Exception == null)
                {
                    _logger.LogInformation($"Returned all data from database.");
                    breweryAndBeerInfo = result.Result.ToList();
                }
                else
                {
                    _logger.LogError($"Something went wrong inside GetBreweryAndBeerInfo action: {result.Exception.InnerException}");
                    return BadRequest($"{result.Exception.InnerException}");
                }

                return Ok(breweryAndBeerInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllBreweries action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<BreweryAndBeersController>/5
        [HttpGet]
        [Route("/brewery/{breweryId}/beer")]
        public IActionResult Get(int breweryId)
        {
            try
            {
                BreweryAndBeerInfoResponse breweryAndBeerInfo  = new BreweryAndBeerInfoResponse();
                var result = _breweryAndBeerInfoService.GetBreweryAndBeerInfoById(breweryId);
                if (result.Exception == null)
                {
                    _logger.LogInformation($"Returned data by id from database.");
                    breweryAndBeerInfo = result.Result;
                }
                else
                {
                    _logger.LogError($"Something went wrong inside GetBreweryAndBeerInfoById action: {result.Exception.InnerException}");
                    return BadRequest($"{result.Exception.InnerException}");
                }

                return Ok(breweryAndBeerInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetBreweryAndBeerInfoById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/<BreweryAndBeersController>
        [HttpPost]
        [Route("/brewery/beer")]
        public IActionResult Post(BreweryAndBeerInfo objBreweryAndBeerInfo)
        {
            try
            {
                BreweryAndBeerInfo breweryAndBeerInfo = new BreweryAndBeerInfo();
                var result = _breweryAndBeerInfoService.InsertBreweryAndBeerInfo(objBreweryAndBeerInfo);
                if (result.Exception == null)
                {
                    _logger.LogInformation($"inserted data in database.");
                    breweryAndBeerInfo = result.Result;
                }
                else
                {
                    _logger.LogError($"Something went wrong inside InsertBreweryAndBeerInfo action: {result.Exception.InnerException}");
                    return BadRequest($"{result.Exception.InnerException}");
                }

                return Ok(breweryAndBeerInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside InsertBreweryAndBeerInfo action: {ex.Message}");
                return StatusCode(500, $"Internal server error :{ex.Message}");
            }
        }

    }
}
