using System.ComponentModel.DataAnnotations;
using SchoolBusWeb.Models.Validations;

namespace SchoolBusWeb.Models
{
    public class Student : ModelBase
    {
        #region Properties

        [RequiredField("Nombre", AllowEmptyStrings = false)]
        [MaxLengthField(500, "Nombre")]
        public virtual ModelProperty<string> FirstName { get; set; }

        [MaxLengthField(500, "Nombre")]
        public virtual ModelProperty<string> MiddleName { get; set; }

        [RequiredField("Apellido Paterno", AllowEmptyStrings = false)]
        [MaxLengthField(500, "Apellido Paterno")]
        public virtual ModelProperty<string> LastName { get; set; }

        [RequiredField("Apellido Materno", AllowEmptyStrings = false)]
        [MaxLengthField(500, "Apellido Materno")]
        public virtual ModelProperty<string> SecondLastName { get; set; }

        [DataType(DataType.Date)]
        public virtual string BirthDate { get; set; }

        #endregion Properties
    }
}