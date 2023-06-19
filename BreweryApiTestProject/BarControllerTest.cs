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
    public class BarControllerTest
    {
        private readonly BarController _controller;
        private readonly IBarService _service;

        public BarControllerTest()
        {
            _service = new BarServiceMock();
            var mockLogger = new Mock<ILogger>();
            _controller = new BarController(_service, mockLogger.Object);
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
            Bar testItem = new Bar()
            {
                BarId = 1,
                BarName = "Guinness",
                BarAddress = "test"
            };
            // Act
            var createdResponse = _controller.Post(testItem);
            // Assert
            Assert.IsInstanceOfType<OkObjectResult>(createdResponse as OkObjectResult);
        }
    }

    internal class BarServiceMock : IBarService
    {
        private readonly List<Bar> _bar;
        public BarServiceMock()
        {
            _bar = new List<Bar>()
            {
                new Bar() { BarId = 1, BarName = "test", BarAddress = "mumbai" },
                new Bar() { BarId = 2, BarName = "test1", BarAddress = "delhi" },
                new Bar() { BarId = 3, BarName = "test2", BarAddress = "goa" }
            };
        }
        public Task<IEnumerable<Bar>> GetAllBars()
        {
            return Task.FromResult<IEnumerable<Bar>>(_bar);
        }

        public Task<Bar> GetBarById(int BarId)
        {
            return Task.FromResult<Bar>(_bar.Where(a => a.BarId == BarId).FirstOrDefault());
        }

        public Task<Bar> InsertBar(Bar objBar)
        {
            objBar.BarId = 1;
            objBar.BarName = "test";
            objBar.BarAddress = "mumbai";
            _bar.Add(objBar);
            return Task.FromResult<Bar>(objBar);
        }

        public Task<Bar> UpdateBarById(int BarId, Bar objBar)
        {
            throw new NotImplementedException();
        }
    }
}
