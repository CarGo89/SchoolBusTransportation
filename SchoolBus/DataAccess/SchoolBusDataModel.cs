using System.Data.Entity;
using SchoolBus.DataAccess.Entities;
using SchoolBus.DataAccess.Entities.Relationships;

namespace SchoolBus.DataAccess
{
    internal class SchoolBusDataModel : DbContext
    {
        #region Constructors

        public SchoolBusDataModel()
            : base("name=SchoolBusDataModel")
        {
        }

        #endregion Constructors

        #region Properties

        public virtual DbSet<SchoolYear> SchoolYears { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Driver> Drivers { get; set; }

        public virtual DbSet<Tutor> Tutors { get; set; }

        public virtual DbSet<Bus> Busses { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<RelationshipTerm> RelationshipTerms { get; set; }

        public virtual DbSet<DriverAddress> DriverAddresses { get; set; }

        public virtual DbSet<DriverStudent> DriverStudents { get; set; }

        public virtual DbSet<DriverBus> DriverBusses { get; set; }

        public virtual DbSet<SchoolYearStudent> SchoolYearStudents { get; set; }

        public virtual DbSet<SchoolYearDriver> SchoolYearDrivers { get; set; }

        public virtual DbSet<StudentTutor> StudentTutors { get; set; }

        public virtual DbSet<StudentTutorAddress> StudentTutorAddresses { get; set; }

        #endregion Properties
    }
}