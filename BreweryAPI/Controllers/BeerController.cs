using BreweryAPI.Models;
using BreweryAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreweryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private ILogger _logger;
        private readonly IBeerService _beerService;
        public BeerController(IBeerService beerService, ILogger logger)
        {
            _beerService = beerService ??
                throw new ArgumentNullException(nameof(beerService));
            _logger = logger;
        }

        // GET: api/<BeerController>
        [HttpGet]
        [Route("/beer")]
        public IActionResult Get()
        {
            try
            {
                IList<Beer> beers = new List<Beer>();
                var result = _beerService.GetBeer();
                if (result.Exception == null)
                {
                    _logger.LogInformation($"Returned all beers from database.");
                    beers = result.Result.ToList();
                }
                else
                {
                    _logger.LogError($"Something went wrong inside GetAllBreweries action: {result.Exception.InnerException}");
                    return BadRequest($"{result.Exception.InnerException}");
                }

                return Ok(beers);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllBreweries action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<BeerController>/5
        [HttpGet]
        [Route("/beer/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Beer beer = new Beer();
                var result = _beerService.GetBeerById(id);
                if (result.Exception == null)
                {
                    _logger.LogInformation($"Returned beer by id from database.");
                    beer = result.Result;
                }
                else
                {
                    _logger.LogError($"Something went wrong inside GetBeerById action: {result.Exception.InnerException}");
                    return BadRequest($"{result.Exception.InnerException}");
                }

                return Ok(beer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetBeerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/<BeerController>
        [HttpPost]
        [Route("/beer")]
        public IActionResult Post(Beer objBeer)
        {
            try
            {
                Beer beer = new Beer();
                var result = _beerService.InsertBeer(objBeer);
                if (result.Exception == null)
                {
                    _logger.LogInformation($"inserted beer in database.");
                    beer = result.Result;
                }
                else
                {
                    _logger.LogError($"Something went wrong inside InsertBeer action: {result.Exception.InnerException}");
                    return BadRequest($"{result.Exception.InnerException}");
                }

                return Ok(beer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside InsertBeer action: {ex.Message}");
                return StatusCode(500, $"Internal server error :{ex.Message}");
            }
        }

        // PUT api/<BeerController>/5
        [HttpPut]
        [Route("/beer/{id}")]
        public IActionResult Put(int id, Beer objBeer)
        {
            try
            {
                Beer beer = new Beer();
                var result = _beerService.UpdateBeerById(id, objBeer);
                if (result.Exception == null)
                {
                    _logger.LogInformation($"Updated beer in database.");
                    beer = result.Result;
                }
                else
                {
                    _logger.LogError($"Something went wrong inside UpdateBeerById action: {result.Exception.InnerException}");
                    return BadRequest($"{result.Exception.InnerException}");
                }

                return Ok(objBeer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateBeerById action: {ex.Message}");
                return StatusCode(500, $"Internal server error :{ex.Message}");
            }
        }

    }
}
