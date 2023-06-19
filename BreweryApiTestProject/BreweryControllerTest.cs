using BreweryAPI.Controllers;
using BreweryAPI.Models;
using BreweryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryApiTestProject
{
    [TestClass]
    public class BreweryControllerTest
    {
        private readonly BreweryController _controller;
        private readonly IBreweryService _service;

        public BreweryControllerTest()
        {
            _service = new BreweryServiceMock();
            var mockLogger = new Mock<ILogger>();
            _controller = new BreweryController(_service, mockLogger.Object);
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
            Brewery testItem = new Brewery()
            {
                BreweryId = 1,
                BreweryName = "Guinness",
            };
            // Act
            var createdResponse = _controller.Post(testItem);
            // Assert
            Assert.IsInstanceOfType<OkObjectResult>(createdResponse as OkObjectResult);
        }
    }

    internal class BreweryServiceMock : IBreweryService
    {
        private readonly List<Brewery> _brewery;
        public BreweryServiceMock()
        {
            _brewery = new List<Brewery>()
            {
                new Brewery() { BreweryId = 1, BreweryName = "test" },
                new Brewery() { BreweryId = 2, BreweryName = "test1" },
                new Brewery() { BreweryId = 3, BreweryName = "test2" }
            };
        }
        public Task<IEnumerable<Brewery>> GetAllBreweries()
        {
            return Task.FromResult<IEnumerable<Brewery>>(_brewery);
        }

        public Task<Brewery> GetBreweryById(int BreweryId)
        {
            return Task.FromResult<Brewery>(_brewery.Where(a => a.BreweryId == BreweryId).FirstOrDefault());
        }

        public Task<Brewery> InsertBrewery(Brewery objBrewery)
        {
            objBrewery.BreweryId = 1;
            objBrewery.BreweryName = "test";

            _brewery.Add(objBrewery);
            return Task.FromResult<Brewery>(objBrewery);
        }

        public Task<Brewery> UpdateBreweryById(int BreweryId, Brewery objBrewery)
        {
            throw new NotImplementedException();
        }
    }
}
