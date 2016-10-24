using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using AutoMapper;
using Dpr.Core.Extensions;
using Dpr.Core.Logging;
using SchoolBus.DataAccess.Repositories;
using SchoolBusWeb.Extensions;
using SchoolBusWeb.Models;
using SchoolBusWeb.Utilities;

namespace SchoolBusWeb.Controllers
{
    public class ModelControllerBase<TModel, TEntity> : Controller
        where TModel : ModelBase
        where TEntity : class, SchoolBus.DataAccess.Entities.IEntity
    {
        #region Fields

        protected readonly ISettingsManager Settings;

        protected readonly IUserInfo UserInfo;

        protected readonly IEntityRepository<TEntity> EntityRepository;

        protected readonly ILogger Logger;

        protected static readonly IDictionary<string, IEnumerable<PropertyInfo>> PropertiesByModel;

        protected string SiteBaseUrl
        {
            get
            {
                if (Request != null && Request.Url != null)
                {
                    return string.Format("{0}://{1}", Request.Url.Scheme, Request.Url.Authority);
                }

                return null;
            }
        }

        private static readonly Type ModelPropertyType;

        #endregion Fields

        #region Constructors

        static ModelControllerBase()
        {
            ModelPropertyType = typeof(ModelProperty<>);

            PropertiesByModel = new Dictionary<string, IEnumerable<PropertyInfo>>(StringComparer.InvariantCultureIgnoreCase);
        }

        protected ModelControllerBase()
            : this(SettingsManager.Instance, new UserInfo(), new EntityRepository<TEntity>(), new Logger(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ShoolBusTransportation.log")))
        {
        }

        protected internal ModelControllerBase(ISettingsManager settings, IUserInfo userInfo, IEntityRepository<TEntity> entityRepository, ILogger logger)
        {
            Settings = settings;

            UserInfo = userInfo;

            //UserInfo.Id = 1;

            EntityRepository = entityRepository;

            Logger = logger;

            var modelType = typeof(TModel);

            if (!PropertiesByModel.ContainsKey(modelType.Name))
            {
                PropertiesByModel[modelType.Name] = modelType.GetProperties()
                    .Where(prop => string.Equals(prop.PropertyType.Name, ModelPropertyType.Name));
            }
        }

        #endregion Constructors

        #region Action Results

        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public virtual ActionResult Get(int? id = null)
        {
            var entities = id.HasValue ? EntityRepository.Get(entity => entity.Id == id.Value) : EntityRepository.Get(entity => !entity.DeactivatedById.HasValue);
            var models = Mapper.Map<TModel[]>(entities);

            return models.ToJsonResult();
        }

        [HttpPost]
        public virtual ActionResult Add(TModel model)
        {
            model.IsValid = ModelState.IsValid;

            if (!model.IsValid)
            {
                SetErrorMessages(model);

                return model.ToJsonResult();
            }

            var entity = Mapper.Map<TEntity>(model);
            var addedEntity = EntityRepository.Add(entity, UserInfo.Id);
            var addedModel = Mapper.Map<TModel>(addedEntity);

            return addedModel.ToJsonResult();
        }

        [HttpPost]
        public virtual ActionResult Update(TModel model)
        {
            model.IsValid = ModelState.IsValid;

            if (!model.IsValid)
            {
                SetErrorMessages(model);

                return model.ToJsonResult();
            }

            var entity = Mapper.Map<TEntity>(model);
            var updatedEntity = EntityRepository.Update(entity, UserInfo.Id);
            var updatedModel = Mapper.Map<TModel>(updatedEntity);

            return updatedModel.ToJsonResult();
        }

        [HttpPost]
        public virtual ActionResult Delete(TModel model)
        {
            model.IsValid = ModelState.IsValid;

            if (!model.IsValid)
            {
                SetErrorMessages(model);

                return model.ToJsonResult();
            }

            var entity = Mapper.Map<TEntity>(model);

            EntityRepository.Deactivate(entity, UserInfo.Id);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        #endregion Action Results

        #region Methods

        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
            }

            base.OnAuthentication(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            Logger.Error(filterContext.Exception);

            base.OnException(filterContext);
        }

        protected IEnumerable<string> GetValidationMessages()
        {
            return ModelState
               .Where(model => model.Value.Errors.Any())
               .SelectMany(model => model.Value.Errors.Select(error => error.ErrorMessage));
        }

        protected void SetErrorMessages(TModel model)
        {
            if (model.IsValid || ModelState.IsNullOrEmpty())
            {
                return;
            }

            var modelProperties = PropertiesByModel[typeof(TModel).Name];

            foreach (var modelProperty in modelProperties)
            {
                var modelState = ModelState.TryGetValue(modelProperty.Name);
                var modelPropertyValue = modelProperty.GetValue(model) ?? Activator.CreateInstance(modelProperty.PropertyType);
                var actualValue = (ModelPropertyBase)modelPropertyValue;

                actualValue.ErrorMessage = string.Empty;

                if (modelState == null)
                {
                    continue;
                }

                if (!modelState.Errors.IsNullOrEmpty())
                {
                    actualValue.ErrorMessage = modelState.Errors.First().ErrorMessage;
                }

                modelProperty.SetValue(model, modelPropertyValue);
            }
        }

        protected override void Dispose(bool disposing)
        {
            EntityRepository.Dispose();

            base.Dispose(disposing);
        }

        #endregion Methods
    }
}