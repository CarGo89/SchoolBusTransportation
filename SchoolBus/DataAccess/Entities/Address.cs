using System;
using System.Collections.Generic;
using SchoolBus.DataAccess.Entities.Relationships;

namespace SchoolBus.DataAccess.Entities
{
    public class Address : IEntity
    {
        #region IEntity Properties

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedById { get; set; }

        public virtual Person CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int UpdatedById { get; set; }

        public virtual Person UpdatedBy { get; set; }

        public DateTime DeactivatedAt { get; set; }

        public int DeactivatedById { get; set; }

        public virtual Person DeactivatedBy { get; set; }

        #endregion IEntity Properties

        #region Properties

        public string Street { get; set; }

        public int ZipCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        #endregion Properties

        #region Navigation Properties

        public virtual ICollection<DriverAddress> DriverAddresses { get; set; }

        public virtual ICollection<StudentTutorAddress> StudentTutorAddresses { get; set; }

        #endregion Navigation Properties
    }
}