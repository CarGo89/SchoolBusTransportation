using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBus.DataAccess.Entities
{
    [Table("RelationshipTerms")]
    public class RelationshipTerm : IEntity
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

        [Column(TypeName = "VARCHAR"), MaxLength(500), Index("UQ_RelationshipTerm", IsUnique = true)]
        public string Term { get; set; }

        #endregion Properties
    }
}