using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using AutoMapper;
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

        protected readonly IUserInfo UserInfo;

        protected readonly IEntityRepository<TEntity> EntityRepository;

        protected readonly ILogger Logger;

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

        #endregion Fields

        #region Constructors

        protected ModelControllerBase()
            : this(new UserInfo(), new EntityRepository<TEntity>(), new Logger(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ShoolBusTransportation.log")))
        {
        }

        protected internal ModelControllerBase(IUserInfo userInfo, IEntityRepository<TEntity> entityRepository, ILogger logger)
        {
            UserInfo = userInfo;

            EntityRepository = entityRepository;

            Logger = logger;
        }

        #endregion Constructors

        #region Action Results

        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public virtual ActionResult Get(int? modelId = null)
        {
            var entities = modelId.HasValue ? EntityRepository.Get(entity => entity.Id == modelId.Value) : EntityRepository.Get();
            var models = Mapper.Map<TModel[]>(entities);

            return models.ToJsonResults();
        }

        [HttpPost]
        public virtual ActionResult Add(TModel model)
        {
            var entity = Mapper.Map<TEntity>(model);
            var addedEntity = EntityRepository.Add(entity, UserInfo.Id);
            var addedModel = Mapper.Map<TModel>(addedEntity);

            return addedModel.ToJsonResult();
        }

        [HttpPut]
        public virtual ActionResult Update(TModel model)
        {
            var entity = Mapper.Map<TEntity>(model);
            var updatedEntity = EntityRepository.Update(entity, UserInfo.Id);
            var updatedModel = Mapper.Map<TModel>(updatedEntity);

            return updatedModel.ToJsonResult();
        }

        [HttpPost]
        public virtual ActionResult Delete(TModel model)
        {
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

        protected override void Dispose(bool disposing)
        {
            EntityRepository.Dispose();

            base.Dispose(disposing);
        }

        #endregion Methods
    }
}