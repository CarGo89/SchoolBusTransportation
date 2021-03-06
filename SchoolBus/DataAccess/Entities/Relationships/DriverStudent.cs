﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBus.DataAccess.Entities.Relationships
{
    [Table("DriverStudents")]
    public class DriverStudent : IEntityRelationship<SchoolYearDriver, SchoolYearStudent>
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

        [Column("SchoolYearDriverId"), Index("UQ_SchoolYearDriverId_SchoolYearStudentId", 1, IsUnique = true)]
        public int LeftEntityId { get; set; }

        [ForeignKey("LeftEntityId")]
        public virtual SchoolYearDriver LeftEntity { get; set; }

        [Column("SchoolYearStudentId"), Index("UQ_SchoolYearDriverId_SchoolYearStudentId", 2, IsUnique = true)]
        public int RightEntityId { get; set; }

        [ForeignKey("RightEntityId")]
        public virtual SchoolYearStudent RightEntity { get; set; }

        #endregion IEntityRelationship Properties
    }
}