namespace iTasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationmain : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tarefas", "DataCriacao", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tarefas", "DataCriacao", c => c.Int(nullable: false));
        }
    }
}
