namespace iTasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gestores", "IdUtilizador", c => c.Int(nullable: false));
            AddColumn("dbo.Programadores", "IdUser", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Programadores", "IdUser");
            DropColumn("dbo.Gestores", "IdUtilizador");
        }
    }
}
