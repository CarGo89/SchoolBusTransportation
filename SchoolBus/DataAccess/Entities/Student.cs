using System.Collections.Generic;
using SchoolBus.DataAccess.Entities.Relationships;

namespace SchoolBus.DataAccess.Entities
{
    public class Student : Person
    {
        public virtual ICollection<SchoolYearStudent> SchoolYearStudents { get; set; }
    }
}