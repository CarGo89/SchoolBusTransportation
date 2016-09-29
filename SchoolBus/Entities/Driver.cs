using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolBus.Entities.Relationships;

namespace SchoolBus.Entities
{
    public class Driver : Person
    {
        public virtual ICollection<SchoolYearDriver> SchoolYearDrivers { get; set; }
    }
}