namespace CalcadosNosSeusPes
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelSapato : DbContext
    {
        // Your context has been configured to use a 'ModelSapato' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CalcadosNosSeusPes.ModelSapato' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelSapato' 
        // connection string in the application configuration file.
        public ModelSapato()
            : base("name=ModelSapato")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<PessoaFisica> PessoasF { get; set; }
        public virtual DbSet<PessoaJuridica> PessoasJ { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Modelo> Modelos { get; set; }
        public virtual DbSet<Sapatos> Estoque { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}