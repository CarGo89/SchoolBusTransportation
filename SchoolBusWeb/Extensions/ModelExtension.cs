using System.Collections.Generic;
using System.Web.Mvc;
using SchoolBusWeb.Models;

namespace SchoolBusWeb.Extensions
{
    public static class ModelExtension
    {
        #region Private Methods

        private static JsonResult Serialize(object target)
        {
            return new JsonResult
            {
                Data = target,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = int.MaxValue
            };
        }

        #endregion Private Methods

        #region Extension Methods

        public static JsonResult ToJsonResult<TModel>(this TModel model)
            where TModel : ModelBase
        {
            return Serialize(model);
        }

        public static JsonResult ToJsonResults<TModels>(this TModels models)
            where TModels : IEnumerable<ModelBase>
        {
            return Serialize(models);
        }

        #endregion Extension Methods
    }
}