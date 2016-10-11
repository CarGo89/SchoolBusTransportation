using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolBusWeb.Models.Validations
{
    public class RangeRequiredFieldAttribute : RangeAttribute
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

        public RangeRequiredFieldAttribute(int minimum, int maximum, string fieldName)
            : base(minimum, maximum)
        {
            _fieldName = fieldName;

            SetErrorMessage();
        }

        public RangeRequiredFieldAttribute(double minimum, double maximum, string fieldName)
            : base(minimum, maximum)
        {
            _fieldName = fieldName;

            SetErrorMessage();
        }

        public RangeRequiredFieldAttribute(Type type, string minimum, string maximum, string fieldName)
            : base(type, minimum, maximum)
        {
            _fieldName = fieldName;

            SetErrorMessage();
        }

        #endregion Constructors

        #region Private Methods

        private void SetErrorMessage()
        {
            ErrorMessage = string.Format("{0} es requerido.", _fieldName);
        }

        #endregion Private Methods

        #region Public Methods

        public override bool IsValid(object value)
        {
            var modelProperty = value as ModelPropertyBase;
            var actualValue = modelProperty != null ? modelProperty.ValueBase : value;

            return base.IsValid(actualValue);
        }

        #endregion Public Methods
    }
}