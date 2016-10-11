using System.Web.Mvc;

namespace SchoolBusWeb.Extensions
{
    public static class ModelExtension
    {
        #region Private Methods

        public static JsonResult ToJsonResult(this object target)
        {
            return new JsonResult
            {
                Data = target,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = int.MaxValue
            };
        }

        #endregion Extension Methods
    }
}