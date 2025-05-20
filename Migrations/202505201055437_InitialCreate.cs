namespace iTasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tarefas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idGestor = c.Int(nullable: false),
                        idProgramador = c.Int(nullable: false),
                        OrdemExecucao = c.Int(nullable: false),
                        Descricao = c.String(),
                        DataPrevistaInicio = c.DateTime(nullable: false),
                        DataPrevistaFim = c.DateTime(nullable: false),
                        IdTipoTarefa = c.Int(nullable: false),
                        StoryPoints = c.Int(nullable: false),
                        DataRealInicio = c.Int(nullable: false),
                        DataRealFim = c.Int(nullable: false),
                        DataCriacao = c.Int(nullable: false),
                        EstadoAtual = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TipoTarefas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Utilizadors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        IdGestor = c.Int(),
                        Gestores = c.Int(nullable: false),
                        Departamento = c.String(),
                        GereUtilizadores = c.Boolean(),
                        NivelExperiencia = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Utilizadors");
            DropTable("dbo.TipoTarefas");
            DropTable("dbo.Tarefas");
        }
    }
}
