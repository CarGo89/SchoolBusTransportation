using System;

namespace SchoolBusWeb.Models
{
    public class SchoolYear : ModelBase
    {
        #region Properties
        
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        #endregion Properties
    }
}