using CadastroDeProdutos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CadastroDeProdutos.DAL
{
    public class ProdutoContexto : DbContext
    {
        public ProdutoContexto() : base("ChaineProduto") { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }    


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}