namespace SchoolBusWeb.Models
{
    public abstract class ModelPropertyBase
    {
        #region Properties

        public virtual object ValueBase { get; set; }

        public virtual bool IsValid
        {
            get { return string.IsNullOrWhiteSpace(ErrorMessage); }
        }

        public virtual string ErrorMessage { get; set; }

        #endregion Properties

        #region Public Methods

        public override string ToString()
        {
            return string.Format("Value: {0}", ValueBase);
        }

        #endregion Public Methods
    }
}