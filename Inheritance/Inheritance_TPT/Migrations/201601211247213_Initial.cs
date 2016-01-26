namespace Inheritance_TPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Subject = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.People", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.People", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "ID", "dbo.People");
            DropForeignKey("dbo.Teacher", "ID", "dbo.People");
            DropIndex("dbo.Student", new[] { "ID" });
            DropIndex("dbo.Teacher", new[] { "ID" });
            DropTable("dbo.Student");
            DropTable("dbo.Teacher");
            DropTable("dbo.People");
        }
    }
}
