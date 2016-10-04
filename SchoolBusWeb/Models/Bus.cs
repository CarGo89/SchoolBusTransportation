using SchoolBusWeb.Models.Validations;

namespace SchoolBusWeb.Models
{
    public class Bus : ModelBase
    {
        #region Properties

        [RequiredField("Marca", AllowEmptyStrings = false)]
        [MaxLengthField(500, "Marca")]
        public string Manufacturer { get; set; }

        [RangeRequiredField(1, int.MaxValue, "Año")]
        public int Year { get; set; }

        [RequiredField("Placa", AllowEmptyStrings = false)]
        [MaxLengthField(20, "Placa")]
        public string Registration { get; set; }

        [RequiredField("Color", AllowEmptyStrings = false)]
        [MaxLengthField(500, "Color")]
        public string Color { get; set; }

        [RangeRequiredField(1, int.MaxValue, "Capacidad")]
        public int Capacity { get; set; }

        #endregion Properties
    }
}