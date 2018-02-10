using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkerRegistration.Models;
using Microsoft.AspNet.Identity;
using Common;

namespace WorkerRegistration.Controllers
{
    public class WorkersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Workers
        public async Task<ActionResult> Index()
        {
            return View(await db.Workers.ToListAsync());
        }

        public async Task<ActionResult> Orc()
        {
            string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            return RedirectToAction($"Details/{db.Workers.SingleOrDefault(w => w.QRCode == UserId).WorkerId}");
        }

        // GET: Workers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = await db.Workers.FindAsync(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // GET: Workers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "WorkerId,FirstNames,LastName,Phone,Gender,Issue,Expiry,Place,Language,Occupation,Address,City,Country")] Worker worker)
        {
            worker.QRCode = System.Web.HttpContext.Current.User.Identity.GetUserId();
            worker.Issue = General.DTNow();
            worker.Expiry = Frequencies.FutureDateTimeAndDifference(Frequencies.Freq7, worker.Issue).Item1;

            if (ModelState.IsValid)
            {
                db.Workers.Add(worker);
                await db.SaveChangesAsync();
                return RedirectToAction($"Details/{db.Workers.SingleOrDefault(w => w.QRCode == worker.QRCode).WorkerId}");
            }

            return View(worker);
        }

        // GET: Workers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = await db.Workers.FindAsync(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "WorkerId,QRCode,FirstNames,LastName,Phone,Gender,Issue,Expiry,Place,Language,Occupation,Address,City,Country")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worker).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction($"Details/{worker.WorkerId}");
            }
            return View(worker);
        }

        // GET: Workers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = await db.Workers.FindAsync(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Worker worker = await db.Workers.FindAsync(id);
            db.Workers.Remove(worker);
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
