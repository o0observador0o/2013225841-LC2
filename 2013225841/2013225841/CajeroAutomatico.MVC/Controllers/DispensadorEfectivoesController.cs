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
    public class DispensadorEfectivoesController : Controller
    {
        private CajeroDBContext db = new CajeroDBContext();

        // GET: DispensadorEfectivoes
        public ActionResult Index()
        {
            var dispensadorEfectivo = db.DispensadorEfectivo.Include(d => d.ATM);
            return View(dispensadorEfectivo.ToList());
        }

        // GET: DispensadorEfectivoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DispensadorEfectivo dispensadorEfectivo = db.DispensadorEfectivo.Find(id);
            if (dispensadorEfectivo == null)
            {
                return HttpNotFound();
            }
            return View(dispensadorEfectivo);
        }

        // GET: DispensadorEfectivoes/Create
        public ActionResult Create()
        {
            ViewBag.idATM = new SelectList(db.ATM, "idATM", "Direccion");
            return View();
        }

        // POST: DispensadorEfectivoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDispensadorefectivo,contador,idATM")] DispensadorEfectivo dispensadorEfectivo)
        {
            if (ModelState.IsValid)
            {
                db.DispensadorEfectivo.Add(dispensadorEfectivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idATM = new SelectList(db.ATM, "idATM", "Direccion", dispensadorEfectivo.idATM);
            return View(dispensadorEfectivo);
        }

        // GET: DispensadorEfectivoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DispensadorEfectivo dispensadorEfectivo = db.DispensadorEfectivo.Find(id);
            if (dispensadorEfectivo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idATM = new SelectList(db.ATM, "idATM", "Direccion", dispensadorEfectivo.idATM);
            return View(dispensadorEfectivo);
        }

        // POST: DispensadorEfectivoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDispensadorefectivo,contador,idATM")] DispensadorEfectivo dispensadorEfectivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dispensadorEfectivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idATM = new SelectList(db.ATM, "idATM", "Direccion", dispensadorEfectivo.idATM);
            return View(dispensadorEfectivo);
        }

        // GET: DispensadorEfectivoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DispensadorEfectivo dispensadorEfectivo = db.DispensadorEfectivo.Find(id);
            if (dispensadorEfectivo == null)
            {
                return HttpNotFound();
            }
            return View(dispensadorEfectivo);
        }

        // POST: DispensadorEfectivoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DispensadorEfectivo dispensadorEfectivo = db.DispensadorEfectivo.Find(id);
            db.DispensadorEfectivo.Remove(dispensadorEfectivo);
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
