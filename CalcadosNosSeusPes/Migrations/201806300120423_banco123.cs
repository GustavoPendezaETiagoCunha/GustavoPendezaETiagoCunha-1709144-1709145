namespace CalcadosNosSeusPes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco123 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MarcaMod = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Modeloes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipoModelo = c.String(),
                        MarcaId = c.Int(nullable: false),
                        Cadarco = c.Boolean(nullable: false),
                        Material = c.String(),
                        Cor = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marcas", t => t.MarcaId, cascadeDelete: true)
                .Index(t => t.MarcaId);
            
            CreateTable(
                "dbo.PessoaFisicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cpf = c.String(),
                        Nome = c.String(),
                        Fone = c.String(),
                        Cep = c.String(),
                        Endereco = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PessoaJuridicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cnpj = c.String(),
                        Nome = c.String(),
                        Fone = c.String(),
                        Cep = c.String(),
                        Endereco = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modeloes", "MarcaId", "dbo.Marcas");
            DropIndex("dbo.Modeloes", new[] { "MarcaId" });
            DropTable("dbo.PessoaJuridicas");
            DropTable("dbo.PessoaFisicas");
            DropTable("dbo.Modeloes");
            DropTable("dbo.Marcas");
        }
    }
}
