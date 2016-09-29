namespace SchoolBus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedById = c.Int(),
                        UpdatedAt = c.DateTime(nullable: false),
                        UpdatedById = c.Int(),
                        DeactivatedAt = c.DateTime(),
                        DeactivatedById = c.Int(),
                        Street = c.String(maxLength: 500, unicode: false),
                        ZipCode = c.Int(nullable: false),
                        City = c.String(maxLength: 500, unicode: false),
                        State = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.DeactivatedById)
                .ForeignKey("dbo.Users", t => t.UpdatedById)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById)
                .Index(t => t.DeactivatedById);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedById = c.Int(),
                        UpdatedAt = c.DateTime(nullable: false),
                        UpdatedById = c.Int(),
                        DeactivatedAt = c.DateTime(),
                        DeactivatedById = c.Int(),
                        FirstName = c.String(maxLength: 500, unicode: false),
                        MiddleName = c.String(maxLength: 500, unicode: false),
                        LastName = c.String(maxLength: 500, unicode: false),
                        SecondLastName = c.String(maxLength: 500, unicode: false),
                        BirthDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.DeactivatedById)
                .ForeignKey("dbo.Users", t => t.UpdatedById)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById)
                .Index(t => t.DeactivatedById);
            
            CreateTable(
                "dbo.SchoolYearDrivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedById = c.Int(),
                        UpdatedAt = c.DateTime(nullable: false),
                        UpdatedById = c.Int(),
                        DeactivatedAt = c.DateTime(),
                        DeactivatedById = c.Int(),
                        SchoolYearId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.DeactivatedById)
                .ForeignKey("dbo.SchoolYears", t => t.SchoolYearId)
                .ForeignKey("dbo.Drivers", t => t.DriverId)
                .ForeignKey("dbo.Users", t => t.UpdatedById)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById)
                .Index(t => t.DeactivatedById)
                .Index(t => t.SchoolYearId)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.DriverAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedById = c.Int(),
                        UpdatedAt = c.DateTime(nullable: false),
                        UpdatedById = c.Int(),
                        DeactivatedAt = c.DateTime(),
                        DeactivatedById = c.Int(),
                        SchoolYearDriverId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.DeactivatedById)
                .ForeignKey("dbo.SchoolYearDrivers", t => t.SchoolYearDriverId, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UpdatedById)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById)
                .Index(t => t.DeactivatedById)
                .Index(t => t.SchoolYearDriverId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.DriverBusses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedById = c.Int(),
                        UpdatedAt = c.DateTime(nullable: false),
                        UpdatedById = c.Int(),
                        DeactivatedAt = c.DateTime(),
                        DeactivatedById = c.Int(),
                        SchoolYearDriverId = c.Int(nullable: false),
                        BusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.DeactivatedById)
                .ForeignKey("dbo.SchoolYearDrivers", t => t.SchoolYearDriverId, cascadeDelete: true)
                .ForeignKey("dbo.Busses", t => t.SchoolYearDriverId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UpdatedById)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById)
                .Index(t => t.DeactivatedById)
                .Index(t => t.SchoolYearDriverId);
            
            CreateTable(
                "dbo.Busses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedById = c.Int(),
                        UpdatedAt = c.DateTime(nullable: false),
                        UpdatedById = c.Int(),
                        DeactivatedAt = c.DateTime(),
                        DeactivatedById = c.Int(),
                        Manufacturer = c.String(maxLength: 500, unicode: false),
                        Year = c.Int(nullable: false),
                        Registration = c.String(maxLength: 20, unicode: false),
                        Color = c.String(maxLength: 500, unicode: false),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.DeactivatedById)
                .ForeignKey("dbo.Users", t => t.UpdatedById)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById)
                .Index(t => t.DeactivatedById);
            
            CreateTable(
                "dbo.DriverStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedById = c.Int(),
                        UpdatedAt = c.DateTime(nullable: false),
                        UpdatedById = c.Int(),
                        DeactivatedAt = c.DateTime(),
                        DeactivatedById = c.Int(),
                        SchoolYearDriverId = c.Int(nullable: false),
                        SchoolYearStudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.DeactivatedById)
                .ForeignKey("dbo.SchoolYearDrivers", t => t.SchoolYearDriverId, cascadeDelete: true)
                .ForeignKey("dbo.SchoolYearStudents", t => t.SchoolYearStudentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UpdatedById)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById)
                .Index(t => t.DeactivatedById)
                .Index(t => t.SchoolYearDriverId)
                .Index(t => t.SchoolYearStudentId);
            
            CreateTable(
                "dbo.SchoolYearStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedById = c.Int(),
                        UpdatedAt = c.DateTime(nullable: false),
                        UpdatedById = c.Int(),
                        DeactivatedAt = c.DateTime(),
                        DeactivatedById = c.Int(),
                        SchoolYearId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.DeactivatedById)
                .ForeignKey("dbo.SchoolYears", t => t.SchoolYearId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Users", t => t.UpdatedById)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById)
                .Index(t => t.DeactivatedById)
                .Index(t => t.SchoolYearId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.SchoolYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedById = c.Int(),
                        UpdatedAt = c.DateTime(nullable: false),
                        UpdatedById = c.Int(),
                        DeactivatedAt = c.DateTime(),
                        DeactivatedById = c.Int(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.DeactivatedById)
                .ForeignKey("dbo.Users", t => t.UpdatedById)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById)
                .Index(t => t.DeactivatedById);
            
            CreateTable(
                "dbo.StudentTutors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedById = c.Int(),
                        UpdatedAt = c.DateTime(nullable: false),
                        UpdatedById = c.Int(),
                        DeactivatedAt = c.DateTime(),
                        DeactivatedById = c.Int(),
                        SchoolYearStudentId = c.Int(nullable: false),
                        TutorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.DeactivatedById)
                .ForeignKey("dbo.SchoolYearStudents", t => t.SchoolYearStudentId, cascadeDelete: true)
                .ForeignKey("dbo.Tutors", t => t.TutorId)
                .ForeignKey("dbo.Users", t => t.UpdatedById)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById)
                .Index(t => t.DeactivatedById)
                .Index(t => t.SchoolYearStudentId)
                .Index(t => t.TutorId);
            
            CreateTable(
                "dbo.StudentTutorAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedById = c.Int(),
                        UpdatedAt = c.DateTime(nullable: false),
                        UpdatedById = c.Int(),
                        DeactivatedAt = c.DateTime(),
                        DeactivatedById = c.Int(),
                        StudentTutorId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.DeactivatedById)
                .ForeignKey("dbo.StudentTutors", t => t.StudentTutorId, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UpdatedById)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById)
                .Index(t => t.DeactivatedById)
                .Index(t => t.StudentTutorId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Tutors",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tutors", "Id", "dbo.Users");
            DropForeignKey("dbo.Students", "Id", "dbo.Users");
            DropForeignKey("dbo.Drivers", "Id", "dbo.Users");
            DropForeignKey("dbo.Addresses", "UpdatedById", "dbo.Users");
            DropForeignKey("dbo.Addresses", "DeactivatedById", "dbo.Users");
            DropForeignKey("dbo.Addresses", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.SchoolYearDrivers", "UpdatedById", "dbo.Users");
            DropForeignKey("dbo.SchoolYearDrivers", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.DriverStudents", "UpdatedById", "dbo.Users");
            DropForeignKey("dbo.SchoolYearStudents", "UpdatedById", "dbo.Users");
            DropForeignKey("dbo.StudentTutors", "UpdatedById", "dbo.Users");
            DropForeignKey("dbo.StudentTutorAddresses", "UpdatedById", "dbo.Users");
            DropForeignKey("dbo.StudentTutorAddresses", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.StudentTutorAddresses", "StudentTutorId", "dbo.StudentTutors");
            DropForeignKey("dbo.StudentTutorAddresses", "DeactivatedById", "dbo.Users");
            DropForeignKey("dbo.StudentTutorAddresses", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.StudentTutors", "TutorId", "dbo.Tutors");
            DropForeignKey("dbo.StudentTutors", "SchoolYearStudentId", "dbo.SchoolYearStudents");
            DropForeignKey("dbo.StudentTutors", "DeactivatedById", "dbo.Users");
            DropForeignKey("dbo.StudentTutors", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.SchoolYearStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.SchoolYears", "UpdatedById", "dbo.Users");
            DropForeignKey("dbo.SchoolYearStudents", "SchoolYearId", "dbo.SchoolYears");
            DropForeignKey("dbo.SchoolYearDrivers", "SchoolYearId", "dbo.SchoolYears");
            DropForeignKey("dbo.SchoolYears", "DeactivatedById", "dbo.Users");
            DropForeignKey("dbo.SchoolYears", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.DriverStudents", "SchoolYearStudentId", "dbo.SchoolYearStudents");
            DropForeignKey("dbo.SchoolYearStudents", "DeactivatedById", "dbo.Users");
            DropForeignKey("dbo.SchoolYearStudents", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.DriverStudents", "SchoolYearDriverId", "dbo.SchoolYearDrivers");
            DropForeignKey("dbo.DriverStudents", "DeactivatedById", "dbo.Users");
            DropForeignKey("dbo.DriverStudents", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.DriverBusses", "UpdatedById", "dbo.Users");
            DropForeignKey("dbo.Busses", "UpdatedById", "dbo.Users");
            DropForeignKey("dbo.DriverBusses", "SchoolYearDriverId", "dbo.Busses");
            DropForeignKey("dbo.Busses", "DeactivatedById", "dbo.Users");
            DropForeignKey("dbo.Busses", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.DriverBusses", "SchoolYearDriverId", "dbo.SchoolYearDrivers");
            DropForeignKey("dbo.DriverBusses", "DeactivatedById", "dbo.Users");
            DropForeignKey("dbo.DriverBusses", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.DriverAddresses", "UpdatedById", "dbo.Users");
            DropForeignKey("dbo.DriverAddresses", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.DriverAddresses", "SchoolYearDriverId", "dbo.SchoolYearDrivers");
            DropForeignKey("dbo.DriverAddresses", "DeactivatedById", "dbo.Users");
            DropForeignKey("dbo.DriverAddresses", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.SchoolYearDrivers", "DeactivatedById", "dbo.Users");
            DropForeignKey("dbo.SchoolYearDrivers", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Users", "UpdatedById", "dbo.Users");
            DropForeignKey("dbo.Users", "DeactivatedById", "dbo.Users");
            DropForeignKey("dbo.Users", "CreatedById", "dbo.Users");
            DropIndex("dbo.Tutors", new[] { "Id" });
            DropIndex("dbo.Students", new[] { "Id" });
            DropIndex("dbo.Drivers", new[] { "Id" });
            DropIndex("dbo.StudentTutorAddresses", new[] { "AddressId" });
            DropIndex("dbo.StudentTutorAddresses", new[] { "StudentTutorId" });
            DropIndex("dbo.StudentTutorAddresses", new[] { "DeactivatedById" });
            DropIndex("dbo.StudentTutorAddresses", new[] { "UpdatedById" });
            DropIndex("dbo.StudentTutorAddresses", new[] { "CreatedById" });
            DropIndex("dbo.StudentTutors", new[] { "TutorId" });
            DropIndex("dbo.StudentTutors", new[] { "SchoolYearStudentId" });
            DropIndex("dbo.StudentTutors", new[] { "DeactivatedById" });
            DropIndex("dbo.StudentTutors", new[] { "UpdatedById" });
            DropIndex("dbo.StudentTutors", new[] { "CreatedById" });
            DropIndex("dbo.SchoolYears", new[] { "DeactivatedById" });
            DropIndex("dbo.SchoolYears", new[] { "UpdatedById" });
            DropIndex("dbo.SchoolYears", new[] { "CreatedById" });
            DropIndex("dbo.SchoolYearStudents", new[] { "StudentId" });
            DropIndex("dbo.SchoolYearStudents", new[] { "SchoolYearId" });
            DropIndex("dbo.SchoolYearStudents", new[] { "DeactivatedById" });
            DropIndex("dbo.SchoolYearStudents", new[] { "UpdatedById" });
            DropIndex("dbo.SchoolYearStudents", new[] { "CreatedById" });
            DropIndex("dbo.DriverStudents", new[] { "SchoolYearStudentId" });
            DropIndex("dbo.DriverStudents", new[] { "SchoolYearDriverId" });
            DropIndex("dbo.DriverStudents", new[] { "DeactivatedById" });
            DropIndex("dbo.DriverStudents", new[] { "UpdatedById" });
            DropIndex("dbo.DriverStudents", new[] { "CreatedById" });
            DropIndex("dbo.Busses", new[] { "DeactivatedById" });
            DropIndex("dbo.Busses", new[] { "UpdatedById" });
            DropIndex("dbo.Busses", new[] { "CreatedById" });
            DropIndex("dbo.DriverBusses", new[] { "SchoolYearDriverId" });
            DropIndex("dbo.DriverBusses", new[] { "DeactivatedById" });
            DropIndex("dbo.DriverBusses", new[] { "UpdatedById" });
            DropIndex("dbo.DriverBusses", new[] { "CreatedById" });
            DropIndex("dbo.DriverAddresses", new[] { "AddressId" });
            DropIndex("dbo.DriverAddresses", new[] { "SchoolYearDriverId" });
            DropIndex("dbo.DriverAddresses", new[] { "DeactivatedById" });
            DropIndex("dbo.DriverAddresses", new[] { "UpdatedById" });
            DropIndex("dbo.DriverAddresses", new[] { "CreatedById" });
            DropIndex("dbo.SchoolYearDrivers", new[] { "DriverId" });
            DropIndex("dbo.SchoolYearDrivers", new[] { "SchoolYearId" });
            DropIndex("dbo.SchoolYearDrivers", new[] { "DeactivatedById" });
            DropIndex("dbo.SchoolYearDrivers", new[] { "UpdatedById" });
            DropIndex("dbo.SchoolYearDrivers", new[] { "CreatedById" });
            DropIndex("dbo.Users", new[] { "DeactivatedById" });
            DropIndex("dbo.Users", new[] { "UpdatedById" });
            DropIndex("dbo.Users", new[] { "CreatedById" });
            DropIndex("dbo.Addresses", new[] { "DeactivatedById" });
            DropIndex("dbo.Addresses", new[] { "UpdatedById" });
            DropIndex("dbo.Addresses", new[] { "CreatedById" });
            DropTable("dbo.Tutors");
            DropTable("dbo.Students");
            DropTable("dbo.Drivers");
            DropTable("dbo.StudentTutorAddresses");
            DropTable("dbo.StudentTutors");
            DropTable("dbo.SchoolYears");
            DropTable("dbo.SchoolYearStudents");
            DropTable("dbo.DriverStudents");
            DropTable("dbo.Busses");
            DropTable("dbo.DriverBusses");
            DropTable("dbo.DriverAddresses");
            DropTable("dbo.SchoolYearDrivers");
            DropTable("dbo.Users");
            DropTable("dbo.Addresses");
        }
    }
}
