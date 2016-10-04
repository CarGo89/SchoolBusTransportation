using SchoolBusWeb.Models.Validations;

namespace SchoolBusWeb.Models
{
    public class RelationshipTerm : ModelBase
    {
        #region Properties

        [RequiredField("Parentezco", AllowEmptyStrings = false)]
        [MaxLengthField(500, "Parentezco")]
        public string Term { get; set; }

        #endregion Properties
    }
}