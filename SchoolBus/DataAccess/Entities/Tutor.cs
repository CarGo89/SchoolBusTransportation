using System.Collections.Generic;
using SchoolBus.DataAccess.Entities.Relationships;

namespace SchoolBus.DataAccess.Entities
{
    public class Tutor : Person
    {
        #region Navigation Properties

        public virtual ICollection<StudentTutor> StudentTutors { get; set; }

        #endregion Navigation Properties
    }
}