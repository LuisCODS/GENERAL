using System;
using System.Collections.Generic;
using System.Data.Entity;//
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIConsole
{
    public class DbProduto: DbContext
    {

        //Representa a tabela e mapea as propriedades para a basa de dados
        public DbSet<Produto> Produtos { get; set; }


    }
}
