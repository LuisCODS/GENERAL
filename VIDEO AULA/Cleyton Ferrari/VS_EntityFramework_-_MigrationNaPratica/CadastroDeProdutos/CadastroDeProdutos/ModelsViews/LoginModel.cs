using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadastroDeProdutos.ModelsViews
{
    public class LoginModel
    {


        [Required]
        [DisplayName("Nom Utilisateur")]
        public string NomUtilisateur { get; set; }

        [Required]
        [DisplayName("Mot de passe")]
        public string Password { get; set; }

        [DisplayName("Memoriser le mot de passe ?")]
        public bool Persistant { get; set; }

        public bool Authentifie { get; set; }

    }
}