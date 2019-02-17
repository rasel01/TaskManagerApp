namespace TaskManager.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubTasks", "Timeline", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Tasks", "DueDate", c => c.DateTime(nullable: false, storeType: "date"));
            CreateIndex("dbo.SubTasks", "Timeline");
            CreateIndex("dbo.Tasks", "DueDate");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tasks", new[] { "DueDate" });
            DropIndex("dbo.SubTasks", new[] { "Timeline" });
            AlterColumn("dbo.Tasks", "DueDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.SubTasks", "Timeline");
        }
    }
}
