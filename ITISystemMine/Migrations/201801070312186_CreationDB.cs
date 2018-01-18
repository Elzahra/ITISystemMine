namespace ITISystemMine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreationDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        LecDuration = c.Int(nullable: false),
                        LabDuration = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Capacity = c.Int(nullable: false),
                        manger_key = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instructors", t => t.manger_key)
                .Index(t => t.Name, unique: true)
                .Index(t => t.manger_key);
            
            CreateTable(
                "dbo.DeptCrsInstrs",
                c => new
                    {
                        Department_key = c.Int(nullable: false),
                        Course_key = c.Int(nullable: false),
                        Instructor_key = c.Int(nullable: false),
                        Full_evaluation = c.Single(),
                    })
                .PrimaryKey(t => new { t.Department_key, t.Course_key, t.Instructor_key })
                .ForeignKey("dbo.Courses", t => t.Course_key, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Department_key, cascadeDelete: true)
                .ForeignKey("dbo.Instructors", t => t.Instructor_key, cascadeDelete: true)
                .Index(t => t.Department_key)
                .Index(t => t.Course_key)
                .Index(t => t.Instructor_key);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Degree = c.String(nullable: false),
                        Graduation_Year = c.Int(nullable: false),
                        Work_Status = c.Int(nullable: false),
                        Department_Key = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Key)
                .Index(t => t.Department_Key);
            
            CreateTable(
                "dbo.StdCrsInstrs",
                c => new
                    {
                        Student_key = c.Int(nullable: false),
                        Course_key = c.Int(nullable: false),
                        Instructor_key = c.Int(nullable: false),
                        Instr_evaluation = c.Int(),
                        Crs_evaluation = c.Int(),
                        Labs_Grade = c.Int(),
                    })
                .PrimaryKey(t => new { t.Student_key, t.Course_key, t.Instructor_key })
                .ForeignKey("dbo.Courses", t => t.Course_key, cascadeDelete: true)
                .ForeignKey("dbo.Instructors", t => t.Instructor_key, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_key, cascadeDelete: true)
                .Index(t => t.Student_key)
                .Index(t => t.Course_key)
                .Index(t => t.Instructor_key);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        Attend_Balance = c.Int(nullable: false),
                        Telephone = c.String(),
                        Address_Street = c.String(),
                        Address_City = c.String(),
                        Address_Country = c.String(),
                        Department_Key = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Key)
                .Index(t => t.UserName, unique: true)
                .Index(t => t.Department_Key);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DepartmentCourses",
                c => new
                    {
                        Department_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Department_Id, t.Course_Id })
                .ForeignKey("dbo.Departments", t => t.Department_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Department_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.InstructorCourses",
                c => new
                    {
                        Instructor_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructor_Id, t.Course_Id })
                .ForeignKey("dbo.Instructors", t => t.Instructor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Instructor_Id)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Instructors", "Department_Key", "dbo.Departments");
            DropForeignKey("dbo.Departments", "manger_key", "dbo.Instructors");
            DropForeignKey("dbo.DeptCrsInstrs", "Instructor_key", "dbo.Instructors");
            DropForeignKey("dbo.StdCrsInstrs", "Student_key", "dbo.Students");
            DropForeignKey("dbo.Students", "Department_Key", "dbo.Departments");
            DropForeignKey("dbo.StdCrsInstrs", "Instructor_key", "dbo.Instructors");
            DropForeignKey("dbo.StdCrsInstrs", "Course_key", "dbo.Courses");
            DropForeignKey("dbo.InstructorCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.InstructorCourses", "Instructor_Id", "dbo.Instructors");
            DropForeignKey("dbo.DeptCrsInstrs", "Department_key", "dbo.Departments");
            DropForeignKey("dbo.DeptCrsInstrs", "Course_key", "dbo.Courses");
            DropForeignKey("dbo.DepartmentCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.DepartmentCourses", "Department_Id", "dbo.Departments");
            DropIndex("dbo.InstructorCourses", new[] { "Course_Id" });
            DropIndex("dbo.InstructorCourses", new[] { "Instructor_Id" });
            DropIndex("dbo.DepartmentCourses", new[] { "Course_Id" });
            DropIndex("dbo.DepartmentCourses", new[] { "Department_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Students", new[] { "Department_Key" });
            DropIndex("dbo.Students", new[] { "UserName" });
            DropIndex("dbo.StdCrsInstrs", new[] { "Instructor_key" });
            DropIndex("dbo.StdCrsInstrs", new[] { "Course_key" });
            DropIndex("dbo.StdCrsInstrs", new[] { "Student_key" });
            DropIndex("dbo.Instructors", new[] { "Department_Key" });
            DropIndex("dbo.DeptCrsInstrs", new[] { "Instructor_key" });
            DropIndex("dbo.DeptCrsInstrs", new[] { "Course_key" });
            DropIndex("dbo.DeptCrsInstrs", new[] { "Department_key" });
            DropIndex("dbo.Departments", new[] { "manger_key" });
            DropIndex("dbo.Departments", new[] { "Name" });
            DropIndex("dbo.Courses", new[] { "Name" });
            DropTable("dbo.InstructorCourses");
            DropTable("dbo.DepartmentCourses");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Students");
            DropTable("dbo.StdCrsInstrs");
            DropTable("dbo.Instructors");
            DropTable("dbo.DeptCrsInstrs");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
        }
    }
}
