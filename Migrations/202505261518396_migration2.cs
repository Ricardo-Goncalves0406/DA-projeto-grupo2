namespace iTasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tarefas", "DataRealInicio", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tarefas", "DataRealFim", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tarefas", "DataRealFim", c => c.Int(nullable: false));
            AlterColumn("dbo.Tarefas", "DataRealInicio", c => c.Int(nullable: false));
        }
    }
}
