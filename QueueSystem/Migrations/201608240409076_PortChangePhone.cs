namespace QueueSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PortChangePhone : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PortInfomaitonElectrics", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PortInfomaitonElectrics", "Phone", c => c.Int(nullable: false));
        }
    }
}
