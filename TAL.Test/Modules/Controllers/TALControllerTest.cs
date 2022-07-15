
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTAL.Controllers;
using TestTAL.Models;
using Xunit;

namespace TAL.Test.Modules.Controllers
{
    public class TALControllerTest
    {
        private readonly TALController _controller;
        private readonly PremiumServiceFake _service;
        private readonly ILogger<TALController> _logger;

        public TALControllerTest()
        {
            _service = new PremiumServiceFake();
            _controller = new TALController(_logger,_service);
        }

        [Fact]
        public async Task Get_OccupationsReturnsAllItems()
        {
            // Act
            var response = await _controller.GetOccupationsAsync();
            List<Occupation> occupationList;

            // Assert.IsTrue(response.TryGetContentValue<List<Occupation>>(out occupationList));
            //    // Assert
            // var items = Assert.IsType<List<Occupation>>(okResult.Value);
            Assert.AreEqual(3, response.Value.Count);
        }
    }
}
