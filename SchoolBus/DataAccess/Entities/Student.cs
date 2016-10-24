using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolBus.DataAccess.Entities.Relationships;

namespace SchoolBus.DataAccess.Entities
{
    [Table("Students")]
    public class Student : IEntity
    {
        #region IEntity Properties

        [Key]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? CreatedById { get; set; }

        public User CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int? UpdatedById { get; set; }

        public User UpdatedBy { get; set; }

        public DateTime? DeactivatedAt { get; set; }

        public int? DeactivatedById { get; set; }

        public User DeactivatedBy { get; set; }

        #endregion IEntity Properties

        #region Properties

        [Required, Column(TypeName = "VARCHAR"), MaxLength(500)]
        public string FirstName { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(500)]
        public string MiddleName { get; set; }

        [Required, Column(TypeName = "VARCHAR"), MaxLength(500)]
        public string LastName { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(500)]
        public string SecondLastName { get; set; }

        public DateTime? BirthDate { get; set; }

        #endregion Properties

        #region Navigation Properties

        public ICollection<SchoolYearStudent> SchoolYearStudents { get; set; }

        #endregion Navigation Properties
    }
}