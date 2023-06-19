

using BreweryAPI.Controllers;
using BreweryAPI.Models;
using BreweryAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BreweryApiTestProject
{
    [TestClass]
    public class BeerControllerTest
    {
        private readonly BeerController _controller;
        private readonly IBeerService _service;

        public BeerControllerTest()
        {
            _service = new BeerServiceMock();
            var mockLogger = new Mock<ILogger>();
            _controller = new BeerController(_service, mockLogger.Object);
        }
        [TestMethod]
       
        public void Get_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = _controller.Get();
            //Assert
            Assert.IsNotNull(okResult);
            Assert.IsInstanceOfType<OkObjectResult>(okResult);
        }

        [TestMethod]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
          
            // Act
            var okResult = _controller.Get(1);
            // Assert
            Assert.IsInstanceOfType<OkObjectResult>(okResult as OkObjectResult);
        }

        [TestMethod]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Beer testItem = new Beer()
            {
                BeerId = 1,
                BeerName = "Guinness",
                PercentageAlchoholByVolume = 12.00M
            };
            // Act
            var createdResponse = _controller.Post(testItem);
            // Assert
            Assert.IsInstanceOfType<OkObjectResult>(createdResponse as OkObjectResult);
        }
      


    }

    internal class BeerServiceMock : IBeerService
    {
        private readonly List<Beer> _beer;
        public BeerServiceMock()
        {
            _beer = new List<Beer>()
            {
                new Beer() { BeerId = 1, BeerName = "test", PercentageAlchoholByVolume = 6.5M },
                new Beer() { BeerId = 2, BeerName = "test1", PercentageAlchoholByVolume = 7.5M },
                new Beer() { BeerId = 3, BeerName = "test2", PercentageAlchoholByVolume = 10.5M }
            };
        }

        public Task<IEnumerable<Beer>> GetBeer(double gtAlcoholByVolume = 5, double ltAlcoholByVolume = 8)
        {
            return Task.FromResult<IEnumerable<Beer>>(_beer); 
        }

        public Task<Beer> GetBeerById(int BeerId)
        {
                return Task.FromResult<Beer>(_beer.Where(a => a.BeerId == BeerId).FirstOrDefault());
        }

        public Task<Beer> InsertBeer(Beer objBeer)
        {
            objBeer.BeerId = 1;
            objBeer.BeerName = "test";
            objBeer.PercentageAlchoholByVolume = 5.0M;
           _beer.Add(objBeer);
            return Task.FromResult<Beer>(objBeer);
        }

        public Task<Beer> UpdateBeerById(int BeerId, Beer objBeer)
        {
            throw new NotImplementedException();
        }
    }
}
