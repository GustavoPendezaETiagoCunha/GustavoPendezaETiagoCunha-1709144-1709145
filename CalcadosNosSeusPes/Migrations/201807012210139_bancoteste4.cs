namespace CalcadosNosSeusPes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bancoteste4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendas", "DataVenda", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendas", "DataVenda", c => c.DateTime(nullable: false));
        }
    }
}
