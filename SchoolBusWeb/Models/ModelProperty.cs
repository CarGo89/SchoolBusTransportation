namespace SchoolBusWeb.Models
{
    public sealed class ModelProperty<TValue> : ModelPropertyBase
    {
        #region Properties

        public override object Value
        {
            get { return GenericValue; }
            set { GenericValue = (TValue)value; }
        }

        public TValue GenericValue { get; set; }

        #endregion Properties

        #region Constructors

        public ModelProperty()
        {
        }

        public ModelProperty(TValue value)
        {
            GenericValue = value;
        }

        #endregion Constructors

        #region Implicit Operators

        public static implicit operator TValue(ModelProperty<TValue> property)
        {
            return property.GenericValue;
        }

        public static implicit operator ModelProperty<TValue>(TValue value)
        {
            return new ModelProperty<TValue>(value);
        }

        #endregion Implicit Operators
    }
}