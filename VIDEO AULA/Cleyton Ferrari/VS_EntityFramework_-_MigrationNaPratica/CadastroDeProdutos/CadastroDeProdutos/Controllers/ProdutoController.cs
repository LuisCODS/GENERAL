using CadastroDeProdutos.DAL;
using CadastroDeProdutos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CadastroDeProdutos.Controllers
{
    public class ProdutoController : Controller
    {

        ProdutoContexto db = new ProdutoContexto();

        // ============================= LIST ==================================
        public ActionResult Index()
        {
            //List avec lase load
            return View(db.Produtos.Include(x => x.Categoria).ToList() );
        }

        // ============================= DETAILS ==================================
        public ActionResult Details(int id)
        {
            Produto produto = db.Produtos.Find(id);
            return View(produto);
        }

        // ============================= CREATE ==================================
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Categoria = new Categoria();
            return View(new Produto());
        }

        [HttpPost]
        public ActionResult Create(Produto p)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        // ============================= EDIT ==================================

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(produto).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
        }

        // ============================= DELITE ==================================
        [Authorize(Roles = "Administrateur")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto p = db.Produtos.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);//Demande la confirmation avant le delete
        }

        // POST: Produto/DeletePost/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                Produto produtoToDelite = db.Produtos.Where(x => x.ProdutoID == id).First();
                db.Set<Produto>().Remove(produtoToDelite);//delete la video de la table
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
