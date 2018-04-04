using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;



namespace UIConsole
{
    public class ProdutoAplicacao
    {
        public DbProduto banco { get; set; }

        public ProdutoAplicacao()
        {
            banco = new DbProduto();
        }
        

        public void Salvar (Produto p)
        {
            //Salva e adiciona um produto na tabela Produto
            banco.Produtos.Add(p);
            banco.SaveChanges();
        }
        public IEnumerable<Produto> Listar()
        {
            //Retorna uma lista de todas entidades da tabela Produto
            return banco.Produtos.ToList();
        }
        public void Alterar(Produto p)
        {
            //Consulta no  banco a entidade que se quer alterar 
            Produto produoToEdit = banco.Produtos.Where(x => x.Id == p.Id).First();
            produoToEdit.nome = p.nome;
            banco.SaveChanges();
        }
        public void Excluir(int id)
        {
            //Consulta no  banco a entidade que se quer alterar 
            Produto produoToDelite = banco.Produtos.Where(x => x.Id == id).First();
            banco.Set<Produto>().Remove(produoToDelite);
            banco.SaveChanges();
        }



    }//fin class
}
