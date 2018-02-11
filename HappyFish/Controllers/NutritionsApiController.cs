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
    public class NutritionsApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/NutritionsApi
        public IQueryable<Nutrition> GetNutritions()
        {
            return db.Nutritions;
        }

        // GET: api/NutritionsApi/5
        [ResponseType(typeof(Nutrition))]
        public async Task<IHttpActionResult> GetNutrition(int id)
        {
            Nutrition nutrition = await db.Nutritions.FindAsync(id);
            if (nutrition == null)
            {
                return NotFound();
            }

            return Ok(nutrition);
        }

        // PUT: api/NutritionsApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNutrition(int id, Nutrition nutrition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nutrition.NutritionId)
            {
                return BadRequest();
            }

            db.Entry(nutrition).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NutritionExists(id))
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

        // POST: api/NutritionsApi
        [ResponseType(typeof(Nutrition))]
        public async Task<IHttpActionResult> PostNutrition(Nutrition nutrition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Nutritions.Add(nutrition);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = nutrition.NutritionId }, nutrition);
        }

        // DELETE: api/NutritionsApi/5
        [ResponseType(typeof(Nutrition))]
        public async Task<IHttpActionResult> DeleteNutrition(int id)
        {
            Nutrition nutrition = await db.Nutritions.FindAsync(id);
            if (nutrition == null)
            {
                return NotFound();
            }

            db.Nutritions.Remove(nutrition);
            await db.SaveChangesAsync();

            return Ok(nutrition);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NutritionExists(int id)
        {
            return db.Nutritions.Count(e => e.NutritionId == id) > 0;
        }
    }
}