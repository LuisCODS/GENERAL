using CadastroDeProdutos.DAL;
using CadastroDeProdutos.Models;
using CadastroDeProdutos.ModelsViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
                string password = user.PasswordRepeated;
                byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                string encoded = BitConverter.ToString(hash);
                user.PasswordRepeated = encoded;

                db.Utilisateurs.Add(user);
                db.SaveChanges();
                FormsAuthentication.SetAuthCookie(user.UtilisateurID.ToString(), false);
                return RedirectToAction("Index", "Home");
            }
            //return utilisateur.Id;
            return View(user);
        }

        //public string HashMotDePasse()
        //{
            
        //    get { return _hashMotDePasse; }
        //    set{
        //        _hashMotDePasse = PasswordHash.PasswordHash.CreateHash(value);
        //    }
        //}

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
                if (!string.IsNullOrWhiteSpace(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    return Redirect(ReturnUrl);
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError("", "Le nom d'utilisateur ou le mot de passe est incorrect. ");
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
