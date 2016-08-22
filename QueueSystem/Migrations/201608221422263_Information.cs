namespace QueueSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Information : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Information",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        codePatient = c.String(),
                        FullName = c.String(),
                        Age = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        IDCard = c.String(),
                        Address = c.String(),
                        IsPublic = c.Boolean(nullable: false),
                        Email = c.String(),
                        Mobile = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.HeThongSoes", "STTConfirmed", c => c.Int(nullable: false));
            AddColumn("dbo.HeThongSoes", "Timer", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HeThongSoes", "STTConfirmed");
            DropTable("dbo.Information");
        }
    }
}
