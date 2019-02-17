namespace TaskManager.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialCommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        taskId = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.taskId, cascadeDelete: true)
                .Index(t => t.taskId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubTasks", "taskId", "dbo.Tasks");
            DropIndex("dbo.SubTasks", new[] { "taskId" });
            DropTable("dbo.Tasks");
            DropTable("dbo.SubTasks");
        }
    }
}
