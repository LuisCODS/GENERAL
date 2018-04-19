using CadastroDeProdutos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TP.Models.DataModels;

namespace CadastroDeProdutos.DAL
{
    public class ProdutoInitializer : DropCreateDatabaseAlways<ProdutoContexto>
    {
        protected override void Seed(ProdutoContexto context)
        {
            //var categorias = new List<Categoria>
            //{
            //   new Categoria {CategoriaID=1,Descricao="Enlatados",},               
            //   new Categoria {CategoriaID=2,Descricao="Refrigerados",},               
            //   new Categoria {CategoriaID=3,Descricao="Oleos",},               
            //};
            //categorias.ForEach(c => context.Categorias.Add(c));
            //context.SaveChanges();

            var produtos = new List<Produto>
            {
                new Produto{ProdutoID=1,Nome = "Sopa",Categoria =Categoria.Enlatados},
                new Produto{ProdutoID=2,Nome = "Peixe",Categoria =Categoria.Alimentos},
                new Produto{ProdutoID=3,Nome = "Oleo de soja",Categoria =Categoria.Oleos}                
            };
            produtos.ForEach(p => context.Produtos.Add(p));
            context.SaveChanges();



            var utilisateurs = new List<Utilisateur>
            {
                new Utilisateur{NomUtilisateur = "Luis",Password="123",PasswordRepeated="123",},
                new Utilisateur{NomUtilisateur = "Ben", Password="123",PasswordRepeated="123",},
                new Utilisateur{NomUtilisateur = "Bob", Password="123",PasswordRepeated="123",}
            };
            utilisateurs.ForEach(u => context.Utilisateurs.Add(u));
            context.SaveChanges();
        }

    }
}