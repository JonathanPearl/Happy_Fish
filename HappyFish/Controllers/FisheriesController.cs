using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HappyFish;
using HappyFish.Models;

namespace HappyFish.Controllers
{
    public class FisheriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Fisheries
        public async Task<ActionResult> Index()
        {
            return View(await db.Fisheries.ToListAsync());
        }

        // GET: Fisheries/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fishery fishery = await db.Fisheries.FindAsync(id);
            if (fishery == null)
            {
                return HttpNotFound();
            }
            return View(fishery);
        }

        // GET: Fisheries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fisheries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FisheryId,Code")] Fishery fishery)
        {
            fishery.Code = Guid.NewGuid();

            if (ModelState.IsValid)
            {
                db.Fisheries.Add(fishery);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fishery);
        }

        // GET: Fisheries/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fishery fishery = await db.Fisheries.FindAsync(id);
            if (fishery == null)
            {
                return HttpNotFound();
            }
            return View(fishery);
        }

        // POST: Fisheries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FisheryId,Code")] Fishery fishery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fishery).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fishery);
        }

        // GET: Fisheries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fishery fishery = await db.Fisheries.FindAsync(id);
            if (fishery == null)
            {
                return HttpNotFound();
            }
            return View(fishery);
        }

        // POST: Fisheries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Fishery fishery = await db.Fisheries.FindAsync(id);
            db.Fisheries.Remove(fishery);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
