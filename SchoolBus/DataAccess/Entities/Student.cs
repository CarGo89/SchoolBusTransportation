using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolBus.DataAccess.Entities.Relationships;

namespace SchoolBus.DataAccess.Entities
{
    [Table("Students")]
    public class Student : User
    {
        #region Navigation Properties

        public virtual ICollection<SchoolYearStudent> SchoolYearStudents { get; set; }

        #endregion Navigation Properties
    }
}