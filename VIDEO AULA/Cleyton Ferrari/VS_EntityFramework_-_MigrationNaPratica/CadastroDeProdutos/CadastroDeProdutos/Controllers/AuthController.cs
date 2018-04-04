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
                db.Utilisateurs.Add(user);
                db.SaveChanges();
                FormsAuthentication.SetAuthCookie(user.UtilisateurID.ToString(), false);
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        // ============================= Login ==================================

        [HttpGet]
        public ActionResult Login() /* Pour afficher le formulaire de login */
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            return View();
        }
        // ============================= Logout ==================================

        public ActionResult Logout() /* Pour déconnecter l'utilisateur */
        {

            return View();

        }

    }
}
