using CadastroDeProdutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroDeProdutos.ModelsViews
{
    public class UtilisateurViewModel
    {
        public Utilisateur Utilisateur { get; set; }
        public bool Authentifie { get; set; }
    }
}