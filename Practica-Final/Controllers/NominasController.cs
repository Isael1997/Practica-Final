﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practica_Final.Models;

namespace Practica_Final.Controllers
{
    public class NominasController : Controller
    {
        private ProyectoFinalEntities db = new ProyectoFinalEntities();

        // GET: Nominas
        public ActionResult Index()
        {
            return View(db.Nominas.ToList());
        }

        public ActionResult Listado()
        {
            return View(db.Nominas.ToList());
        }

        // GET: Nominas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nominas nominas = db.Nominas.Find(id);
            if (nominas == null)
            {
                return HttpNotFound();
            }
            return View(nominas);
        }

        // GET: Nominas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nominas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Año,Mes,Total")] Nominas nominas)
        {
            if (ModelState.IsValid)
            {
                db.Nominas.Add(nominas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nominas);
        }

        // GET: Nominas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nominas nominas = db.Nominas.Find(id);
            if (nominas == null)
            {
                return HttpNotFound();
            }
            return View(nominas);
        }

        // POST: Nominas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Año,Mes,Total")] Nominas nominas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nominas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nominas);
        }

        // GET: Nominas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nominas nominas = db.Nominas.Find(id);
            if (nominas == null)
            {
                return HttpNotFound();
            }
            return View(nominas);
        }

        // POST: Nominas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nominas nominas = db.Nominas.Find(id);
            db.Nominas.Remove(nominas);
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
