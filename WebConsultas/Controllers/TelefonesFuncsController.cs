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
    public class TelefonesFuncsController : Controller
    {
        private WebConsultasContext db = new WebConsultasContext();

        // GET: TelefonesFuncs
        public ActionResult Index()
        {
            var telefones = db.telefones.Include(t => t.Funcionario);
            return View(telefones.ToList());
        }

        // GET: TelefonesFuncs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelefonesFunc telefonesFunc = db.telefones.Find(id);
            if (telefonesFunc == null)
            {
                return HttpNotFound();
            }
            return View(telefonesFunc);
        }

        // GET: TelefonesFuncs/Create
        public ActionResult Create()
        {
            ViewBag.Funcionario_idFuncionario = new SelectList(db.funcionarios, "idFuncionario", "nome");
            return View();
        }

        // POST: TelefonesFuncs/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTelefone,numero,Funcionario_idFuncionario")] TelefonesFunc telefonesFunc)
        {
            if (ModelState.IsValid)
            {
                db.telefones.Add(telefonesFunc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Funcionario_idFuncionario = new SelectList(db.funcionarios, "idFuncionario", "nome", telefonesFunc.Funcionario_idFuncionario);
            return View(telefonesFunc);
        }

        // GET: TelefonesFuncs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelefonesFunc telefonesFunc = db.telefones.Find(id);
            if (telefonesFunc == null)
            {
                return HttpNotFound();
            }
            ViewBag.Funcionario_idFuncionario = new SelectList(db.funcionarios, "idFuncionario", "nome", telefonesFunc.Funcionario_idFuncionario);
            return View(telefonesFunc);
        }

        // POST: TelefonesFuncs/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTelefone,numero,Funcionario_idFuncionario")] TelefonesFunc telefonesFunc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefonesFunc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Funcionario_idFuncionario = new SelectList(db.funcionarios, "idFuncionario", "nome", telefonesFunc.Funcionario_idFuncionario);
            return View(telefonesFunc);
        }

        // GET: TelefonesFuncs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelefonesFunc telefonesFunc = db.telefones.Find(id);
            if (telefonesFunc == null)
            {
                return HttpNotFound();
            }
            return View(telefonesFunc);
        }

        // POST: TelefonesFuncs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TelefonesFunc telefonesFunc = db.telefones.Find(id);
            db.telefones.Remove(telefonesFunc);
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
