using BreweryAPI.Models;
using BreweryAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreweryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarController : ControllerBase
    {
        private ILogger _logger;
        private readonly IBarService _barService;

        public BarController(IBarService barService, ILogger logger)
        {
            _barService = barService ??
                throw new ArgumentNullException(nameof(barService));
            _logger = logger;
        }

        // GET: /bar - Get all bars
        [HttpGet]
        [Route("/bar")]
        public IActionResult Get()
        {
            try
            {
                IList<Bar> bars = new List<Bar>();
                var result = _barService.GetAllBars();
                if (result.Exception == null)
                {
                    _logger.LogInformation($"Returned all bars from database.");
                    bars = result.Result.ToList();
                }
                else
                {
                    _logger.LogError($"Something went wrong inside GetAllBreweries action: {result.Exception.InnerException}");
                    return BadRequest($"{result.Exception.InnerException}");
                }

                return Ok(bars);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllBreweries action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET /bar/{id} - Get bar by Id
        [HttpGet]
        [Route("/bar/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Bar bar = new Bar();
                var result = _barService.GetBarById(id);
                if (result.Exception == null)
                {
                    _logger.LogInformation($"Returned bar by id from database.");
                    bar = result.Result;
                }
                else
                {
                    _logger.LogError($"Something went wrong inside GetAllBreweries action: {result.Exception.InnerException}");
                    return BadRequest($"{result.Exception.InnerException}");
                }

                return Ok(bar);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllBreweries action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST /bar - Insert a single bar
        [HttpPost]
        [Route("/bar")]
        public IActionResult Post(Bar objBar)
        {
            try
            {
                Bar bar = new Bar();
                var result = _barService.InsertBar(objBar);
                if (result.Exception == null)
                {
                    _logger.LogInformation($"inserted bar in database.");
                    bar = result.Result;
                }
                else
                {
                    _logger.LogError($"Something went wrong inside InsertBrewery action: {result.Exception.InnerException}");
                    return BadRequest($"{result.Exception.InnerException}");
                }

                return Ok(bar);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside InsertBrewery action: {ex.Message}");
                return StatusCode(500, $"Internal server error :{ex.Message}");
            }
        }

        // PUT /bar/{id} - Update a bar by Id
        [HttpPut]
        [Route("/bar/{id}")]
        public IActionResult Put(int id, Bar objBar)
        {
            try
            {
                Bar bar = new Bar();
                var result = _barService.UpdateBarById(id, objBar);
                if (result.Exception == null)
                {
                    _logger.LogInformation($"Updated bar in database.");
                    bar = result.Result;
                }
                else
                {
                    _logger.LogError($"Something went wrong inside InsertBrewery action: {result.Exception.InnerException}");
                    return BadRequest($"{result.Exception.InnerException}");
                }

                return Ok(bar);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside InsertBrewery action: {ex.Message}");
                return StatusCode(500, $"Internal server error :{ex.Message}");
            }
        }

       
    }
}
