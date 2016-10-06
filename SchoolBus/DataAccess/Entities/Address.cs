using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolBus.DataAccess.Entities.Relationships;

namespace SchoolBus.DataAccess.Entities
{
    [Table("Addresses")]
    public class Address : IEntity
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

        [Required, Column(TypeName = "VARCHAR"), MaxLength(500)]
        public string Street { get; set; }

        public int ZipCode { get; set; }

        [Required, Column(TypeName = "VARCHAR"), MaxLength(500)]
        public string Neighborhood { get; set; }

        [Required, Column(TypeName = "VARCHAR"), MaxLength(500)]
        public string City { get; set; }

        [Required, Column(TypeName = "VARCHAR"), MaxLength(500)]
        public string State { get; set; }

        #endregion Properties

        #region Navigation Properties

        public virtual ICollection<DriverAddress> DriverAddresses { get; set; }

        public virtual ICollection<StudentTutorAddress> StudentTutorAddresses { get; set; }

        #endregion Navigation Properties
    }
}