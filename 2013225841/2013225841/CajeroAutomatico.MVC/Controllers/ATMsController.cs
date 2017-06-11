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
    public class ATMsController : Controller
    {
        private CajeroDBContext db = new CajeroDBContext();

        // GET: ATMs
        public ActionResult Index()
        {
            var aTM = db.ATM.Include(a => a.BaseDatos);
            return View(aTM.ToList());
        }

        // GET: ATMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATM aTM = db.ATM.Find(id);
            if (aTM == null)
            {
                return HttpNotFound();
            }
            return View(aTM);
        }

        // GET: ATMs/Create
        public ActionResult Create()
        {
            ViewBag.idBaseDatos = new SelectList(db.BaseDatos, "idBaseDatos", "Administrador");
            return View();
        }

        // POST: ATMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idATM,Direccion,CodigoATM,idBaseDatos")] ATM aTM)
        {
            if (ModelState.IsValid)
            {
                db.ATM.Add(aTM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBaseDatos = new SelectList(db.BaseDatos, "idBaseDatos", "Administrador", aTM.idBaseDatos);
            return View(aTM);
        }

        // GET: ATMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATM aTM = db.ATM.Find(id);
            if (aTM == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBaseDatos = new SelectList(db.BaseDatos, "idBaseDatos", "Administrador", aTM.idBaseDatos);
            return View(aTM);
        }

        // POST: ATMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idATM,Direccion,CodigoATM,idBaseDatos")] ATM aTM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aTM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBaseDatos = new SelectList(db.BaseDatos, "idBaseDatos", "Administrador", aTM.idBaseDatos);
            return View(aTM);
        }

        // GET: ATMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATM aTM = db.ATM.Find(id);
            if (aTM == null)
            {
                return HttpNotFound();
            }
            return View(aTM);
        }

        // POST: ATMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ATM aTM = db.ATM.Find(id);
            db.ATM.Remove(aTM);
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
