using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBus.DataAccess.Entities
{
    [Table("UserRoles")]
    public class UserRole
    {
        #region IEntity Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        public virtual DateTime CreatedAt { get; set; }

        public virtual int? CreatedById { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual DateTime UpdatedAt { get; set; }

        public virtual int? UpdatedById { get; set; }

        public virtual User UpdatedBy { get; set; }

        public virtual DateTime? DeactivatedAt { get; set; }

        public virtual int? DeactivatedById { get; set; }

        public virtual User DeactivatedBy { get; set; }

        #endregion IEntity Properties

        #region Properties

        [Required, Column(TypeName = "VARCHAR"), MaxLength(500), Index("UQ_UserRole", IsUnique = true)]
        public string Role { get; set; }

        #endregion Properties
    }
}