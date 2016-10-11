namespace SchoolBusWeb.Utilities
{
    public sealed class SettingsManager : ISettingsManager
    {
        #region Fields

        private static SettingsManager _instance;

        #endregion Fields

        #region Properties

        public static SettingsManager Instance
        {
            get
            {
                _instance = _instance ?? new SettingsManager();

                return _instance;
            }
        }

        public int AdmninistratorRoleId { get; private set; }

        public int DriverRoleId { get; private set; }

        public int TutorRoleId { get; private set; }

        #endregion Properties

        #region Constructors

        private SettingsManager()
        {
            AdmninistratorRoleId = 1;
            DriverRoleId = 2;
            TutorRoleId = 3;
        }

        #endregion Constructors
    }
}