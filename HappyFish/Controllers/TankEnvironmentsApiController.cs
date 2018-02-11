using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HappyFish;
using HappyFish.Models;

namespace HappyFish.Controllers
{
    public class TankEnvironmentsApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TankEnvironmentsApi
        public IQueryable<TankEnvironment> GetTankEnvironments()
        {
            return db.TankEnvironments;
        }

        // GET: api/TankEnvironmentsApi/5
        [ResponseType(typeof(TankEnvironment))]
        public async Task<IHttpActionResult> GetTankEnvironment(int id)
        {
            TankEnvironment tankEnvironment = await db.TankEnvironments.FindAsync(id);
            if (tankEnvironment == null)
            {
                return NotFound();
            }

            return Ok(tankEnvironment);
        }

        // PUT: api/TankEnvironmentsApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTankEnvironment(int id, TankEnvironment tankEnvironment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tankEnvironment.TankEnvironmentId)
            {
                return BadRequest();
            }

            db.Entry(tankEnvironment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TankEnvironmentExists(id))
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

        // POST: api/TankEnvironmentsApi
        [ResponseType(typeof(TankEnvironment))]
        public async Task<IHttpActionResult> PostTankEnvironment(TankEnvironment tankEnvironment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TankEnvironments.Add(tankEnvironment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tankEnvironment.TankEnvironmentId }, tankEnvironment);
        }

        // DELETE: api/TankEnvironmentsApi/5
        [ResponseType(typeof(TankEnvironment))]
        public async Task<IHttpActionResult> DeleteTankEnvironment(int id)
        {
            TankEnvironment tankEnvironment = await db.TankEnvironments.FindAsync(id);
            if (tankEnvironment == null)
            {
                return NotFound();
            }

            db.TankEnvironments.Remove(tankEnvironment);
            await db.SaveChangesAsync();

            return Ok(tankEnvironment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TankEnvironmentExists(int id)
        {
            return db.TankEnvironments.Count(e => e.TankEnvironmentId == id) > 0;
        }
    }
}