using System.Collections.Generic;
using SchoolBus.DataAccess.Entities.Relationships;

namespace SchoolBus.DataAccess.Entities
{
    public class Student : Person
    {
        #region Navigation Properties

        public virtual ICollection<SchoolYearStudent> SchoolYearStudents { get; set; }

        #endregion Navigation Properties
    }
}