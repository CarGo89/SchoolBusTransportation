using System;

namespace SchoolBus.DataAccess.Entities
{
    public interface IEntity
    {
        #region Properties

        int Id { get; set; }

        DateTime CreatedAt { get; set; }

        int? CreatedById { get; set; }

        User CreatedBy { get; set; }

        DateTime UpdatedAt { get; set; }

        int? UpdatedById { get; set; }

        User UpdatedBy { get; set; }

        DateTime? DeactivatedAt { get; set; }

        int? DeactivatedById { get; set; }

        User DeactivatedBy { get; set; }

        #endregion Properties
    }
}