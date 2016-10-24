using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBus.DataAccess.Entities.Relationships
{
    [Table("DriverBusses")]
    public class DriverBus : IEntityRelationship<SchoolYearDriver, Bus>
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

        [Column("SchoolYearDriverId"), Index("UQ_SchoolYearDriverId_BusId", 1, IsUnique = true)]
        public int LeftEntityId { get; set; }

        [ForeignKey("LeftEntityId")]
        public virtual SchoolYearDriver LeftEntity { get; set; }

        [Column("BusId"), Index("UQ_SchoolYearDriverId_BusId", 2, IsUnique = true)]
        public int RightEntityId { get; set; }

        [ForeignKey("LeftEntityId")]
        public virtual Bus RightEntity { get; set; }

        #endregion IEntityRelationship Properties
    }
}