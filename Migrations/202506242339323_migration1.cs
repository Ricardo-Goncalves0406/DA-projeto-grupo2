namespace iTasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Utilizadores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Departamento = c.Int(nullable: false),
                        IdGestor = c.Int(),
                        Gestores = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tarefas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        idGestor = c.Int(nullable: false),
                        idProgramador = c.Int(nullable: false),
                        OrdemExecucao = c.Int(nullable: false),
                        Descricao = c.String(),
                        DataPrevistaInicio = c.DateTime(nullable: false),
                        DataPrevistaFim = c.DateTime(nullable: false),
                        IdTipoTarefa = c.Int(nullable: false),
                        StoryPoints = c.Int(nullable: false),
                        DataRealInicio = c.DateTime(nullable: false),
                        DataRealFim = c.DateTime(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        EstadoAtual = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoTarefas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gestores",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        GereUtilizadores = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilizadores", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Programadores",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NivelExperiencia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilizadores", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Programadores", "Id", "dbo.Utilizadores");
            DropForeignKey("dbo.Gestores", "Id", "dbo.Utilizadores");
            DropIndex("dbo.Programadores", new[] { "Id" });
            DropIndex("dbo.Gestores", new[] { "Id" });
            DropTable("dbo.Programadores");
            DropTable("dbo.Gestores");
            DropTable("dbo.TipoTarefas");
            DropTable("dbo.Tarefas");
            DropTable("dbo.Utilizadores");
        }
    }
}
