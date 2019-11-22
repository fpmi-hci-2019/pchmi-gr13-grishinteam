using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using sitedigitalstore.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTest
{
	public class HomeControllersTests
	{
		[Fact]
		public void IndexViewDataMessage()
		{
			// Arrange
			var loggerMoc = new Mock<ILogger<HomeController>>();

			HomeController controller = new HomeController(loggerMoc.Object);

			// Act
			ViewResult result = controller.Index() as ViewResult;

			// Assert
			Assert.Equal("Hello!", result?.ViewData["Message"]);
		}

		[Fact]
		public void IndexViewResultNotNull()
		{
			// Arrange
			var loggerMoc = new Mock<ILogger<HomeController>>();

			HomeController controller = new HomeController(loggerMoc.Object);
			// Act
			ViewResult result = controller.Index() as ViewResult;
			// Assert
			Assert.NotNull(result);
		}
	}
}

