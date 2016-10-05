using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Dpr.Core.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchoolBus.DataAccess.Repositories;
using SchoolBusWeb.Tests.Models;
using SchoolBusWeb.Utilities;

namespace SchoolBusWeb.Tests.Controllers
{
    [TestClass]
    public class ModelControllerBaseTest
    {
        [TestMethod]
        public void ModelControllerBaseInitTest()
        {
            /*Arrange*/
            var mockUserInfo = new Mock<IUserInfo>(MockBehavior.Strict);
            var mockEntityRepository = new Mock<IEntityRepository<TestEntity>>(MockBehavior.Strict);
            var mockLogger = new Mock<ILogger>(MockBehavior.Strict);

            mockEntityRepository
                .Setup(repository => repository.Dispose());

            /*Act*/
            using (new ModelController(mockUserInfo.Object, mockEntityRepository.Object, mockLogger.Object))
            {
            }

            /*Assert*/
            mockUserInfo.VerifyAll();

            mockEntityRepository.VerifyAll();
            mockEntityRepository
                .Verify(repository => repository.Dispose(), Times.Once);

            mockLogger.VerifyAll();
        }

        [TestMethod]
        public void ModelControllerBaseIndexTest()
        {
            /*Arrange*/
            var mockUserInfo = new Mock<IUserInfo>(MockBehavior.Strict);
            var mockEntityRepository = new Mock<IEntityRepository<TestEntity>>(MockBehavior.Strict);
            var mockLogger = new Mock<ILogger>(MockBehavior.Strict);
            ActionResult actualActionResult;

            mockEntityRepository
                .Setup(repository => repository.Dispose());

            /*Act*/
            using (var controller = new ModelController(mockUserInfo.Object, mockEntityRepository.Object, mockLogger.Object))
            {
                actualActionResult = controller.Index();
            }

            /*Assert*/
            mockUserInfo.VerifyAll();

            mockEntityRepository.VerifyAll();
            mockEntityRepository
                .Verify(repository => repository.Dispose(), Times.Once);

            mockLogger.VerifyAll();

            Assert.IsInstanceOfType(actualActionResult, typeof(ViewResult));
        }

        [TestMethod]
        public void ModelControllerBaseGetTest()
        {
            /*Arrange*/
            var mockUserInfo = new Mock<IUserInfo>(MockBehavior.Strict);
            var mockEntityRepository = new Mock<IEntityRepository<TestEntity>>(MockBehavior.Strict);
            var mockLogger = new Mock<ILogger>(MockBehavior.Strict);
            var expectedTestEntities = Enumerable.Range(1, 5)
                .Select(index => new TestEntity { Id = index }).ToArray();
            ActionResult actualActionResult;

            mockEntityRepository
                .Setup(repository => repository.Get(null))
                .Returns(expectedTestEntities);

            mockEntityRepository
                .Setup(repository => repository.Dispose());

            /*Act*/
            using (var controller = new ModelController(mockUserInfo.Object, mockEntityRepository.Object, mockLogger.Object))
            {
                actualActionResult = controller.Get();
            }

            /*Assert*/
            mockUserInfo.VerifyAll();

            mockEntityRepository.VerifyAll();
            mockEntityRepository
                .Verify(repository => repository.Get(null), Times.Once);
            mockEntityRepository
                .Verify(repository => repository.Dispose(), Times.Once);

            mockLogger.VerifyAll();

            Assert.IsInstanceOfType(actualActionResult, typeof(JsonResult));
        }

        [TestMethod]
        public void ModelControllerBaseGetByIdTest()
        {
            /*Arrange*/
            var mockUserInfo = new Mock<IUserInfo>(MockBehavior.Strict);
            var mockEntityRepository = new Mock<IEntityRepository<TestEntity>>(MockBehavior.Strict);
            var mockLogger = new Mock<ILogger>(MockBehavior.Strict);
            var expectedId = 1;
            var expectedTestEntities = new[] { new TestEntity { Id = expectedId } };
            ActionResult actualActionResult;

            mockEntityRepository
                .Setup(repository => repository.Get(It.IsNotNull<Expression<Func<TestEntity, bool>>>()))
                .Returns(expectedTestEntities);

            mockEntityRepository
                .Setup(repository => repository.Dispose());

            /*Act*/
            using (var controller = new ModelController(mockUserInfo.Object, mockEntityRepository.Object, mockLogger.Object))
            {
                actualActionResult = controller.Get(expectedId);
            }

            /*Assert*/
            mockUserInfo.VerifyAll();

            mockEntityRepository.VerifyAll();
            mockEntityRepository
                .Verify(repository => repository.Get(It.IsNotNull<Expression<Func<TestEntity, bool>>>()), Times.Once);
            mockEntityRepository
                .Verify(repository => repository.Dispose(), Times.Once);

            mockLogger.VerifyAll();

            Assert.IsInstanceOfType(actualActionResult, typeof(JsonResult));
        }

