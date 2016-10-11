using System;
using System.Web.Script.Serialization;

namespace SchoolBusWeb.Models
{
    public abstract class ModelBase
    {
        #region Properties

        public virtual int Id { get; set; }

        [ScriptIgnore]
        public virtual DateTime? CreatedAt { get; set; }

        [ScriptIgnore]
        public virtual int? CreatedById { get; set; }

        [ScriptIgnore]
        public virtual User CreatedBy { get; set; }

        [ScriptIgnore]
        public virtual DateTime? UpdatedAt { get; set; }

        [ScriptIgnore]
        public virtual int? UpdatedById { get; set; }

        [ScriptIgnore]
        public virtual User UpdatedBy { get; set; }

        [ScriptIgnore]
        public virtual DateTime? DeactivatedAt { get; set; }

        [ScriptIgnore]
        public virtual int? DeactivatedById { get; set; }

        [ScriptIgnore]
        public virtual User DeactivatedBy { get; set; }

        public virtual bool IsValid { get; set; }

        #endregion Properties

        #region Constructors

        protected ModelBase()
        {
            IsValid = true;
        }

        #endregion Constructors
    }
}