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
    public class NeedsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Needs
        public async Task<ActionResult> Index()
        {
            return View(await db.Needs.ToListAsync());
        }

        // GET: Needs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Need need = await db.Needs.FindAsync(id);
            if (need == null)
            {
                return HttpNotFound();
            }
            return View(need);
        }

        // GET: Needs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Needs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NeedId,ProductId")] Need need)
        {
            if (ModelState.IsValid)
            {
                db.Needs.Add(need);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(need);
        }

        // GET: Needs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Need need = await db.Needs.FindAsync(id);
            if (need == null)
            {
                return HttpNotFound();
            }
            return View(need);
        }

        // POST: Needs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NeedId,ProductId")] Need need)
        {
            if (ModelState.IsValid)
            {
                db.Entry(need).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(need);
        }

        // GET: Needs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Need need = await db.Needs.FindAsync(id);
            if (need == null)
            {
                return HttpNotFound();
            }
            return View(need);
        }

        // POST: Needs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Need need = await db.Needs.FindAsync(id);
            db.Needs.Remove(need);
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
