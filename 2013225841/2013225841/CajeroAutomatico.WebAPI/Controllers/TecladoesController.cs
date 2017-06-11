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
    public class TecladoesController : ApiController
    {
        private CajeroDBContext db = new CajeroDBContext();

        // GET: api/Tecladoes
        public IQueryable<Teclado> GetTeclado()
        {
            return db.Teclado;
        }

        // GET: api/Tecladoes/5
        [ResponseType(typeof(Teclado))]
        public IHttpActionResult GetTeclado(int id)
        {
            Teclado teclado = db.Teclado.Find(id);
            if (teclado == null)
            {
                return NotFound();
            }

            return Ok(teclado);
        }

        // PUT: api/Tecladoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeclado(int id, Teclado teclado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teclado.idTeclado)
            {
                return BadRequest();
            }

            db.Entry(teclado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TecladoExists(id))
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

        // POST: api/Tecladoes
        [ResponseType(typeof(Teclado))]
        public IHttpActionResult PostTeclado(Teclado teclado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Teclado.Add(teclado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = teclado.idTeclado }, teclado);
        }

        // DELETE: api/Tecladoes/5
        [ResponseType(typeof(Teclado))]
        public IHttpActionResult DeleteTeclado(int id)
        {
            Teclado teclado = db.Teclado.Find(id);
            if (teclado == null)
            {
                return NotFound();
            }

            db.Teclado.Remove(teclado);
            db.SaveChanges();

            return Ok(teclado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TecladoExists(int id)
        {
            return db.Teclado.Count(e => e.idTeclado == id) > 0;
        }
    }
}