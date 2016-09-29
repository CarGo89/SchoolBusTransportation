using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBus.DataAccess.Entities.Relationships
{
    [Table("SchoolYearStudents")]
    public class SchoolYearStudent : IEntityRelationship<SchoolYear, Student>
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

        #region IEntityRelationship Properties

        [Column("SchoolYearId")]
        public int LeftEntityId { get; set; }

        [ForeignKey("LeftEntityId")]
        public virtual SchoolYear LeftEntity { get; set; }

        [Column("StudentId")]
        public int RightEntityId { get; set; }

        [ForeignKey("RightEntityId")]
        public virtual Student RightEntity { get; set; }

        #endregion IEntityRelationship Properties

        #region Navigation Properties

        public virtual ICollection<DriverStudent> DriverStudents { get; set; }

        public virtual ICollection<StudentTutor> StudentTutors { get; set; }

        #endregion Navigation Properties
    }
}