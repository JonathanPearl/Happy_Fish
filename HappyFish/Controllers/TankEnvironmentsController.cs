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
    public class TankEnvironmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TankEnvironments
        public async Task<ActionResult> Index()
        {
            return View(await db.TankEnvironments.ToListAsync());
        }

        // GET: TankEnvironments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TankEnvironment tankEnvironment = await db.TankEnvironments.FindAsync(id);
            if (tankEnvironment == null)
            {
                return HttpNotFound();
            }
            return View(tankEnvironment);
        }

        // GET: TankEnvironments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TankEnvironments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TankEnvironmentId,Code,EventTime,PH,Ammonia,Oxygen,Conductivity,Temperature")] TankEnvironment tankEnvironment)
        {
            if (ModelState.IsValid)
            {
                db.TankEnvironments.Add(tankEnvironment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tankEnvironment);
        }

        // GET: TankEnvironments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TankEnvironment tankEnvironment = await db.TankEnvironments.FindAsync(id);
            if (tankEnvironment == null)
            {
                return HttpNotFound();
            }
            return View(tankEnvironment);
        }

        // POST: TankEnvironments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TankEnvironmentId,Code,EventTime,PH,Ammonia,Oxygen,Conductivity,Temperature")] TankEnvironment tankEnvironment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tankEnvironment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tankEnvironment);
        }

        // GET: TankEnvironments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TankEnvironment tankEnvironment = await db.TankEnvironments.FindAsync(id);
            if (tankEnvironment == null)
            {
                return HttpNotFound();
            }
            return View(tankEnvironment);
        }

        // POST: TankEnvironments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TankEnvironment tankEnvironment = await db.TankEnvironments.FindAsync(id);
            db.TankEnvironments.Remove(tankEnvironment);
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
