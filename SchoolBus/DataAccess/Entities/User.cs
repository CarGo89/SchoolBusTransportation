using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBus.DataAccess.Entities
{
    [Table("Users")]
    public abstract class User : IEntity
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

        [Required, Column(TypeName = "VARCHAR"), MaxLength(500)]
        public virtual string FirstName { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(500)]
        public virtual string MiddleName { get; set; }

        [Required, Column(TypeName = "VARCHAR"), MaxLength(500)]
        public virtual string LastName { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(500)]
        public virtual string SecondLastName { get; set; }

        public virtual DateTime? BirthDate { get; set; }

        [Required, Column(TypeName = "VARCHAR"), MaxLength(500)]
        public virtual string Email { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(500)]
        public virtual string Password { get; set; }

        #endregion Properties

        #region Navigation Properties

        public int UserRoleId { get; set; }

        public virtual UserRole UserRole { get; set; }

        #endregion Navigation Properties
    }
}