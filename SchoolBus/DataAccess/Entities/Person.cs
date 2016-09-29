using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBus.DataAccess.Entities
{
    [NotMapped]
    public abstract class Person : IEntity
    {
        #region IEntity Properties

        public virtual int Id { get; set; }

        public virtual DateTime CreatedAt { get; set; }

        public virtual int CreatedById { get; set; }

        public virtual Person CreatedBy { get; set; }

        public virtual DateTime UpdatedAt { get; set; }

        public virtual int UpdatedById { get; set; }

        public virtual Person UpdatedBy { get; set; }

        public virtual DateTime DeactivatedAt { get; set; }

        public virtual int DeactivatedById { get; set; }

        public virtual Person DeactivatedBy { get; set; }

        #endregion IEntity Properties

        #region Properties

        public virtual string FirstName { get; set; }

        public virtual string MiddleName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string SecondLastName { get; set; }

        public virtual DateTime? BirthDate { get; set; }

        #endregion Properties
    }
}