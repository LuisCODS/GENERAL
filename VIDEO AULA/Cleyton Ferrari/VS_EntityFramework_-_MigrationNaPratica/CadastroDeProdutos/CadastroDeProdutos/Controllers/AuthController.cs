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
        public ActionResult Login(LoginModel userModel, string ReturnUrl)
        {
            if (IsValid(userModel))
            {
                FormsAuthentication.SetAuthCookie(userModel.NomUtilisateur, userModel.Persistant);
                if(!string.IsNullOrWhiteSpace(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    return Redirect(ReturnUrl);
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError("","Le nom d'utilisateur ou le mot de passe est incorrect. ");
                return View(userModel);
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
