using System.Linq;
using Dpr.Core.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchoolBus.DataAccess.Repositories;
using SchoolBus.Tests.DataAccess.Entities;

namespace SchoolBus.Tests.DataAccess.Repositories
{
    [TestClass]
    public class EntityRepositoryTest
    {
        [TestMethod]
        public void EntityRepositoryInitTest()
        {
            /*Arrange*/
            var mockRepository = new Mock<IRepository<TestEntity>>(MockBehavior.Strict);

            mockRepository
                .Setup(repository => repository.Dispose());

            /*Act*/
            using (new EntityRepository<TestEntity>(mockRepository.Object))
            {
            }

            /*Assert*/
            mockRepository.VerifyAll();

            mockRepository
                .Verify(repository => repository.Dispose(), Times.Once);
        }

        [TestMethod]
        public void EntityRepositoryGetTest()
        {
            /*Arrange*/
            var mockRepository = new Mock<IRepository<TestEntity>>(MockBehavior.Strict);
            var expectedEntities = Enumerable.Range(1, 5)
                .Select(index => new TestEntity { Id = index }).ToArray();
            TestEntity[] actualEntities;

            mockRepository
                .Setup(repository => repository.GetAll())
                .Returns(expectedEntities);

            mockRepository
                .Setup(repository => repository.Dispose());

            /*Act*/
            using (var entityRepository = new EntityRepository<TestEntity>(mockRepository.Object))
            {
                actualEntities = entityRepository.Get().ToArray();
            }

            /*Assert*/
            mockRepository.VerifyAll();

            mockRepository
                .Verify(repository => repository.GetAll(), Times.Once);

            mockRepository
                .Verify(repository => repository.Dispose(), Times.Once);

            CollectionAssert.AreEqual(expectedEntities, actualEntities);
        }
    }
}