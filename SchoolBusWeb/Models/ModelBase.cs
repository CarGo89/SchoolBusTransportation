using System;
using SchoolBus.DataAccess.Entities;

namespace SchoolBusWeb.Models
{
    public abstract class ModelBase : IEntity
    {
        #region Properties

        public virtual int Id { get; set; }

        public virtual DateTime CreatedAt { get; set; }

        public virtual int? CreatedById { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual DateTime UpdatedAt { get; set; }

        public virtual int? UpdatedById { get; set; }

        public virtual User UpdatedBy { get; set; }

        public virtual DateTime? DeactivatedAt { get; set; }

        public virtual int? DeactivatedById { get; set; }

        public virtual User DeactivatedBy { get; set; }

        #endregion Properties
    }
}