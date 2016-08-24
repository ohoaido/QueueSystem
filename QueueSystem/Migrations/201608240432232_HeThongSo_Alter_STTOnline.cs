namespace QueueSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HeThongSo_Alter_STTOnline : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HeThongSoes", "STTOnline", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HeThongSoes", "STTOnline");
        }
    }
}
