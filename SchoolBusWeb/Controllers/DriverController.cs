using System.Web.Mvc;
using Dpr.Core.Logging;
using SchoolBus.DataAccess.Repositories;
using SchoolBusWeb.Models;
using SchoolBusWeb.Utilities;

namespace SchoolBusWeb.Controllers
{
    public class DriverController : ModelControllerBase<Driver, SchoolBus.DataAccess.Entities.Driver>
    {
        #region Constructors

        public DriverController()
        { }

        internal DriverController(ISettingsManager settings, IUserInfo userInfo, IEntityRepository<SchoolBus.DataAccess.Entities.Driver> entityRepository, ILogger logger)
            : base(settings, userInfo, entityRepository, logger)
        { }

        #endregion Constructors

        #region Action Results

        public override ActionResult Add(Driver model)
        {
            model.UserRoleId = Settings.DriverRoleId;

            return base.Add(model);
        }

        public override ActionResult Update(Driver model)
        {
            model.UserRoleId = Settings.DriverRoleId;

            return base.Update(model);
        }

        public override ActionResult Delete(Driver model)
        {
            model.UserRoleId = Settings.DriverRoleId;

            return base.Delete(model);
        }

        #endregion Action Results
    }
}