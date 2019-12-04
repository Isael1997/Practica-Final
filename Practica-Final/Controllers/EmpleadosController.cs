using System;
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
    public class EmpleadosController : Controller
    {
        private ProyectoFinalEntities db = new ProyectoFinalEntities();

        // GET: Empleados
        public ActionResult Index()
        {
            return View(db.Empleados.ToList());
        }


        public ActionResult EActivos()
        {
            var lista = from datos in db.Empleados select datos;


            lista = lista.Where(a => a.Estatus.Equals("Activo"));

            return View(lista);
        }

        public ActionResult EInactivos()
        {
            var lista = from datos in db.Empleados select datos;


            lista = lista.Where(a => a.Estatus.Equals("Inactivo"));

            return View(lista);
        }


        public ActionResult EbyMoth(string Mes)
        {

            var lista = from datos in db.Empleados select datos;



            if (Mes == null)
            {
                return View(db.Empleados.ToList());
            }
            else
            {
                lista = lista.Where(a => a.FechaI.Equals(Mes));

                return View(lista);
            }

        }



        public ActionResult TSalario()
        {
            var lista = from datos in db.Empleados select datos;

            lista = lista.Where(a => a.Estatus.Equals("Activo"));


            return View(lista);
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,CodigoEmpleado,Nombres,Apellidos,Telefono,Departarmento,Cargo,FechaI,Salario,Estatus")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CodigoEmpleado,Nombres,Apellidos,Telefono,Departarmento,Cargo,FechaI,Salario,Estatus")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleados empleados = db.Empleados.Find(id);
            db.Empleados.Remove(empleados);
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
