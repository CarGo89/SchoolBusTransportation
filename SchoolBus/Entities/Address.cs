using System;

namespace SchoolBus.Entities
{
    public class Address : IEntity
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

        public string Street { get; set; }

        public int ZipCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }
    }
}