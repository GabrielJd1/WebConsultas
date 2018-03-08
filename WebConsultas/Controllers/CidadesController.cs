﻿using System;
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
    public class CidadesController : Controller
    {
        private WebConsultasContext db = new WebConsultasContext();

        // GET: Cidades
        public ActionResult Index()
        {
            var cidades = db.cidades.Include(c => c.Estado);
            return View(cidades.ToList());
        }

        // GET: Cidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = db.cidades.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // GET: Cidades/Create
        public ActionResult Create()
        {
            ViewBag.Estado_idEstado = new SelectList(db.estados, "idEstado", "descricao");
            return View();
        }

        // POST: Cidades/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCidade,descricao,Estado_idEstado")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.cidades.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estado_idEstado = new SelectList(db.estados, "idEstado", "descricao", cidade.Estado_idEstado);
            return View(cidade);
        }

        // GET: Cidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = db.cidades.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estado_idEstado = new SelectList(db.estados, "idEstado", "descricao", cidade.Estado_idEstado);
            return View(cidade);
        }

        // POST: Cidades/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCidade,descricao,Estado_idEstado")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estado_idEstado = new SelectList(db.estados, "idEstado", "descricao", cidade.Estado_idEstado);
            return View(cidade);
        }

        // GET: Cidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = db.cidades.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cidade cidade = db.cidades.Find(id);
            db.cidades.Remove(cidade);
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
