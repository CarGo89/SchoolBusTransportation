using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolBus.DataAccess.Entities.Relationships;

namespace SchoolBus.DataAccess.Entities
{
    [Table("Tutors")]
    public class Tutor : User
    {
        #region Navigation Properties

        public virtual ICollection<StudentTutor> StudentTutors { get; set; }

        #endregion Navigation Properties
    }
}