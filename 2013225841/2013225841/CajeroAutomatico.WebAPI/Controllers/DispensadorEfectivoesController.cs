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
    public class DispensadorEfectivoesController : ApiController
    {
        private CajeroDBContext db = new CajeroDBContext();

        // GET: api/DispensadorEfectivoes
        public IQueryable<DispensadorEfectivo> GetDispensadorEfectivo()
        {
            return db.DispensadorEfectivo;
        }

        // GET: api/DispensadorEfectivoes/5
        [ResponseType(typeof(DispensadorEfectivo))]
        public IHttpActionResult GetDispensadorEfectivo(int id)
        {
            DispensadorEfectivo dispensadorEfectivo = db.DispensadorEfectivo.Find(id);
            if (dispensadorEfectivo == null)
            {
                return NotFound();
            }

            return Ok(dispensadorEfectivo);
        }

        // PUT: api/DispensadorEfectivoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDispensadorEfectivo(int id, DispensadorEfectivo dispensadorEfectivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dispensadorEfectivo.idDispensadorefectivo)
            {
                return BadRequest();
            }

            db.Entry(dispensadorEfectivo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DispensadorEfectivoExists(id))
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

        // POST: api/DispensadorEfectivoes
        [ResponseType(typeof(DispensadorEfectivo))]
        public IHttpActionResult PostDispensadorEfectivo(DispensadorEfectivo dispensadorEfectivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DispensadorEfectivo.Add(dispensadorEfectivo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dispensadorEfectivo.idDispensadorefectivo }, dispensadorEfectivo);
        }

        // DELETE: api/DispensadorEfectivoes/5
        [ResponseType(typeof(DispensadorEfectivo))]
        public IHttpActionResult DeleteDispensadorEfectivo(int id)
        {
            DispensadorEfectivo dispensadorEfectivo = db.DispensadorEfectivo.Find(id);
            if (dispensadorEfectivo == null)
            {
                return NotFound();
            }

            db.DispensadorEfectivo.Remove(dispensadorEfectivo);
            db.SaveChanges();

            return Ok(dispensadorEfectivo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DispensadorEfectivoExists(int id)
        {
            return db.DispensadorEfectivo.Count(e => e.idDispensadorefectivo == id) > 0;
        }
    }
}