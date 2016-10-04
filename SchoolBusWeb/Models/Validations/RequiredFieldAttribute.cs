using System.ComponentModel.DataAnnotations;

namespace SchoolBusWeb.Models.Validations
{
    public class RequiredFieldAttribute : RequiredAttribute
    {
        #region Fields

        private readonly string _fieldName;

        #endregion Fields

        #region Constructors

        public RequiredFieldAttribute(string fieldName)
        {
            _fieldName = fieldName;

            ErrorMessage = string.Format("{0} es requerido.", _fieldName);
        }

        #endregion Constructors

        #region Properties

        public string FieldName
        {
            get { return _fieldName; }
        }

        #endregion Properties
    }
}