using System;

namespace SchoolBus.DataAccess.Entities
{
    public interface IEntity
    {
        int Id { get; set; }

        DateTime CreatedAt { get; set; }

        int CreatedById { get; set; }

        Person CreatedBy { get; set; }

        DateTime UpdatedAt { get; set; }

        int UpdatedById { get; set; }

        Person UpdatedBy { get; set; }

        DateTime DeactivatedAt { get; set; }

        int DeactivatedById { get; set; }

        Person DeactivatedBy { get; set; }
    }
}