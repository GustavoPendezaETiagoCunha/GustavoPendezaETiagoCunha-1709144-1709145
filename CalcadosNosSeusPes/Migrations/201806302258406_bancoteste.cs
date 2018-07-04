namespace CalcadosNosSeusPes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bancoteste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sapatos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModeloId = c.Int(nullable: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QntDisponivel = c.Int(nullable: false),
                        Tamanho = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Modeloes", t => t.ModeloId, cascadeDelete: true)
                .Index(t => t.ModeloId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sapatos", "ModeloId", "dbo.Modeloes");
            DropIndex("dbo.Sapatos", new[] { "ModeloId" });
            DropTable("dbo.Sapatos");
        }
    }
}
