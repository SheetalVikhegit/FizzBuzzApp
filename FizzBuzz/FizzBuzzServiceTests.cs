using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FizzBuzz.Controllers;
using FizzBuzz.Interfaces;
using Moq;

namespace FizzBuzz
{
    public class FizzBuzzControllerTests
    {
        [Fact]
        public void ProcessArray_ValidInput_ReturnsExpectedResults()
        {
            // Arrange
            var mockService = new Mock<IFizzBuzzService>();
            mockService.Setup(service => service.ProcessValue(3)).Returns("Fizz");
            mockService.Setup(service => service.ProcessValue(5)).Returns("Buzz");
            mockService.Setup(service => service.GetDivisionsPerformed()).Returns(new List<string> { "Divided 3 by 5" });

            var controller = new FizzBuzzController(mockService.Object);
            int[] input = { 3, 5 };

            // Act
            var result = controller.ProcessArray(input) as ActionResult<List<string>>;
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var resultList = Assert.IsType<List<string>>(okResult.Value);

            // Assert
            Assert.Equal(3, resultList.Count); // Expected: Fizz, Buzz, Divided 3 by 5
            Assert.Contains("Fizz", resultList);
            Assert.Contains("Buzz", resultList);
            Assert.Contains("Divided 3 by 5", resultList);
        }

        // Add more test cases for edge cases, error handling, etc.
    }
}
