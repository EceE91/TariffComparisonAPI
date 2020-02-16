using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using TariffComparisonAPI.Controllers;
using Xunit;

namespace TariffComparisonAPI.UnitTest
{
    public class TariffComparisonTest_ForList
    {
        [Fact]
        public void TariffComparison_ReturnsJsonResult_WithAListOfProducts()
        {               
            // Arrange
            var mockRepo = new Mock<ITariffComparisonStrategy>();
            var mockLogger = new Mock<ILogger<TariffComparisonController>>();

            mockRepo.Setup(repo => repo.ListTariffComparison(3500))
                .Returns(GetTestTariffComparisonProducts());
            var controller = new TariffComparisonController(mockLogger.Object,mockRepo.Object);

            // Act
            var result = controller.GetTariffComparisons(3500) as ActionResult<IEnumerable<IProduct>>;
            
            // Assert
            var res = Assert.IsType<Microsoft.AspNetCore.Mvc.ActionResult<IEnumerable<IProduct>>>(result);
            var model = Assert.IsAssignableFrom<List<IProduct>>(res.Value);

            foreach (var item in res.Value)
            {
                if(item.Type == ProductType.ProductA)
                    Assert.Equal(830, item.AnnualCost);
                if (item.Type == ProductType.ProductB)
                    Assert.Equal(800, item.AnnualCost);
            }
            Assert.Equal(2, model.Count);
        }

        private IList<IProduct> GetTestTariffComparisonProducts()
        {
            IList<IProduct> results = new List<IProduct>() {
                    new ProductA()
                    {
                        TariffName = "basic electricity tariff",
                        AnnualCost=830
                    },
                    new ProductB()
                    {
                       TariffName = "Packaged tariff",
                       AnnualCost=800
                    }
            };

            return results;
        }
    }
}
