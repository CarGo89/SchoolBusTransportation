using System;
using SchoolBus.DataAccess.Entities;

namespace SchoolBus.Tests.DataAccess.Entities
{
    public class TestEntity : IEntity
    {
        #region IEntity Properties

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

        public string Street { get; set; }

        public int ZipCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        #endregion Properties
    }
}