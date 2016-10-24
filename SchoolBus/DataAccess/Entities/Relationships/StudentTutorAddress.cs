using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBus.DataAccess.Entities.Relationships
{
    [Table("StudentTutorAddresses")]
    public class StudentTutorAddress : IEntityRelationship<StudentTutor, Address>
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

        [Column("StudentTutorId"), Index("UQ_StudentTutorId_AddressId", 1, IsUnique = true)]
        public int LeftEntityId { get; set; }

        [ForeignKey("LeftEntityId")]
        public virtual StudentTutor LeftEntity { get; set; }

        [Column("AddressId"), Index("UQ_StudentTutorId_AddressId", 2, IsUnique = true)]
        public int RightEntityId { get; set; }

        [ForeignKey("RightEntityId")]
        public virtual Address RightEntity { get; set; }

        #endregion IEntityRelationship Properties
    }
}