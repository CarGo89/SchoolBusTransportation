using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolBus.DataAccess.Entities.Relationships;

namespace SchoolBus.DataAccess.Entities
{
    [Table("Drivers")]
    public class Driver : User
    {
        #region Navigation Properties

        public virtual ICollection<SchoolYearDriver> SchoolYearDrivers { get; set; }

        #endregion Navigation Properties
    }
}