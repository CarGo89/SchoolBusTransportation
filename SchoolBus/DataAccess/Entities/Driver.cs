using System.Collections.Generic;
using SchoolBus.DataAccess.Entities.Relationships;

namespace SchoolBus.DataAccess.Entities
{
    public class Driver : Person
    {
        #region Navigation Properties

        public virtual ICollection<SchoolYearDriver> SchoolYearDrivers { get; set; }

        #endregion Navigation Properties
    }
}