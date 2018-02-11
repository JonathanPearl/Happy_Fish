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
    public class TanksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tanks
        public async Task<ActionResult> Index()
        {
            return View(await db.Tanks.ToListAsync());
        }

        // GET: Tanks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tank tank = await db.Tanks.FindAsync(id);
            if (tank == null)
            {
                return HttpNotFound();
            }
            return View(tank);
        }

        // GET: Tanks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tanks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TankId,FisheryId,Name,Volume,Code")] Tank tank)
        {
            if (ModelState.IsValid)
            {
                db.Tanks.Add(tank);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tank);
        }

        // GET: Tanks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tank tank = await db.Tanks.FindAsync(id);
            if (tank == null)
            {
                return HttpNotFound();
            }
            return View(tank);
        }

        // POST: Tanks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TankId,FisheryId,Name,Volume,Code")] Tank tank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tank).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tank);
        }

        // GET: Tanks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tank tank = await db.Tanks.FindAsync(id);
            if (tank == null)
            {
                return HttpNotFound();
            }
            return View(tank);
        }

        // POST: Tanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tank tank = await db.Tanks.FindAsync(id);
            db.Tanks.Remove(tank);
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
