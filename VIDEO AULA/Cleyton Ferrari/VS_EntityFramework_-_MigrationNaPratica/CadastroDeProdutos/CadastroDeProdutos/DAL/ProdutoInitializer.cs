using CadastroDeProdutos.Models;
using System.Collections.Generic;
using System.Data.Entity;


namespace CadastroDeProdutos.DAL
{
    public class ProdutoInitializer : DropCreateDatabaseAlways<ProdutoContexto>
    {
        protected override void Seed(ProdutoContexto context)
        {
            var produtos = new List<Produto>
            {
                new Produto{Nome = "Sopa",Categoria =Categoria.Enlatados},
                new Produto{Nome = "Peixe",Categoria =Categoria.Alimentos},
                new Produto{Nome = "Oleo de soja",Categoria =Categoria.Oleos}                
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