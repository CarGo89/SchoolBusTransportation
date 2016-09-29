using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolBus.DataAccess.Entities.Relationships;

namespace SchoolBus.DataAccess.Entities
{
    [Table("SchoolYears")]
    public class SchoolYear : IEntity
    {
        #region IEntity Properties

        [Key]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? CreatedById { get; set; }

        public virtual User CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int? UpdatedById { get; set; }

        public virtual User UpdatedBy { get; set; }

        public DateTime? DeactivatedAt { get; set; }

        public int? DeactivatedById { get; set; }

        public virtual User DeactivatedBy { get; set; }

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