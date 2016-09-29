﻿using System;
using System.Collections.Generic;

namespace SchoolBus.DataAccess.Entities.Relationships
{
    public class SchoolYearDriver : IEntityRelationship<SchoolYear, Driver>
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

        #region IEntityRelationship Properties

        public int LeftEntityId { get; set; }

        public virtual SchoolYear LeftEntity { get; set; }

        public int RightEntityId { get; set; }

        public virtual Driver RightEntity { get; set; }

        #endregion IEntityRelationship Properties

        #region Navigation Properties

        public virtual ICollection<DriverBus> DriverBusses { get; set; }

        public virtual ICollection<DriverAddress> DriverAddresses { get; set; }

        public virtual ICollection<DriverStudent> DriverStudents { get; set; }

        #endregion Navigation Properties
    }
}