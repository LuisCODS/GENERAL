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

        // ============================= Login ==================================
        public ActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel user, string ReturnUrl, bool Persistant)
        {
            if (IsValid(user))
            {
                FormsAuthentication.SetAuthCookie(user.NomUtilisateur, Persistant);
                //return Redirect(ReturnUrl);
                if(!string.IsNullOrWhiteSpace(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    return Redirect(ReturnUrl);
                return Redirect("/");
            }
            else
            {
                return View(user);
            }

        }

        private bool IsValid(LoginModel user)
        {
            Utilisateur userFromBd = db.Utilisateurs.FirstOrDefault(u => u.NomUtilisateur == user.NomUtilisateur && u.Password == user.Password);
            if (userFromBd != null)            
                return (true);            
            return (false);
        }

        // ============================= Logout ==================================
        public ActionResult Logout() 
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

    }
}