        [TestMethod]
        public void ModelControllerBaseAddTest()
        {
            /*Arrange*/
            var mockUserInfo = new Mock<IUserInfo>(MockBehavior.Strict);
            var mockEntityRepository = new Mock<IEntityRepository<TestEntity>>(MockBehavior.Strict);
            var mockLogger = new Mock<ILogger>(MockBehavior.Strict);
            var expectedTestModel = new TestModel();
            var expectedCreatorId = 1;
            ActionResult actualActionResult;

            mockUserInfo
                .SetupGet(userInfo => userInfo.Id)
                .Returns(expectedCreatorId);

            mockEntityRepository
                .Setup(repository => repository.Add(It.IsNotNull<TestEntity>(), expectedCreatorId))
                .Returns(It.IsNotNull<TestEntity>());

            mockEntityRepository
                .Setup(repository => repository.Dispose());

            /*Act*/
            using (var controller = new ModelController(mockUserInfo.Object, mockEntityRepository.Object, mockLogger.Object))
            {
                actualActionResult = controller.Add(expectedTestModel);
            }

            /*Assert*/
            mockUserInfo.VerifyAll();
            mockUserInfo
                .Verify(userInfo => userInfo.Id, Times.Once);

            mockEntityRepository.VerifyAll();
            mockEntityRepository
                .Verify(repository => repository.Add(It.IsNotNull<TestEntity>(), expectedCreatorId), Times.Once);
            mockEntityRepository
                .Verify(repository => repository.Dispose(), Times.Once);

            mockLogger.VerifyAll();

            Assert.IsInstanceOfType(actualActionResult, typeof(JsonResult));
        }

        [TestMethod]
        public void ModelControllerBaseUpdateTest()
        {
            /*Arrange*/
            var mockUserInfo = new Mock<IUserInfo>(MockBehavior.Strict);
            var mockEntityRepository = new Mock<IEntityRepository<TestEntity>>(MockBehavior.Strict);
            var mockLogger = new Mock<ILogger>(MockBehavior.Strict);
            var expectedTestModel = new TestModel();
            var expectedUpdaterId = 1;
            ActionResult actualActionResult;

            mockUserInfo
                .SetupGet(userInfo => userInfo.Id)
                .Returns(expectedUpdaterId);

            mockEntityRepository
                .Setup(repository => repository.Update(It.IsNotNull<TestEntity>(), expectedUpdaterId))
                .Returns(It.IsNotNull<TestEntity>());

            mockEntityRepository
                .Setup(repository => repository.Dispose());

            /*Act*/
            using (var controller = new ModelController(mockUserInfo.Object, mockEntityRepository.Object, mockLogger.Object))
            {
                actualActionResult = controller.Update(expectedTestModel);
            }

            /*Assert*/
            mockUserInfo.VerifyAll();
            mockUserInfo
                .Verify(userInfo => userInfo.Id, Times.Once);

            mockEntityRepository.VerifyAll();
            mockEntityRepository
                .Verify(repository => repository.Update(It.IsNotNull<TestEntity>(), expectedUpdaterId), Times.Once);
            mockEntityRepository
                .Verify(repository => repository.Dispose(), Times.Once);

            mockLogger.VerifyAll();

            Assert.IsInstanceOfType(actualActionResult, typeof(JsonResult));
        }

        [TestMethod]
        public void ModelControllerBaseDeleteTest()
        {
            /*Arrange*/
            var mockUserInfo = new Mock<IUserInfo>(MockBehavior.Strict);
            var mockEntityRepository = new Mock<IEntityRepository<TestEntity>>(MockBehavior.Strict);
            var mockLogger = new Mock<ILogger>(MockBehavior.Strict);
            var expectedTestModel = new TestModel();
            var expectedDeactivatorId = 1;
            ActionResult actualActionResult;

            mockUserInfo
                .SetupGet(userInfo => userInfo.Id)
                .Returns(expectedDeactivatorId);

            mockEntityRepository
                .Setup(repository => repository.Deactivate(It.IsNotNull<TestEntity>(), expectedDeactivatorId))
                .Returns(It.IsNotNull<TestEntity>());

            mockEntityRepository
                .Setup(repository => repository.Dispose());

            /*Act*/
            using (var controller = new ModelController(mockUserInfo.Object, mockEntityRepository.Object, mockLogger.Object))
            {
                actualActionResult = controller.Delete(expectedTestModel);
            }

            /*Assert*/
            mockUserInfo.VerifyAll();
            mockUserInfo
                .Verify(userInfo => userInfo.Id, Times.Once);

            mockEntityRepository.VerifyAll();
            mockEntityRepository
                .Verify(repository => repository.Deactivate(It.IsNotNull<TestEntity>(), expectedDeactivatorId), Times.Once);
            mockEntityRepository
                .Verify(repository => repository.Dispose(), Times.Once);

            mockLogger.VerifyAll();

            Assert.IsInstanceOfType(actualActionResult, typeof(HttpStatusCodeResult));
        }
    }
}