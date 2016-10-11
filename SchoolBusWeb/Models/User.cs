using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;
using SchoolBusWeb.Models.Validations;

namespace SchoolBusWeb.Models
{
    public abstract class User : ModelBase
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

        [RequiredField("Email", AllowEmptyStrings = false)]
        [MaxLengthField(500, "Email")]
        [EmailAddressValidator("Email")]
        public virtual ModelProperty<string> Email { get; set; }

        [MaxLengthField(500, "Contraseña")]
        public virtual ModelProperty<string> Password { get; set; }

        [DataType(DataType.Date)]
        public virtual string BirthDate { get; set; }

        [ScriptIgnore]
        public virtual int UserRoleId { get; set; }

        #endregion Properties
    }
}