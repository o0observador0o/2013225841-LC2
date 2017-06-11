using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CajeroAutomatico.Entities;
using CajeroAutomatico.Persistance;

namespace CajeroAutomatico.WebAPI.Controllers
{
    public class ATMsController : ApiController
    {
        private CajeroDBContext db = new CajeroDBContext();

        // GET: api/ATMs
        public IQueryable<ATM> GetATM()
        {
            return db.ATM;
        }

        // GET: api/ATMs/5
        [ResponseType(typeof(ATM))]
        public IHttpActionResult GetATM(int id)
        {
            ATM aTM = db.ATM.Find(id);
            if (aTM == null)
            {
                return NotFound();
            }

            return Ok(aTM);
        }

        // PUT: api/ATMs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutATM(int id, ATM aTM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aTM.idATM)
            {
                return BadRequest();
            }

            db.Entry(aTM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ATMExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ATMs
        [ResponseType(typeof(ATM))]
        public IHttpActionResult PostATM(ATM aTM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ATM.Add(aTM);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aTM.idATM }, aTM);
        }

        // DELETE: api/ATMs/5
        [ResponseType(typeof(ATM))]
        public IHttpActionResult DeleteATM(int id)
        {
            ATM aTM = db.ATM.Find(id);
            if (aTM == null)
            {
                return NotFound();
            }

            db.ATM.Remove(aTM);
            db.SaveChanges();

            return Ok(aTM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ATMExists(int id)
        {
            return db.ATM.Count(e => e.idATM == id) > 0;
        }
    }
}