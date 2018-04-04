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
            var categorias = new List<Categoria>
            {
               new Categoria {CategoriaID=1,Descricao="Enlatados",},               
               new Categoria {CategoriaID=2,Descricao="Refrigerados",},               
               new Categoria {CategoriaID=3,Descricao="Oleos",},               
            };
            categorias.ForEach(c => context.Categorias.Add(c));
            context.SaveChanges();

            var produtos = new List<Produto>
            {
                new Produto{ProdutoID=1,Nome = "Sopa",CategoriaID=1},
                new Produto{ProdutoID=2,Nome = "Peixe",CategoriaID=2},
                new Produto{ProdutoID=3,Nome = "Oleo de soja",CategoriaID=1}                
            };
            produtos.ForEach(p => context.Produtos.Add(p));
            context.SaveChanges();



            var utilisateurs = new List<Utilisateur>
            {
                new Utilisateur{NomUtilisateur = "Luis",Password="123",PasswordRepeated="123", TypeUtilisateur = TypeUtilisateur.Administrateur},
                new Utilisateur{NomUtilisateur = "Ben", Password="123",PasswordRepeated="123",TypeUtilisateur = TypeUtilisateur.Membre},
                new Utilisateur{NomUtilisateur = "Bob", Password="123",PasswordRepeated="123",TypeUtilisateur = TypeUtilisateur.Membre}
            };
            utilisateurs.ForEach(u => context.Utilisateurs.Add(u));
            context.SaveChanges();
        }

    }
}