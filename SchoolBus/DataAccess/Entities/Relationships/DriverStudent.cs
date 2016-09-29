﻿using System;

namespace SchoolBus.DataAccess.Entities.Relationships
{
    public class DriverStudent : IEntityRelationship<SchoolYearDriver, SchoolYearStudent>
    {
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

        public int LeftEntityId { get; set; }

        public virtual SchoolYearDriver LeftEntity { get; set; }

        public int RightEntityId { get; set; }

        public virtual SchoolYearStudent RightEntity { get; set; }
    }
}