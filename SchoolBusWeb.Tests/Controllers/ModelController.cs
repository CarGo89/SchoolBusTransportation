using AutoMapper;
using Dpr.Core.Logging;
using SchoolBus.DataAccess.Repositories;
using SchoolBusWeb.Controllers;
using SchoolBusWeb.Tests.Models;
using SchoolBusWeb.Utilities;
using SchoolBusWeb.Tests.Models.Mappings;

namespace SchoolBusWeb.Tests.Controllers
{
    public class ModelController : ModelControllerBase<TestModel, TestEntity>
    {
        #region Constructors

        static ModelController()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<TestModelMapperProfile>());
        }

        public ModelController(ISettingsManager settings, IUserInfo userInfo, IEntityRepository<TestEntity> entityRepository, ILogger logger)
            : base(settings, userInfo, entityRepository, logger)
        {
        }

        #endregion Constructors
    }
}