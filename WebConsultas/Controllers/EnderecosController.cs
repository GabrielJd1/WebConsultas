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
    public class EnderecosController : Controller
    {
        private WebConsultasContext db = new WebConsultasContext();

        // GET: Enderecos
        public ActionResult Index()
        {
            var enderecos = db.enderecos.Include(e => e.Estado);
            return View(enderecos.ToList());
        }

        // GET: Enderecos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.enderecos.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // GET: Enderecos/Create
        public ActionResult Create()
        {
            ViewBag.Estado_idEstado = new SelectList(db.estados, "idEstado", "descricao");
            return View();
        }

        // POST: Enderecos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEndereco,rua,numero,complemento,obs,Estado_idEstado")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.enderecos.Add(endereco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estado_idEstado = new SelectList(db.estados, "idEstado", "descricao", endereco.Estado_idEstado);
            return View(endereco);
        }

        // GET: Enderecos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.enderecos.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estado_idEstado = new SelectList(db.estados, "idEstado", "descricao", endereco.Estado_idEstado);
            return View(endereco);
        }

        // POST: Enderecos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEndereco,rua,numero,complemento,obs,Estado_idEstado")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estado_idEstado = new SelectList(db.estados, "idEstado", "descricao", endereco.Estado_idEstado);
            return View(endereco);
        }

        // GET: Enderecos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.enderecos.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Enderecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Endereco endereco = db.enderecos.Find(id);
            db.enderecos.Remove(endereco);
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
