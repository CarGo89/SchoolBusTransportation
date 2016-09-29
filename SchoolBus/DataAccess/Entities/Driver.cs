using System.Collections.Generic;
using SchoolBus.DataAccess.Entities.Relationships;

namespace SchoolBus.DataAccess.Entities
{
    public class Driver : Person
    {
        public virtual ICollection<SchoolYearDriver> SchoolYearDrivers { get; set; }
    }
}