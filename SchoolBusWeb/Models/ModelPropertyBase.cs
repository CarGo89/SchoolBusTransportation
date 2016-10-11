namespace SchoolBusWeb.Models
{
    public abstract class ModelPropertyBase
    {
        #region Properties

        public virtual object Value { get; set; }

        public virtual bool IsValid
        {
            get { return string.IsNullOrWhiteSpace(ErrorMessage); }
        }

        public virtual string ErrorMessage { get; set; }

        #endregion Properties
    }
}