using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolBus.Entities.Relationships;

namespace SchoolBus.Entities
{
    public class Student : Person
    {
        public virtual ICollection<SchoolYearStudent> SchoolYearStudents { get; set; }
    }
}