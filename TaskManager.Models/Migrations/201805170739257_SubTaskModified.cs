namespace TaskManager.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubTaskModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubTasks", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubTasks", "Description");
        }
    }
}
