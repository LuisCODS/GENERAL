using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CadastroDeProdutos.Models
{
    public enum Categoria
    {
        Enlatados, Alimentos, Oleos
    }

    public class Produto
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProdutoID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public Categoria Categoria { get; set; }

    }
}