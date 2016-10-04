using SchoolBusWeb.Models.Validations;

namespace SchoolBusWeb.Models
{
    public class Address : ModelBase
    {
        #region Properties

        [RequiredField("Calle", AllowEmptyStrings = false)]
        [MaxLengthField(500, "Calle")]
        public string Street { get; set; }

        [RangeRequiredFieldAttribute(1, int.MaxValue, "Código Postal")]
        public int ZipCode { get; set; }

        [RequiredField("Ciudad", AllowEmptyStrings = false)]
        [MaxLengthField(500, "Ciudad")]
        public string City { get; set; }

        [RequiredField("Estado", AllowEmptyStrings = false)]
        [MaxLengthField(500, "Estado")]
        public string State { get; set; }

        #endregion Properties
    }
}