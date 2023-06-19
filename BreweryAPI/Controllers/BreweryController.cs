using BreweryAPI.Models;
using BreweryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BreweryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweryController : ControllerBase
    {
        private ILogger _logger;
        private readonly IBreweryService _breweryService;

        public BreweryController(IBreweryService breweryService, ILogger logger)
        {
            _breweryService = breweryService ??
                throw new ArgumentNullException(nameof(breweryService));
            _logger = logger;
        }

        // GET: /brewery - Get all breweries
        [HttpGet]
        [Route("/brewery")]
        public IActionResult Get()
        {
            try
            {
                IList<Brewery> breweries = new List<Brewery>();
                var result = _breweryService.GetAllBreweries();
                if (result.Exception == null)
                {
                    _logger.LogInformation($"Returned all breweries from database.");
                    breweries = result.Result.ToList();
                }
                else
                {
                    _logger.LogError($"Something went wrong inside GetAllBreweries action: {result.Exception.InnerException}");
                    return BadRequest($"{result.Exception.InnerException}");
                }

                return Ok(breweries);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllBreweries action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET /brewery/{id} - Get brewery by Id
        [HttpGet]
        [Route("/brewery/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Brewery breweries = new Brewery();
                var result = _breweryService.GetBreweryById(id);
                if (result.Exception == null)
                {
                    _logger.LogInformation($"Returned brewery by id from database.");
                    breweries = result.Result;
                }
                else
                {
                    _logger.LogError($"Something went wrong inside GetAllBreweries action: {result.Exception.InnerException}");
                    return BadRequest($"{result.Exception.InnerException}");
                }

                return Ok(breweries);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllBreweries action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST /brewery - Insert a single brewery
        [HttpPost]
        [Route("/brewery")]
        public IActionResult Post(Brewery objBrewery)
        {
            try
            {
                Brewery breweries = new Brewery();
                var result = _breweryService.InsertBrewery(objBrewery);
                if (result.Exception == null)
                {
                    _logger.LogInformation($"inserted breweries in database.");
                    breweries = result.Result;
                }
                else
                {
                    _logger.LogError($"Something went wrong inside InsertBrewery action: {result.Exception.InnerException}");
                    return BadRequest($"{result.Exception.InnerException}");
                }
               
                return Ok(breweries);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside InsertBrewery action: {ex.Message}");
                return StatusCode(500, $"Internal server error :{ex.Message}");
            }
        }

        // PUT /brewery/{id} - Update a brewery by Id
        [HttpPut]
        [Route("/brewery/{id}")]
        public IActionResult Put(int id, Brewery objBrewery)
        {
            try
            {
                Brewery breweries = new Brewery();
                var result = _breweryService.UpdateBreweryById(id,objBrewery);
                if (result.Exception == null)
                {
                    _logger.LogInformation($"Updated breweries in database.");
                    breweries = result.Result;
                }
                else
                {
                    _logger.LogError($"Something went wrong inside InsertBrewery action: {result.Exception.InnerException}");
                    return BadRequest($"{result.Exception.InnerException}");
                }

                return Ok(breweries);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside InsertBrewery action: {ex.Message}");
                return StatusCode(500, $"Internal server error :{ex.Message}");
            }
        }

       
    }
}
