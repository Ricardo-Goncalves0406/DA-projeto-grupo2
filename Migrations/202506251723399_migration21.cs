namespace iTasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Programadores", "IdUtilizador", c => c.Int(nullable: false));
            DropColumn("dbo.Programadores", "IdUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Programadores", "IdUser", c => c.Int(nullable: false));
            DropColumn("dbo.Programadores", "IdUtilizador");
        }
    }
}
