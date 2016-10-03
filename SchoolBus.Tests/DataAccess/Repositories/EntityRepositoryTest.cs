using System;
using System.Fakes;
using System.Linq;
using System.Linq.Expressions;
using Dpr.Core.DataAccess;
using Microsoft.QualityTools.Testing.Fakes;
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

        [TestMethod]
        public void EntityRepositoryGetUsingFilterTest()
        {
            /*Arrange*/
            var mockRepository = new Mock<IRepository<TestEntity>>(MockBehavior.Strict);
            var expectedEntities = Enumerable.Range(1, 5)
                .Select(index => new TestEntity { Id = index }).ToArray();
            TestEntity[] actualEntities;

            mockRepository
                .Setup(repository => repository.GetAll(entity => entity.Id % 2 == 0))
                .Returns(expectedEntities);

            mockRepository
                .Setup(repository => repository.Dispose());

            /*Act*/
            using (var entityRepository = new EntityRepository<TestEntity>(mockRepository.Object))
            {
                actualEntities = entityRepository.Get(entity => entity.Id % 2 == 0).ToArray();
            }

            /*Assert*/
            mockRepository.VerifyAll();

            mockRepository
                .Verify(repository => repository.GetAll(entity => entity.Id % 2 == 0), Times.Once);

            mockRepository
                .Verify(repository => repository.Dispose(), Times.Once);

            CollectionAssert.AreEqual(expectedEntities, actualEntities);
        }

        [TestMethod]
        public void EntityRepositoryAddTest()
        {
            using (ShimsContext.Create())
            {
                /*Arrange*/
                var mockRepository = new Mock<IRepository<TestEntity>>(MockBehavior.Strict);
                var expectedEntity = new TestEntity();
                var expectedCreatedAt = new DateTime(2016, 10, 3, 11, 30, 30);
                const int expectedCreatorId = 4;

                ShimDateTime.NowGet = () => expectedCreatedAt;

                mockRepository
                    .Setup(repository => repository.Dispose());

                mockRepository
                    .Setup(repository => repository.Add(It.Is<TestEntity>(entity =>
                        entity.CreatedAt == expectedCreatedAt && entity.UpdatedAt == expectedCreatedAt && entity.DeactivatedAt == null &&
                        entity.CreatedById == expectedCreatorId && entity.UpdatedById == expectedCreatorId && entity.DeactivatedById == null &&
                        entity.CreatedBy == null && entity.UpdatedBy == null && entity.DeactivatedBy == null)))
                    .Returns(expectedEntity);

                /*Act*/
                using (var entityRepository = new EntityRepository<TestEntity>(mockRepository.Object))
                {
                    entityRepository.Add(expectedEntity, expectedCreatorId);
                }

                /*Assert*/
                mockRepository.VerifyAll();

                mockRepository
                    .Verify(repository => repository.Add(It.Is<TestEntity>(entity =>
                        entity.CreatedAt == expectedCreatedAt && entity.UpdatedAt == expectedCreatedAt &&
                        entity.CreatedById == expectedCreatorId && entity.UpdatedById == expectedCreatorId &&
                        entity.CreatedBy == null && entity.UpdatedBy == null)), Times.Once);

                mockRepository
                    .Verify(repository => repository.Dispose(), Times.Once);
            }
        }

        [TestMethod]
        public void EntityRepositoryUpdateNonExistingTest()
        {
            /*Arrange*/
            var mockRepository = new Mock<IRepository<TestEntity>>(MockBehavior.Strict);
            var expectedEntity = new TestEntity { Id = 5 };
            TestEntity actualEntity;
            const int expectedUpdaterId = 4;

            mockRepository
                .Setup(repository => repository.Single(It.IsNotNull<Expression<Func<TestEntity, bool>>>()))
                .Returns((TestEntity)null);

            mockRepository
                .Setup(repository => repository.Dispose());

            /*Act*/
            using (var entityRepository = new EntityRepository<TestEntity>(mockRepository.Object))
            {
                actualEntity = entityRepository.Update(expectedEntity, expectedUpdaterId);
            }

            /*Assert*/
            mockRepository.VerifyAll();

            mockRepository
                .Verify(repository => repository.Single(It.IsNotNull<Expression<Func<TestEntity, bool>>>()), Times.Once);

            mockRepository
                .Verify(repository => repository.Dispose(), Times.Once);

            Assert.AreEqual(expectedEntity, actualEntity);
        }

        [TestMethod]
        public void EntityRepositoryUpdateTest()
        {
            using (ShimsContext.Create())
            {
                /*Arrange*/
                var mockRepository = new Mock<IRepository<TestEntity>>(MockBehavior.Strict);
                var expectedCreatedAt = new DateTime(2016, 10, 3, 10, 14, 23);
                var expectedUpdatedAt = new DateTime(2016, 12, 3, 10, 14, 23);
                const int expectedCreatorId = 54;
                const int expectedUpdaterId = 14;
                var expectedEntity = new TestEntity
                {
                    Id = 5,
                    CreatedById = expectedCreatorId,
                    CreatedAt = expectedCreatedAt,
                    UpdatedById = expectedCreatorId,
                    UpdatedAt = expectedCreatedAt
                };

                ShimDateTime.NowGet = () => expectedUpdatedAt;

                mockRepository
                    .Setup(repository => repository.Single(It.IsNotNull<Expression<Func<TestEntity, bool>>>()))
                    .Returns(expectedEntity);

                mockRepository
                    .Setup(repository => repository.Update(It.Is<TestEntity>(entity => entity.Id == expectedEntity.Id &&
                        entity.CreatedAt == expectedCreatedAt && entity.UpdatedAt == expectedUpdatedAt && entity.DeactivatedAt == null &&
                        entity.CreatedById == expectedCreatorId && entity.UpdatedById == expectedUpdaterId && entity.DeactivatedById == null &&
                        entity.CreatedBy == null && entity.UpdatedBy == null && entity.DeactivatedBy == null)))
                    .Returns(expectedEntity);

                mockRepository
                    .Setup(repository => repository.Dispose());

                /*Act*/
                using (var entityRepository = new EntityRepository<TestEntity>(mockRepository.Object))
                {
                    entityRepository.Update(expectedEntity, expectedUpdaterId);
                }

                /*Assert*/
                mockRepository.VerifyAll();

                mockRepository
                    .Verify(repository => repository.Single(It.IsNotNull<Expression<Func<TestEntity, bool>>>()), Times.Once);

                mockRepository
                    .Verify(repository => repository.Update(It.Is<TestEntity>(entity => entity.Id == expectedEntity.Id &&
                        entity.CreatedAt == expectedCreatedAt && entity.UpdatedAt == expectedUpdatedAt && entity.DeactivatedAt == null &&
                        entity.CreatedById == expectedCreatorId && entity.UpdatedById == expectedUpdaterId && entity.DeactivatedById == null &&
                        entity.CreatedBy == null && entity.UpdatedBy == null && entity.DeactivatedBy == null)), Times.Once);

                mockRepository
                    .Verify(repository => repository.Dispose(), Times.Once);
            }
        }

        [TestMethod]
        public void EntityRepositoryDeactivateNonExistingTest()
        {
            /*Arrange*/
            var mockRepository = new Mock<IRepository<TestEntity>>(MockBehavior.Strict);
            var expectedEntity = new TestEntity { Id = 5 };
            TestEntity actualEntity;
            const int expectedUpdaterId = 4;

            mockRepository
                .Setup(repository => repository.Single(It.IsNotNull<Expression<Func<TestEntity, bool>>>()))
                .Returns((TestEntity)null);

            mockRepository
                .Setup(repository => repository.Dispose());

            /*Act*/
            using (var entityRepository = new EntityRepository<TestEntity>(mockRepository.Object))
            {
                actualEntity = entityRepository.Deactivate(expectedEntity, expectedUpdaterId);
            }

            /*Assert*/
            mockRepository.VerifyAll();

            mockRepository
                .Verify(repository => repository.Single(It.IsNotNull<Expression<Func<TestEntity, bool>>>()), Times.Once);

            mockRepository
                .Verify(repository => repository.Dispose(), Times.Once);

            Assert.AreEqual(expectedEntity, actualEntity);
        }

        [TestMethod]
        public void EntityRepositoryDactivateTest()
        {
            using (ShimsContext.Create())
            {
                /*Arrange*/
                var mockRepository = new Mock<IRepository<TestEntity>>(MockBehavior.Strict);
                var expectedCreatedAt = new DateTime(2016, 10, 3, 10, 14, 23);
                var expectedDeactivatedAt = new DateTime(2016, 12, 3, 10, 14, 23);
                const int expectedCreatorId = 54;
                const int expectedDeactivatorId = 14;
                var expectedEntity = new TestEntity
                {
                    Id = 5,
                    CreatedById = expectedCreatorId,
                    CreatedAt = expectedCreatedAt,
                    UpdatedById = expectedCreatorId,
                    UpdatedAt = expectedCreatedAt
                };

                ShimDateTime.NowGet = () => expectedDeactivatedAt;

                mockRepository
                    .Setup(repository => repository.Single(It.IsNotNull<Expression<Func<TestEntity, bool>>>()))
                    .Returns(expectedEntity);

                mockRepository
                    .Setup(repository => repository.Update(It.Is<TestEntity>(entity => entity.Id == expectedEntity.Id &&
                        entity.CreatedAt == expectedCreatedAt && entity.UpdatedAt == expectedDeactivatedAt && entity.DeactivatedAt == expectedDeactivatedAt &&
                        entity.CreatedById == expectedCreatorId && entity.UpdatedById == expectedDeactivatorId && entity.DeactivatedById == expectedDeactivatorId &&
                        entity.CreatedBy == null && entity.UpdatedBy == null && entity.DeactivatedBy == null)))
                    .Returns(expectedEntity);

                mockRepository
                    .Setup(repository => repository.Dispose());

                /*Act*/
                using (var entityRepository = new EntityRepository<TestEntity>(mockRepository.Object))
                {
                    entityRepository.Deactivate(expectedEntity, expectedDeactivatorId);
                }

                /*Assert*/
                mockRepository.VerifyAll();

                mockRepository
                    .Verify(repository => repository.Single(It.IsNotNull<Expression<Func<TestEntity, bool>>>()), Times.Once);

                mockRepository
                    .Verify(repository => repository.Update(It.Is<TestEntity>(entity => entity.Id == expectedEntity.Id &&
                        entity.CreatedAt == expectedCreatedAt && entity.UpdatedAt == expectedDeactivatedAt && entity.DeactivatedAt == expectedDeactivatedAt &&
                        entity.CreatedById == expectedCreatorId && entity.UpdatedById == expectedDeactivatorId && entity.DeactivatedById == expectedDeactivatorId &&
                        entity.CreatedBy == null && entity.UpdatedBy == null && entity.DeactivatedBy == null)), Times.Once);

                mockRepository
                    .Verify(repository => repository.Dispose(), Times.Once);
            }
        }
    }
}