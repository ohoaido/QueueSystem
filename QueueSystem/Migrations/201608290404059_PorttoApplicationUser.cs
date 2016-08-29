namespace QueueSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PorttoApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PortInfomaitonElectrics", "Userid", c => c.String(maxLength: 128));
            CreateIndex("dbo.PortInfomaitonElectrics", "Userid");
            AddForeignKey("dbo.PortInfomaitonElectrics", "Userid", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PortInfomaitonElectrics", "Userid", "dbo.AspNetUsers");
            DropIndex("dbo.PortInfomaitonElectrics", new[] { "Userid" });
            DropColumn("dbo.PortInfomaitonElectrics", "Userid");
        }
    }
}
