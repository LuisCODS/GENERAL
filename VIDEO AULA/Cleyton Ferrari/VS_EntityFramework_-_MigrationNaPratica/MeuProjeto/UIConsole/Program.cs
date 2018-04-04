using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ProdutoAplicacao app = new ProdutoAplicacao();

            Produto p1 = new Produto();
            //p1.Id = 2;
            p1.nome = "Feijao preto";

            app.Salvar(p1);
            //app.Alterar(p1);
            //app.Excluir(2); 
            foreach (var produto in app.Listar())
	        {
                Console.WriteLine("{0} - {1}", produto.Id, produto.nome);
	        }                         
            Console.ReadKey();

        }
    }
}
