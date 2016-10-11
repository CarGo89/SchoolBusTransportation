using System.ComponentModel.DataAnnotations;

namespace SchoolBusWeb.Models.Validations
{
    public class MaxLengthFieldAttribute : MaxLengthAttribute
    {
        #region Fields

        private readonly string _fieldName;

        #endregion Fields

        #region Properties

        public string FieldName
        {
            get { return _fieldName; }
        }

        #endregion Properties

        #region Constructors

        public MaxLengthFieldAttribute(int length, string fieldName)
            : base(length)
        {
            _fieldName = fieldName;

            ErrorMessage = string.Format("{0} excede la longitud de {1} caracteres.", _fieldName, length);
        }

        #endregion Constructors

        #region Public Methods

        public override bool IsValid(object value)
        {
            var modelProperty = value as ModelPropertyBase;

            return base.IsValid(modelProperty != null ? modelProperty.ValueBase : value);
        }

        #endregion Public Methods
    }
}