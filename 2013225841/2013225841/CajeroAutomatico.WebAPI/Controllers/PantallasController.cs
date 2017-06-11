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
    public class PantallasController : ApiController
    {
        private CajeroDBContext db = new CajeroDBContext();

        // GET: api/Pantallas
        public IQueryable<Pantalla> GetPantalla()
        {
            return db.Pantalla;
        }

        // GET: api/Pantallas/5
        [ResponseType(typeof(Pantalla))]
        public IHttpActionResult GetPantalla(int id)
        {
            Pantalla pantalla = db.Pantalla.Find(id);
            if (pantalla == null)
            {
                return NotFound();
            }

            return Ok(pantalla);
        }

        // PUT: api/Pantallas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPantalla(int id, Pantalla pantalla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pantalla.idPantalla)
            {
                return BadRequest();
            }

            db.Entry(pantalla).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PantallaExists(id))
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

        // POST: api/Pantallas
        [ResponseType(typeof(Pantalla))]
        public IHttpActionResult PostPantalla(Pantalla pantalla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pantalla.Add(pantalla);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pantalla.idPantalla }, pantalla);
        }

        // DELETE: api/Pantallas/5
        [ResponseType(typeof(Pantalla))]
        public IHttpActionResult DeletePantalla(int id)
        {
            Pantalla pantalla = db.Pantalla.Find(id);
            if (pantalla == null)
            {
                return NotFound();
            }

            db.Pantalla.Remove(pantalla);
            db.SaveChanges();

            return Ok(pantalla);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PantallaExists(int id)
        {
            return db.Pantalla.Count(e => e.idPantalla == id) > 0;
        }
    }
}