using CadastroDeProdutos.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastroDeProdutos.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            using ( ProdutoContexto db = new ProdutoContexto())
            {
                 return View(db.Utilisateurs.ToList());

            }
        }


        public ActionResult Connection()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}