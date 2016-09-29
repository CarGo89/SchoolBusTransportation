using SchoolBus.DataAccess;

namespace SchoolBus.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolBusDataModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SchoolBusDataModel context)
        {
        }
    }
}