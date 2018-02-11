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
    public class TanksApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TanksApi
        public IQueryable<Tank> GetTanks()
        {
            return db.Tanks;
        }

        // GET: api/TanksApi/5
        [ResponseType(typeof(Tank))]
        public async Task<IHttpActionResult> GetTank(int id)
        {
            Tank tank = await db.Tanks.FindAsync(id);
            if (tank == null)
            {
                return NotFound();
            }

            return Ok(tank);
        }

        // PUT: api/TanksApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTank(int id, Tank tank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tank.TankId)
            {
                return BadRequest();
            }

            db.Entry(tank).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TankExists(id))
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

        // POST: api/TanksApi
        [ResponseType(typeof(Tank))]
        public async Task<IHttpActionResult> PostTank(Tank tank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tanks.Add(tank);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tank.TankId }, tank);
        }

        // DELETE: api/TanksApi/5
        [ResponseType(typeof(Tank))]
        public async Task<IHttpActionResult> DeleteTank(int id)
        {
            Tank tank = await db.Tanks.FindAsync(id);
            if (tank == null)
            {
                return NotFound();
            }

            db.Tanks.Remove(tank);
            await db.SaveChangesAsync();

            return Ok(tank);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TankExists(int id)
        {
            return db.Tanks.Count(e => e.TankId == id) > 0;
        }
    }
}