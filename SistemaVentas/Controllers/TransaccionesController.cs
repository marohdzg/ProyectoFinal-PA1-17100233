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
    public class TransaccionesController : Controller
    {
        private MaroContext db = new MaroContext();

        // GET: Transacciones
        public ActionResult Index()
        {
            var transaccions = db.Transaccions.Include(t => t.Cliente).Include(t => t.Diseño);
            return View(transaccions.ToList());
        }

        // GET: Transacciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccions.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // GET: Transacciones/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nombre");
            ViewBag.DiseñoID = new SelectList(db.Diseño, "DiseñoID", "Descripcion");
            return View();
        }

        public ActionResult ConfirmarPago()
        {
            return View();
        }

        // POST: Transacciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransaccionID,ClienteID,DiseñoID,FechaTransaccion,Total")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                int intTransaccionID = db.Transaccions.Include(t => t.Cliente).Include(t => t.Diseño).ToList().Count + 1;

                foreach (DiseñoCarrito item in Carrito.lstDisenos)
                {
                    Transaccion miTransaccion = new Transaccion
                    {
                        TransaccionID = intTransaccionID,
                        ClienteID = transaccion.ClienteID,
                        DiseñoID = item.DiseñoID,
                        FechaTransaccion = DateTime.Now,
                        Cantidad = item.Cantidad,
                        PrecioUnitario = db.Diseño.Find(item.DiseñoID).PrecioUnitario,
                        Total = item.SubTotal
                    };
                    db.Transaccions.Add(miTransaccion);
                }
                db.SaveChanges();
                Carrito.lstDisenos = new List<DiseñoCarrito>();
                Carrito.Cliente = db.Clientes.Find(transaccion.ClienteID).Nombre;
                return RedirectToAction("ConfirmarPago");
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nombre", transaccion.ClienteID);
            ViewBag.DiseñoID = new SelectList(db.Diseño, "DiseñoID", "Descripcion", transaccion.DiseñoID);
            return View(transaccion);
        }

        // GET: Transacciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccions.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nombre", transaccion.ClienteID);
            ViewBag.DiseñoID = new SelectList(db.Diseño, "DiseñoID", "Descripcion", transaccion.DiseñoID);
            return View(transaccion);
        }

        // POST: Transacciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransaccionID,ClienteID,DiseñoID,FechaTransaccion,Total")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nombre", transaccion.ClienteID);
            ViewBag.DiseñoID = new SelectList(db.Diseño, "DiseñoID", "Descripcion", transaccion.DiseñoID);
            return View(transaccion);
        }

        // GET: Transacciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccions.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // POST: Transacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaccion transaccion = db.Transaccions.Find(id);
            db.Transaccions.Remove(transaccion);
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
