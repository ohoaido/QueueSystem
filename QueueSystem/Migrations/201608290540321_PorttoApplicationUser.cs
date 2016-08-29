namespace QueueSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PorttoApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PortInfomaitonElectricID", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "PortInfomaitonElectricID");
            AddForeignKey("dbo.AspNetUsers", "PortInfomaitonElectricID", "dbo.PortInfomaitonElectrics", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "PortInfomaitonElectricID", "dbo.PortInfomaitonElectrics");
            DropIndex("dbo.AspNetUsers", new[] { "PortInfomaitonElectricID" });
            DropColumn("dbo.AspNetUsers", "PortInfomaitonElectricID");
        }
    }
}
