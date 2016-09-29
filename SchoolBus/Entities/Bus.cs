using System;

namespace SchoolBus.Entities
{
    public class Bus : IEntity
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

        public string Manufacturer { get; set; }

        public int Year { get; set; }

        public string Registration { get; set; }

        public string Color { get; set; }

        public int Capacity { get; set; }
    }
}