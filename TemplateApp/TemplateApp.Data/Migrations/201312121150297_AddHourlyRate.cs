namespace TemplateApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHourlyRate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbUser", "HourlyRate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbUser", "HourlyRate");
        }
    }
}
