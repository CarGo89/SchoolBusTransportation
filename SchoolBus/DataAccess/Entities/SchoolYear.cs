using System;
using System.Collections.Generic;
using SchoolBus.DataAccess.Entities.Relationships;

namespace SchoolBus.DataAccess.Entities
{
    public class SchoolYear : IEntity
    {
        #region IEntity Properties

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedById { get; set; }

        public virtual Person CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int UpdatedById { get; set; }

        public virtual Person UpdatedBy { get; set; }

        public DateTime DeactivatedAt { get; set; }

        public int DeactivatedById { get; set; }

        public virtual Person DeactivatedBy { get; set; }

        #endregion IEntity Properties

        #region Properties

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        #endregion Properties

        #region Navigation Properties

        public virtual ICollection<SchoolYearStudent> SchoolYearStudents { get; set; }

        public virtual ICollection<SchoolYearDriver> SchoolYearDrivers { get; set; }

        #endregion Navigation Properties
    }
}