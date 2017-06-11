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
    public class RetiroesController : Controller
    {
        private CajeroDBContext db = new CajeroDBContext();

        // GET: Retiroes
        public ActionResult Index()
        {
            var retiro = db.Retiro.Include(r => r.ATM).Include(r => r.Cuenta);
            return View(retiro.ToList());
        }

        // GET: Retiroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retiro retiro = db.Retiro.Find(id);
            if (retiro == null)
            {
                return HttpNotFound();
            }
            return View(retiro);
        }

        // GET: Retiroes/Create
        public ActionResult Create()
        {
            ViewBag.idATM = new SelectList(db.ATM, "idATM", "Direccion");
            ViewBag.idCuenta = new SelectList(db.Cuenta, "idCuenta", "idCuenta");
            return View();
        }

        // POST: Retiroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRetiro,Monto,DNIPersona,NombrePersona,idATM,idCuenta")] Retiro retiro)
        {
            if (ModelState.IsValid)
            {
                db.Retiro.Add(retiro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idATM = new SelectList(db.ATM, "idATM", "Direccion", retiro.idATM);
            ViewBag.idCuenta = new SelectList(db.Cuenta, "idCuenta", "idCuenta", retiro.idCuenta);
            return View(retiro);
        }

        // GET: Retiroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retiro retiro = db.Retiro.Find(id);
            if (retiro == null)
            {
                return HttpNotFound();
            }
            ViewBag.idATM = new SelectList(db.ATM, "idATM", "Direccion", retiro.idATM);
            ViewBag.idCuenta = new SelectList(db.Cuenta, "idCuenta", "idCuenta", retiro.idCuenta);
            return View(retiro);
        }

        // POST: Retiroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRetiro,Monto,DNIPersona,NombrePersona,idATM,idCuenta")] Retiro retiro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(retiro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idATM = new SelectList(db.ATM, "idATM", "Direccion", retiro.idATM);
            ViewBag.idCuenta = new SelectList(db.Cuenta, "idCuenta", "idCuenta", retiro.idCuenta);
            return View(retiro);
        }

        // GET: Retiroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retiro retiro = db.Retiro.Find(id);
            if (retiro == null)
            {
                return HttpNotFound();
            }
            return View(retiro);
        }

        // POST: Retiroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Retiro retiro = db.Retiro.Find(id);
            db.Retiro.Remove(retiro);
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
