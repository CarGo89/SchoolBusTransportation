using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolBus.DataAccess.Entities.Relationships;

namespace SchoolBus.DataAccess.Entities
{
    [Table("Busses")]
    public class Bus : IEntity
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
        public string Manufacturer { get; set; }

        public int Year { get; set; }

        [Required, Column(TypeName = "VARCHAR"), MaxLength(20)]
        public string Registration { get; set; }

        [Required, Column(TypeName = "VARCHAR"), MaxLength(500)]
        public string Color { get; set; }

        public int Capacity { get; set; }

        #endregion Properties

        #region Navigation Properties

        public virtual ICollection<DriverBus> DriverBusses { get; set; }

        #endregion Navigation Properties
    }
}