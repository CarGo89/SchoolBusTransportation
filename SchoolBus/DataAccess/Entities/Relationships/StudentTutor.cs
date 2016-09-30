using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBus.DataAccess.Entities.Relationships
{
    [Table("StudentTutors")]
    public class StudentTutor : IEntityRelationship<SchoolYearStudent, Tutor>
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

        [Column("SchoolYearStudentId"), Index("UQ_SchoolYearStudentId_TutorId", 1, IsUnique = true)]
        public int LeftEntityId { get; set; }

        [ForeignKey("LeftEntityId")]
        public virtual SchoolYearStudent LeftEntity { get; set; }

        [Column("TutorId"), Index("UQ_SchoolYearStudentId_TutorId", 2, IsUnique = true)]
        public int RightEntityId { get; set; }

        [ForeignKey("RightEntityId")]
        public virtual Tutor RightEntity { get; set; }

        #endregion IEntityRelationship Properties

        #region Navigation Properties

        public virtual ICollection<StudentTutorAddress> StudentTutorAddresses { get; set; }

        #endregion Navigation Properties
    }
}