using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ABCD_Admin.Models;

namespace ABCD_Admin.Controllers
{
    public class TicketsController : Controller
    {
        private Entities db = new Entities();

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.Movy).Include(t => t.RoomSeat).Include(t => t.Screening).Include(t => t.OrderDetail);
            return View(tickets.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        //// GET: Tickets/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Ticket ticket = db.Tickets.Find(id);
        //    if (ticket == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.movieId = new SelectList(db.Movies, "movieId", "movieTitle", ticket.movieId);
        //    ViewBag.roomId = new SelectList(db.RoomSeats, "roomId", "roomId", ticket.roomId);
        //    ViewBag.screeningId = new SelectList(db.Screenings, "screeningId", "screeningId", ticket.screeningId);
        //    ViewBag.ticketId = new SelectList(db.OrderDetails, "ticketId", "ticketId", ticket.ticketId);
        //    return View(ticket);
        //}

        //// POST: Tickets/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ticketId,roomId,seatId,seatName,movieId,screeningId")] Ticket ticket)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(ticket).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.movieId = new SelectList(db.Movies, "movieId", "movieTitle", ticket.movieId);
        //    ViewBag.roomId = new SelectList(db.RoomSeats, "roomId", "roomId", ticket.roomId);
        //    ViewBag.screeningId = new SelectList(db.Screenings, "screeningId", "screeningId", ticket.screeningId);
        //    ViewBag.ticketId = new SelectList(db.OrderDetails, "ticketId", "ticketId", ticket.ticketId);
        //    return View(ticket);
        //}

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
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
