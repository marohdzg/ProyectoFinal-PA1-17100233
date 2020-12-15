using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaVentas.DAL;
using SistemaVentas.Models;

namespace SistemaVentas.Controllers
{
    public class DiseñoCarritosController : Controller
    {
        private MaroContext db = new MaroContext();

        // GET: DiseñoCarritos
        public ActionResult Index()
        {
            //var diseñoCarrito = db.DiseñoCarrito.Include(d => d.diseño);
            var diseñocarrito = Carrito.lstDisenos;
            return View(diseñocarrito);
        }

        // GET: DiseñoCarritos/Details/5
        public ActionResult Details(DiseñoCarrito dis)
        {
            return View(dis);
        }

        // GET: DiseñoCarritos/Create
        public ActionResult Create()
        {
            ViewBag.DiseñoID = new SelectList(db.Diseño, "DiseñoID", "Descripcion");
            return View();
        }

        // POST: DiseñoCarritos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiseñoCarritoID,DiseñoID,Cantidad,SubTotal")] DiseñoCarrito diseñoCarrito)
        {
            diseñoCarrito.PrecioUnitario = diseñoCarrito.diseño.PrecioUnitario;
            if (ModelState.IsValid)
            {
                db.DiseñoCarrito.Add(diseñoCarrito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DiseñoID = new SelectList(db.Diseño, "DiseñoID", "Descripcion", diseñoCarrito.DiseñoID);
            return View(diseñoCarrito);
        }

        // GET: DiseñoCarritos/Edit/5
        public ActionResult Edit(DiseñoCarrito dis)
        {
            if (dis == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            foreach (DiseñoCarrito item in Carrito.lstDisenos)
            {
                if (item.DiseñoID.Equals(dis.DiseñoID))
                {
                    item.diseño = dis.diseño;
                }
            }
            if (dis == null)
            {
                return HttpNotFound();
            }
            ViewBag.DiseñoID = new SelectList(db.Diseño, "DiseñoID", "Descripcion", dis.DiseñoID);
            return View(dis);
        }

        // GET: DiseñoCarritos/Delete/5
        public ActionResult Delete(DiseñoCarrito dis)
        {
            foreach (DiseñoCarrito item in Carrito.lstDisenos)
            {
                if (item.DiseñoID.Equals(dis.DiseñoID))
                {
                    dis = item;
                }
            }
            return View(dis);
        }

        // POST: DiseñoCarritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DiseñoCarrito dis)
        {
            Carrito.lstDisenos.Remove(dis);
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
