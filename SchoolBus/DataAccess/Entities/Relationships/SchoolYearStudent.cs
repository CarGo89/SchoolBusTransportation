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

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [Column("SchoolYearId"), Index("UQ_SchoolYearId_StudentId", 1, IsUnique = true)]
        public int LeftEntityId { get; set; }

        [ForeignKey("LeftEntityId")]
        public virtual SchoolYear LeftEntity { get; set; }

        [Column("StudentId"), Index("UQ_SchoolYearId_StudentId", 2, IsUnique = true)]
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