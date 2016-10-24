using System.Web.Mvc;
using Dpr.Core.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchoolBus.DataAccess.Repositories;
using SchoolBusWeb.Controllers;
using SchoolBusWeb.Models;
using SchoolBusWeb.Utilities;

namespace SchoolBusWeb.Tests.Controllers
{
    [TestClass]
    public class DriverControllerTest
    {
        [TestMethod]
        public void DriverControllerAddTest()
        {
            /*Arrange*/
            var mockSettings = new Mock<ISettingsManager>(MockBehavior.Strict);
            var mockUserInfo = new Mock<IUserInfo>(MockBehavior.Strict);
            var mockEntityRepository = new Mock<IEntityRepository<SchoolBus.DataAccess.Entities.Driver>>(MockBehavior.Strict);
            var mockLogger = new Mock<ILogger>(MockBehavior.Strict);
            var mockDriver = new Mock<Driver>(MockBehavior.Strict);
            var controller = new DriverController(mockSettings.Object, mockUserInfo.Object, mockEntityRepository.Object, mockLogger.Object);
            var expectedDriverRoleId = 5;

            mockSettings
                .SetupGet(settings => settings.DriverRoleId)
                .Returns(expectedDriverRoleId);

            mockDriver
                .SetupSet(driver => driver.UserRoleId = expectedDriverRoleId);

            mockDriver
                .SetupSet(driver => driver.IsValid = true);

            mockDriver
                .SetupGet(driver => driver.IsValid)
                .Returns(false);

            /*Act*/
            var actualResult = controller.Add(mockDriver.Object);

            /*Assert*/
            mockSettings.VerifyAll();
            mockSettings
                .VerifyGet(settings => settings.DriverRoleId, Times.Once);

            mockUserInfo.VerifyAll();
            mockEntityRepository.VerifyAll();
            mockLogger.VerifyAll();

            mockDriver.VerifyAll();
            mockDriver
                .VerifySet(driver => driver.UserRoleId = expectedDriverRoleId, Times.Once);
            mockDriver
                .VerifySet(driver => driver.IsValid = true, Times.Once);
            mockDriver
                .VerifyGet(driver => driver.IsValid, Times.Exactly(2));

            Assert.IsInstanceOfType(actualResult, typeof(JsonResult));
        }

        [TestMethod]
        public void DriverControllerUpdateTest()
        {
            /*Arrange*/
            var mockSettings = new Mock<ISettingsManager>(MockBehavior.Strict);
            var mockUserInfo = new Mock<IUserInfo>(MockBehavior.Strict);
            var mockEntityRepository = new Mock<IEntityRepository<SchoolBus.DataAccess.Entities.Driver>>(MockBehavior.Strict);
            var mockLogger = new Mock<ILogger>(MockBehavior.Strict);
            var mockDriver = new Mock<Driver>(MockBehavior.Strict);
            var controller = new DriverController(mockSettings.Object, mockUserInfo.Object, mockEntityRepository.Object, mockLogger.Object);
            var expectedDriverRoleId = 5;

            mockSettings
                .SetupGet(settings => settings.DriverRoleId)
                .Returns(expectedDriverRoleId);

            mockDriver
                .SetupSet(driver => driver.UserRoleId = expectedDriverRoleId);

            mockDriver
                .SetupSet(driver => driver.IsValid = true);

            mockDriver
                .SetupGet(driver => driver.IsValid)
                .Returns(false);

            /*Act*/
            var actualResult = controller.Update(mockDriver.Object);

            /*Assert*/
            mockSettings.VerifyAll();
            mockSettings
                .VerifyGet(settings => settings.DriverRoleId, Times.Once);

            mockUserInfo.VerifyAll();
            mockEntityRepository.VerifyAll();
            mockLogger.VerifyAll();

            mockDriver.VerifyAll();
            mockDriver
                .VerifySet(driver => driver.UserRoleId = expectedDriverRoleId, Times.Once);
            mockDriver
                .VerifySet(driver => driver.IsValid = true, Times.Once);
            mockDriver
                .VerifyGet(driver => driver.IsValid, Times.Exactly(2));

            Assert.IsInstanceOfType(actualResult, typeof(JsonResult));
        }

        [TestMethod]
        public void DriverControllerDeleteTest()
        {
            /*Arrange*/
            var mockSettings = new Mock<ISettingsManager>(MockBehavior.Strict);
            var mockUserInfo = new Mock<IUserInfo>(MockBehavior.Strict);
            var mockEntityRepository = new Mock<IEntityRepository<SchoolBus.DataAccess.Entities.Driver>>(MockBehavior.Strict);
            var mockLogger = new Mock<ILogger>(MockBehavior.Strict);
            var mockDriver = new Mock<Driver>(MockBehavior.Strict);
            var controller = new DriverController(mockSettings.Object, mockUserInfo.Object, mockEntityRepository.Object, mockLogger.Object);
            var expectedDriverRoleId = 5;

            mockSettings
                .SetupGet(settings => settings.DriverRoleId)
                .Returns(expectedDriverRoleId);

            mockDriver
                .SetupSet(driver => driver.UserRoleId = expectedDriverRoleId);

            mockDriver
                .SetupSet(driver => driver.IsValid = true);

            mockDriver
                .SetupGet(driver => driver.IsValid)
                .Returns(false);

            /*Act*/
            var actualResult = controller.Delete(mockDriver.Object);

            /*Assert*/
            mockSettings.VerifyAll();
            mockSettings
                .VerifyGet(settings => settings.DriverRoleId, Times.Once);

            mockUserInfo.VerifyAll();
            mockEntityRepository.VerifyAll();
            mockLogger.VerifyAll();

            mockDriver.VerifyAll();
            mockDriver
                .VerifySet(driver => driver.UserRoleId = expectedDriverRoleId, Times.Once);
            mockDriver
                .VerifySet(driver => driver.IsValid = true, Times.Once);
            mockDriver
                .VerifyGet(driver => driver.IsValid, Times.Exactly(2));

            Assert.IsInstanceOfType(actualResult, typeof(JsonResult));
        }
    }
}