using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CajeroAutomatico.Entities;
using CajeroAutomatico.Persistance;

namespace CajeroAutomatico.MVC.Controllers
{
    public class BaseDatosController : Controller
    {
        private CajeroDBContext db = new CajeroDBContext();

        // GET: BaseDatos
        public ActionResult Index()
        {
            return View(db.BaseDatos.ToList());
        }

        // GET: BaseDatos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseDatos baseDatos = db.BaseDatos.Find(id);
            if (baseDatos == null)
            {
                return HttpNotFound();
            }
            return View(baseDatos);
        }

        // GET: BaseDatos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BaseDatos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBaseDatos,Administrador,LenguajeNativo,CapacidadHDD")] BaseDatos baseDatos)
        {
            if (ModelState.IsValid)
            {
                db.BaseDatos.Add(baseDatos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baseDatos);
        }

        // GET: BaseDatos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseDatos baseDatos = db.BaseDatos.Find(id);
            if (baseDatos == null)
            {
                return HttpNotFound();
            }
            return View(baseDatos);
        }

        // POST: BaseDatos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBaseDatos,Administrador,LenguajeNativo,CapacidadHDD")] BaseDatos baseDatos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baseDatos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baseDatos);
        }

        // GET: BaseDatos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseDatos baseDatos = db.BaseDatos.Find(id);
            if (baseDatos == null)
            {
                return HttpNotFound();
            }
            return View(baseDatos);
        }

        // POST: BaseDatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaseDatos baseDatos = db.BaseDatos.Find(id);
            db.BaseDatos.Remove(baseDatos);
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
