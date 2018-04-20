//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Web;

//namespace CadastroDeProdutos.Models
//{

//    public class Categoria
//    {
//        [DatabaseGenerated(DatabaseGeneratedOption.None)]
//        public int CategoriaID { get; set; }

//        public string  Descricao { get; set; }

//        //public int ProdutoID { get; set; }
//        public virtual IEnumerable<Produto> Produtos { get; set; }

//    }
//}