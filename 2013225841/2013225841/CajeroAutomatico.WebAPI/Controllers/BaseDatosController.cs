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
    public class BaseDatosController : ApiController
    {
        private CajeroDBContext db = new CajeroDBContext();

        // GET: api/BaseDatos
        public IQueryable<BaseDatos> GetBaseDatos()
        {
            return db.BaseDatos;
        }

        // GET: api/BaseDatos/5
        [ResponseType(typeof(BaseDatos))]
        public IHttpActionResult GetBaseDatos(int id)
        {
            BaseDatos baseDatos = db.BaseDatos.Find(id);
            if (baseDatos == null)
            {
                return NotFound();
            }

            return Ok(baseDatos);
        }

        // PUT: api/BaseDatos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBaseDatos(int id, BaseDatos baseDatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != baseDatos.idBaseDatos)
            {
                return BadRequest();
            }

            db.Entry(baseDatos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaseDatosExists(id))
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

        // POST: api/BaseDatos
        [ResponseType(typeof(BaseDatos))]
        public IHttpActionResult PostBaseDatos(BaseDatos baseDatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BaseDatos.Add(baseDatos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = baseDatos.idBaseDatos }, baseDatos);
        }

        // DELETE: api/BaseDatos/5
        [ResponseType(typeof(BaseDatos))]
        public IHttpActionResult DeleteBaseDatos(int id)
        {
            BaseDatos baseDatos = db.BaseDatos.Find(id);
            if (baseDatos == null)
            {
                return NotFound();
            }

            db.BaseDatos.Remove(baseDatos);
            db.SaveChanges();

            return Ok(baseDatos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BaseDatosExists(int id)
        {
            return db.BaseDatos.Count(e => e.idBaseDatos == id) > 0;
        }
    }
}