using System;
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

             var date = new DateTime();

            DateTime.TryParse(model.BirthDate, out date);

            return base.Add(model);
        }
    }
}