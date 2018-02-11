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
    public class FisheriesApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/FisheriesApi
        public IQueryable<Fishery> GetFisheries()
        {
            return db.Fisheries;
        }

        // GET: api/FisheriesApi/5
        [ResponseType(typeof(Fishery))]
        public async Task<IHttpActionResult> GetFishery(int id)
        {
            Fishery fishery = await db.Fisheries.FindAsync(id);
            if (fishery == null)
            {
                return NotFound();
            }

            return Ok(fishery);
        }

        // PUT: api/FisheriesApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFishery(int id, Fishery fishery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fishery.FisheryId)
            {
                return BadRequest();
            }

            db.Entry(fishery).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FisheryExists(id))
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

        // POST: api/FisheriesApi
        [ResponseType(typeof(Fishery))]
        public async Task<IHttpActionResult> PostFishery(Fishery fishery)
        {
            fishery.Code = Guid.NewGuid();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fisheries.Add(fishery);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = fishery.FisheryId }, fishery);
        }

        // DELETE: api/FisheriesApi/5
        [ResponseType(typeof(Fishery))]
        public async Task<IHttpActionResult> DeleteFishery(int id)
        {
            Fishery fishery = await db.Fisheries.FindAsync(id);
            if (fishery == null)
            {
                return NotFound();
            }

            db.Fisheries.Remove(fishery);
            await db.SaveChangesAsync();

            return Ok(fishery);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FisheryExists(int id)
        {
            return db.Fisheries.Count(e => e.FisheryId == id) > 0;
        }
    }
}