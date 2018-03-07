using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebConsultas.Models;

namespace WebConsultas.Controllers
{
    public class BairrosController : Controller
    {
        private WebConsultasContext db = new WebConsultasContext();

        // GET: Bairros
        public ActionResult Index()
        {
            var bairros = db.bairros.Include(b => b.Cidade);
            return View(bairros.ToList());
        }

        // GET: Bairros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bairro bairro = db.bairros.Find(id);
            if (bairro == null)
            {
                return HttpNotFound();
            }
            return View(bairro);
        }

        // GET: Bairros/Create
        public ActionResult Create()
        {
            ViewBag.Cidade_idCidade = new SelectList(db.cidades, "idCidade", "descricao");
            return View();
        }

        // POST: Bairros/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBairro,descricao,Cidade_idCidade")] Bairro bairro)
        {
            if (ModelState.IsValid)
            {
                db.bairros.Add(bairro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cidade_idCidade = new SelectList(db.cidades, "idCidade", "descricao", bairro.Cidade_idCidade);
            return View(bairro);
        }

        // GET: Bairros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bairro bairro = db.bairros.Find(id);
            if (bairro == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cidade_idCidade = new SelectList(db.cidades, "idCidade", "descricao", bairro.Cidade_idCidade);
            return View(bairro);
        }

        // POST: Bairros/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBairro,descricao,Cidade_idCidade")] Bairro bairro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bairro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cidade_idCidade = new SelectList(db.cidades, "idCidade", "descricao", bairro.Cidade_idCidade);
            return View(bairro);
        }

        // GET: Bairros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bairro bairro = db.bairros.Find(id);
            if (bairro == null)
            {
                return HttpNotFound();
            }
            return View(bairro);
        }

        // POST: Bairros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bairro bairro = db.bairros.Find(id);
            db.bairros.Remove(bairro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
