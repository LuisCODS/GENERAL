using CadastroDeProdutos.DAL;
using CadastroDeProdutos.Models;
using CadastroDeProdutos.ModelsViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DemoAuthentication.Controllers
{
    public class AuthController : Controller
    {

        ProdutoContexto db = new ProdutoContexto();

        // ============================= CREATE ==================================
        public ActionResult Create() 
        {
            return View(new Utilisateur());
        }
        [HttpPost]
        public ActionResult Create(Utilisateur user)
        {
            if (ModelState.IsValid)
            {
                //string motDePasseEncode = EncodeMD5(user.PasswordRepeated);
                db.Utilisateurs.Add(user);
                db.SaveChanges();
                FormsAuthentication.SetAuthCookie(user.UtilisateurID.ToString(), false);
                return RedirectToAction("Index", "Home");
            }
            //return utilisateur.Id;
            return View(user);
        }

        // ============================= Login ==================================

        [HttpGet]
        public ActionResult Login() /* Pour afficher le formulaire de login */
        {

            //fournit l’utilisateur et également si l’utilisateur est authentifié
            UtilisateurViewModel viewModel = new UtilisateurViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated};

            //permet de vérifier si l’utilisateur est authentifié(cookie attaché).
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Utilisateur = ObtenirUtilisateur(HttpContext.User.Identity.Name);
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Login(UtilisateurViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Utilisateur utilisateur = Authentifier(viewModel.Utilisateur.NomUtilisateur, viewModel.Utilisateur.PasswordRepeated);
                if (utilisateur != null)
                {
                    // génère le cookie d’authentification à partir de l’identifiant de l’utilisateur.
                    FormsAuthentication.SetAuthCookie(utilisateur.UtilisateurID.ToString(), false);

                    //si le paramètre dans l’URL existe et si ce dernier contient bien un lien vers le site
                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);//rediriger l’utilisateur au bon endroit.
                    return Redirect("/");
                }
                ModelState.AddModelError("Utilisateur.NomUtilisateur", "Nom utilisateur et/ou mot de passe incorrect(s)");
            }
            return View(viewModel);
        }

        private Utilisateur Authentifier(string nom, string motDePasse)
        {
            //string motDePasseEncode = EncodeMD5(motDePasse);
            return db.Utilisateurs.FirstOrDefault(u => u.NomUtilisateur == nom && u.PasswordRepeated == motDePasse);
        }
        private Utilisateur ObtenirUtilisateur(int id)
        {
            return db.Utilisateurs.FirstOrDefault(u => u.UtilisateurID == id);
        }
        public Utilisateur ObtenirUtilisateur(string idString)
        {
            int id;
            if (int.TryParse(idString, out id))
                return ObtenirUtilisateur(id);
            return null;
        }
        // ============================= Logout ==================================

        public ActionResult Logout() /* Pour déconnecter l'utilisateur */
        {

            return View();

        }

    }
}
