using System.Web.Mvc;
using SchoolBusWeb.Models;

namespace SchoolBusWeb.Controllers
{
    public class DriverController : ModelControllerBase<Driver, SchoolBus.DataAccess.Entities.Driver>
    {
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
    }
}