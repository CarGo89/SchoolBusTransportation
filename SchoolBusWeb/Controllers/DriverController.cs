using System.Web.Mvc;
using SchoolBusWeb.Models;

namespace SchoolBusWeb.Controllers
{
    public class DriverController : ModelControllerBase<Driver, SchoolBus.DataAccess.Entities.Driver>
    {
        [HttpPost]
        public override ActionResult Add(Driver model)
        {
            model.UserRoleId = Settings.DriverRoleId;

            return base.Add(model);
        }

        [HttpPost]
        public override ActionResult Update(Driver model)
        {
            model.UserRoleId = Settings.DriverRoleId;

            return base.Update(model);
        }
    }
}