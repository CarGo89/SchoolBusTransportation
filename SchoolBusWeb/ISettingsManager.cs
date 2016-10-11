namespace SchoolBusWeb
{
    public interface ISettingsManager
    {
        #region Properties

        int AdmninistratorRoleId { get; }

        int DriverRoleId { get; }

        int TutorRoleId { get; }

        #endregion Properties
    }
}