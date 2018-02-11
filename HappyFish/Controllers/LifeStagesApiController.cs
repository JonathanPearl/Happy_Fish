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
    public class LifeStagesApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/LifeStagesApi
        public IQueryable<LifeStage> GetLifeStages()
        {
            return db.LifeStages;
        }

        // GET: api/LifeStagesApi/5
        [ResponseType(typeof(LifeStage))]
        public async Task<IHttpActionResult> GetLifeStage(int id)
        {
            LifeStage lifeStage = await db.LifeStages.FindAsync(id);
            if (lifeStage == null)
            {
                return NotFound();
            }

            return Ok(lifeStage);
        }

        // PUT: api/LifeStagesApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLifeStage(int id, LifeStage lifeStage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lifeStage.LifeStageId)
            {
                return BadRequest();
            }

            db.Entry(lifeStage).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LifeStageExists(id))
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

        // POST: api/LifeStagesApi
        [ResponseType(typeof(LifeStage))]
        public async Task<IHttpActionResult> PostLifeStage(LifeStage lifeStage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LifeStages.Add(lifeStage);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = lifeStage.LifeStageId }, lifeStage);
        }

        // DELETE: api/LifeStagesApi/5
        [ResponseType(typeof(LifeStage))]
        public async Task<IHttpActionResult> DeleteLifeStage(int id)
        {
            LifeStage lifeStage = await db.LifeStages.FindAsync(id);
            if (lifeStage == null)
            {
                return NotFound();
            }

            db.LifeStages.Remove(lifeStage);
            await db.SaveChangesAsync();

            return Ok(lifeStage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LifeStageExists(int id)
        {
            return db.LifeStages.Count(e => e.LifeStageId == id) > 0;
        }
    }
}