using System;
using SchoolBusWeb.Models.Validations;

namespace SchoolBusWeb.Models
{
    public abstract class User : ModelBase
    {
        #region Properties

        [RequiredField("Nombre", AllowEmptyStrings = false)]
        [MaxLengthField(500, "Nombre")]
        public virtual string FirstName { get; set; }

        [MaxLengthField(500, "Nombre")]
        public virtual string MiddleName { get; set; }

        [RequiredField("Apellido Paterno", AllowEmptyStrings = false)]
        [MaxLengthField(500, "Apellido Paterno")]
        public virtual string LastName { get; set; }

        [RequiredField("Apellido Materno", AllowEmptyStrings = false)]
        [MaxLengthField(500, "Apellido Materno")]
        public virtual string SecondLastName { get; set; }

        public virtual DateTime? BirthDate { get; set; }

        #endregion Properties
    }
}