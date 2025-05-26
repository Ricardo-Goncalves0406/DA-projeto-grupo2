namespace iTasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tarefas", "DataPrevistaInicio", c => c.DateTime());
            AlterColumn("dbo.Tarefas", "DataPrevistaFim", c => c.DateTime());
            AlterColumn("dbo.Tarefas", "DataRealInicio", c => c.DateTime());
            AlterColumn("dbo.Tarefas", "DataRealFim", c => c.DateTime());
            AlterColumn("dbo.Tarefas", "DataCriacao", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tarefas", "DataCriacao", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tarefas", "DataRealFim", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tarefas", "DataRealInicio", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tarefas", "DataPrevistaFim", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tarefas", "DataPrevistaInicio", c => c.DateTime(nullable: false));
        }
    }
}
