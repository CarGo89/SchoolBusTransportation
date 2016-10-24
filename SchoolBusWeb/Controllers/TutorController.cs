using System.Web.Mvc;
using Dpr.Core.Logging;
using SchoolBus.DataAccess.Repositories;
using SchoolBusWeb.Models;
using SchoolBusWeb.Utilities;

namespace SchoolBusWeb.Controllers
{
    public class TutorController : ModelControllerBase<Tutor, SchoolBus.DataAccess.Entities.Tutor>
    {
        #region Constructors

        public TutorController()
        { }

        internal TutorController(ISettingsManager settings, IUserInfo userInfo, IEntityRepository<SchoolBus.DataAccess.Entities.Tutor> entityRepository, ILogger logger)
            : base(settings, userInfo, entityRepository, logger)
        { }

        #endregion Constructors

        #region Action Results

        public override ActionResult Add(Tutor model)
        {
            model.UserRoleId = Settings.TutorRoleId;

            return base.Add(model);
        }

        public override ActionResult Update(Tutor model)
        {
            model.UserRoleId = Settings.TutorRoleId;

            return base.Update(model);
        }

        public override ActionResult Delete(Tutor model)
        {
            model.UserRoleId = Settings.TutorRoleId;

            return base.Delete(model);
        }

        #endregion Action Results
    }
}