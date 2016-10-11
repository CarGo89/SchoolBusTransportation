using System.ComponentModel.DataAnnotations;

namespace SchoolBusWeb.Models.Validations
{
    public class EmailAddressValidatorAttribute : ValidationAttribute
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

        public EmailAddressValidatorAttribute(string fieldName)
        {
            _fieldName = fieldName;

            ErrorMessage = string.Format("{0} formato inválido.", _fieldName);
        }

        #endregion Constructors

        #region Public Methods

        public override bool IsValid(object value)
        {
            var modelProperty = value as ModelPropertyBase;
            var actualValue = modelProperty != null ? modelProperty.ValueBase : value;
            var emailAddressValidator = new EmailAddressAttribute();

            return emailAddressValidator.IsValid(actualValue);
        }

        #endregion Public Methods
    }
}