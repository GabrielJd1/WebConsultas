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
    public class FuncionariosController : Controller
    {
        private WebConsultasContext db = new WebConsultasContext();

        // GET: Funcionarios
        public ActionResult Index()
        {
            var funcionarios = db.funcionarios.Include(f => f.Cargo).Include(f => f.Endereco);
            return View(funcionarios.ToList());
        }

        // GET: Funcionarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public ActionResult Create()
        {
            ViewBag.Cargo_idCargo = new SelectList(db.cargos, "idCargo", "descricao");
            ViewBag.Endereco_idEndereco = new SelectList(db.enderecos, "idEndereco", "rua");
            return View();
        }

        // POST: Funcionarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFuncionario,nome,salario,dataDemi,Cargo_idCargo,Endereco_idEndereco")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.funcionarios.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cargo_idCargo = new SelectList(db.cargos, "idCargo", "descricao", funcionario.Cargo_idCargo);
            ViewBag.Endereco_idEndereco = new SelectList(db.enderecos, "idEndereco", "rua", funcionario.Endereco_idEndereco);
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cargo_idCargo = new SelectList(db.cargos, "idCargo", "descricao", funcionario.Cargo_idCargo);
            ViewBag.Endereco_idEndereco = new SelectList(db.enderecos, "idEndereco", "rua", funcionario.Endereco_idEndereco);
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFuncionario,nome,salario,dataDemi,Cargo_idCargo,Endereco_idEndereco")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cargo_idCargo = new SelectList(db.cargos, "idCargo", "descricao", funcionario.Cargo_idCargo);
            ViewBag.Endereco_idEndereco = new SelectList(db.enderecos, "idEndereco", "rua", funcionario.Endereco_idEndereco);
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funcionario funcionario = db.funcionarios.Find(id);
            db.funcionarios.Remove(funcionario);
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
