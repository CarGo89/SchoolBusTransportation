namespace SchoolBusWeb.Models
{
    public sealed class ModelProperty<TValue> : ModelPropertyBase
    {
        #region Properties

        public override object ValueBase
        {
            get { return Value; }
            set { Value = (TValue)value; }
        }

        public TValue Value { get; set; }

        #endregion Properties

        #region Constructors

        public ModelProperty()
        {
        }

        public ModelProperty(TValue value)
        {
            Value = value;
        }

        #endregion Constructors

        #region Public Methods

        public override string ToString()
        {
            return string.Format("Value: {0}", Value);
        }

        #endregion Public Methods

        #region Implicit Operators

        public static implicit operator TValue(ModelProperty<TValue> property)
        {
            return property.Value;
        }

        public static implicit operator ModelProperty<TValue>(TValue value)
        {
            return new ModelProperty<TValue>(value);
        }

        #endregion Implicit Operators
    }
}