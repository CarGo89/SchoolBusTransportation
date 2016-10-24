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
    public class TutorControllerTest
    {
        [TestMethod]
        public void TutorControllerAddTest()
        {
            /*Arrange*/
            var mockSettings = new Mock<ISettingsManager>(MockBehavior.Strict);
            var mockUserInfo = new Mock<IUserInfo>(MockBehavior.Strict);
            var mockEntityRepository = new Mock<IEntityRepository<SchoolBus.DataAccess.Entities.Tutor>>(MockBehavior.Strict);
            var mockLogger = new Mock<ILogger>(MockBehavior.Strict);
            var mockTutor = new Mock<Tutor>(MockBehavior.Strict);
            var controller = new TutorController(mockSettings.Object, mockUserInfo.Object, mockEntityRepository.Object, mockLogger.Object);
            var expectedTutorRoleId = 5;

            mockSettings
                .SetupGet(settings => settings.TutorRoleId)
                .Returns(expectedTutorRoleId);

            mockTutor
                .SetupSet(tutor => tutor.UserRoleId = expectedTutorRoleId);

            mockTutor
                .SetupSet(tutor => tutor.IsValid = true);

            mockTutor
                .SetupGet(tutor => tutor.IsValid)
                .Returns(false);

            /*Act*/
            var actualResult = controller.Add(mockTutor.Object);

            /*Assert*/
            mockSettings.VerifyAll();
            mockSettings
                .VerifyGet(settings => settings.TutorRoleId, Times.Once);

            mockUserInfo.VerifyAll();
            mockEntityRepository.VerifyAll();
            mockLogger.VerifyAll();

            mockTutor.VerifyAll();
            mockTutor
                .VerifySet(tutor => tutor.UserRoleId = expectedTutorRoleId, Times.Once);
            mockTutor
                .VerifySet(tutor => tutor.IsValid = true, Times.Once);
            mockTutor
                .VerifyGet(tutor => tutor.IsValid, Times.Exactly(2));

            Assert.IsInstanceOfType(actualResult, typeof(JsonResult));
        }

        [TestMethod]
        public void TutorControllerUpdateTest()
        {
            /*Arrange*/
            var mockSettings = new Mock<ISettingsManager>(MockBehavior.Strict);
            var mockUserInfo = new Mock<IUserInfo>(MockBehavior.Strict);
            var mockEntityRepository = new Mock<IEntityRepository<SchoolBus.DataAccess.Entities.Tutor>>(MockBehavior.Strict);
            var mockLogger = new Mock<ILogger>(MockBehavior.Strict);
            var mockTutor = new Mock<Tutor>(MockBehavior.Strict);
            var controller = new TutorController(mockSettings.Object, mockUserInfo.Object, mockEntityRepository.Object, mockLogger.Object);
            var expectedTutorRoleId = 5;

            mockSettings
                .SetupGet(settings => settings.TutorRoleId)
                .Returns(expectedTutorRoleId);

            mockTutor
                .SetupSet(tutor => tutor.UserRoleId = expectedTutorRoleId);

            mockTutor
                .SetupSet(tutor => tutor.IsValid = true);

            mockTutor
                .SetupGet(tutor => tutor.IsValid)
                .Returns(false);

            /*Act*/
            var actualResult = controller.Update(mockTutor.Object);

            /*Assert*/
            mockSettings.VerifyAll();
            mockSettings
                .VerifyGet(settings => settings.TutorRoleId, Times.Once);

            mockUserInfo.VerifyAll();
            mockEntityRepository.VerifyAll();
            mockLogger.VerifyAll();

            mockTutor.VerifyAll();
            mockTutor
                .VerifySet(tutor => tutor.UserRoleId = expectedTutorRoleId, Times.Once);
            mockTutor
                .VerifySet(tutor => tutor.IsValid = true, Times.Once);
            mockTutor
                .VerifyGet(tutor => tutor.IsValid, Times.Exactly(2));

            Assert.IsInstanceOfType(actualResult, typeof(JsonResult));
        }

        [TestMethod]
        public void TutorControllerDeleteTest()
        {
            /*Arrange*/
            var mockSettings = new Mock<ISettingsManager>(MockBehavior.Strict);
            var mockUserInfo = new Mock<IUserInfo>(MockBehavior.Strict);
            var mockEntityRepository = new Mock<IEntityRepository<SchoolBus.DataAccess.Entities.Tutor>>(MockBehavior.Strict);
            var mockLogger = new Mock<ILogger>(MockBehavior.Strict);
            var mockTutor = new Mock<Tutor>(MockBehavior.Strict);
            var controller = new TutorController(mockSettings.Object, mockUserInfo.Object, mockEntityRepository.Object, mockLogger.Object);
            var expectedTutorRoleId = 5;

            mockSettings
                .SetupGet(settings => settings.TutorRoleId)
                .Returns(expectedTutorRoleId);

            mockTutor
                .SetupSet(tutor => tutor.UserRoleId = expectedTutorRoleId);

            mockTutor
                .SetupSet(tutor => tutor.IsValid = true);

            mockTutor
                .SetupGet(tutor => tutor.IsValid)
                .Returns(false);

            /*Act*/
            var actualResult = controller.Delete(mockTutor.Object);

            /*Assert*/
            mockSettings.VerifyAll();
            mockSettings
                .VerifyGet(settings => settings.TutorRoleId, Times.Once);

            mockUserInfo.VerifyAll();
            mockEntityRepository.VerifyAll();
            mockLogger.VerifyAll();

            mockTutor.VerifyAll();
            mockTutor
                .VerifySet(tutor => tutor.UserRoleId = expectedTutorRoleId, Times.Once);
            mockTutor
                .VerifySet(tutor => tutor.IsValid = true, Times.Once);
            mockTutor
                .VerifyGet(tutor => tutor.IsValid, Times.Exactly(2));

            Assert.IsInstanceOfType(actualResult, typeof(JsonResult));
        }
    }
}