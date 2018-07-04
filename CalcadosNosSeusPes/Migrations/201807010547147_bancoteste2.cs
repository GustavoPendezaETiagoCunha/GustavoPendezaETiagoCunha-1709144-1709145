namespace CalcadosNosSeusPes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bancoteste2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PessoaFisicas", newName: "Pessoas");
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SapatoId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        DataVenda = c.DateTime(nullable: false),
                        PrecoTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Sapatos", t => t.SapatoId, cascadeDelete: true)
                .Index(t => t.SapatoId)
                .Index(t => t.ClienteId);
            
            AddColumn("dbo.Pessoas", "Cnpj", c => c.String());
            AddColumn("dbo.Pessoas", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.PessoaJuridicas");
        }
        
        public override void Down()
        {
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
            
            DropForeignKey("dbo.Vendas", "SapatoId", "dbo.Sapatos");
            DropForeignKey("dbo.Vendas", "ClienteId", "dbo.Pessoas");
            DropIndex("dbo.Vendas", new[] { "ClienteId" });
            DropIndex("dbo.Vendas", new[] { "SapatoId" });
            DropColumn("dbo.Pessoas", "Discriminator");
            DropColumn("dbo.Pessoas", "Cnpj");
            DropTable("dbo.Vendas");
            RenameTable(name: "dbo.Pessoas", newName: "PessoaFisicas");
        }
    }
}
