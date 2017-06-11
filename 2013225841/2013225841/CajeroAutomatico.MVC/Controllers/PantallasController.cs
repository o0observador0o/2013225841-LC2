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
    public class PantallasController : Controller
    {
        private CajeroDBContext db = new CajeroDBContext();

        // GET: Pantallas
        public ActionResult Index()
        {
            var pantalla = db.Pantalla.Include(p => p.ATM);
            return View(pantalla.ToList());
        }

        // GET: Pantallas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pantalla pantalla = db.Pantalla.Find(id);
            if (pantalla == null)
            {
                return HttpNotFound();
            }
            return View(pantalla);
        }

        // GET: Pantallas/Create
        public ActionResult Create()
        {
            ViewBag.idATM = new SelectList(db.ATM, "idATM", "Direccion");
            return View();
        }

        // POST: Pantallas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPantalla,MarcaPantalla,idATM")] Pantalla pantalla)
        {
            if (ModelState.IsValid)
            {
                db.Pantalla.Add(pantalla);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idATM = new SelectList(db.ATM, "idATM", "Direccion", pantalla.idATM);
            return View(pantalla);
        }

        // GET: Pantallas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pantalla pantalla = db.Pantalla.Find(id);
            if (pantalla == null)
            {
                return HttpNotFound();
            }
            ViewBag.idATM = new SelectList(db.ATM, "idATM", "Direccion", pantalla.idATM);
            return View(pantalla);
        }

        // POST: Pantallas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPantalla,MarcaPantalla,idATM")] Pantalla pantalla)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pantalla).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idATM = new SelectList(db.ATM, "idATM", "Direccion", pantalla.idATM);
            return View(pantalla);
        }

        // GET: Pantallas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pantalla pantalla = db.Pantalla.Find(id);
            if (pantalla == null)
            {
                return HttpNotFound();
            }
            return View(pantalla);
        }

        // POST: Pantallas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pantalla pantalla = db.Pantalla.Find(id);
            db.Pantalla.Remove(pantalla);
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
