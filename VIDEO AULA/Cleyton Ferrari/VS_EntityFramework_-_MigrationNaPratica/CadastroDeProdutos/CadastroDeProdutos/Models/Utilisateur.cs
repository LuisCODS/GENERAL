using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using TP.Models.DataModels;

namespace CadastroDeProdutos.Models
{
    public class Utilisateur
    {

        //public Utilisateur()
        //{
        //    this.TypeUtilisateur = TypeUtilisateur.Membre;
        //}

        [Key]
        public int UtilisateurID { get; set; }

        //public int ProdutoID { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }



        [Index(IsUnique = true)]
        [Required(ErrorMessage = "Veuillez entrer votre nom s.t.p.")]
        [DisplayName("Nom Utilisateur")]
        [StringLength(30, ErrorMessage = "Must be between 3 and 30 characters", MinimumLength = 3)]
        public string NomUtilisateur { get; set; }

        [Required(ErrorMessage = "Veuillez remplir votre mot de passe")]
        [DataType(DataType.Password)]
        [StringLength(80, ErrorMessage = "Must be between 3 and 8 characters", MinimumLength = 3)]
        public string Password { get; set; }

        [DisplayName("Repetez le Mot de passe")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordRepeated { get; set; }

        //[Required(ErrorMessage = "Veuiller entrer le tipe de compte")]
        //public TypeUtilisateur TypeUtilisateur { get; set; }

        [DisplayName("Restez connecté ?")]
        public bool Persistant { get; set; }
    }
}