using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PagedList;
using SistemaVentas.DAL;
using SistemaVentas.Models;

namespace SistemaVentas.Controllers
{
    public class DiseñosController : Controller
    {
        private MaroContext db = new MaroContext();

        // GET: Diseños
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.OrdenDiseñoID = String.IsNullOrEmpty(sortOrder) ? "diseñoid_desc" : "";
            ViewBag.OrdenPrecioUnitario = sortOrder == "PrecioUnitario" ? "preciounitario_desc" : "PrecioUnitario";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var diseños = db.Diseño.AsEnumerable();

            if (!String.IsNullOrEmpty(searchString))
            {
                diseños = diseños.Where(c => c.Descripcion.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "diseñoid_desc":
                    diseños = diseños.OrderByDescending(c => c.DiseñoID);
                    break;
                case "PrecioUnitario":
                    diseños = diseños.OrderBy(c => c.PrecioUnitario);
                    break;
                case "preciounitario_desc":
                    diseños = diseños.OrderByDescending(c => c.PrecioUnitario);
                    break;
                default:
                    diseños = diseños.OrderBy(c => c.DiseñoID);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(diseños.ToPagedList(pageNumber, pageSize));
        }

        //Método para agregar el diseño al carrito
        [HttpPost]
        public ActionResult AgregarCarrito(FormCollection form)
        {
            Diseño dis = db.Diseño.Find(int.Parse(Request["item.DiseñoID"].ToString()));

            DiseñoCarrito item = new DiseñoCarrito();
            item.DiseñoCarritoID = Carrito.lstDisenos.Count + 1;
            item.diseño = dis;
            item.DiseñoID = dis.DiseñoID;
            item.Cantidad = int.Parse(Request["Cantidad"].ToString());
            item.CalcularSubtotal();
            item.PrecioUnitario = item.diseño.PrecioUnitario;

            //Agregamos el artículo al carrito(lista)
            Carrito.lstDisenos.Add(item);


            if (dis == null)
            {
                return HttpNotFound();
            }
            return View(dis);
        }

        // GET: Diseños/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diseño diseño = db.Diseño.Find(id);
            if (diseño == null)
            {
                return HttpNotFound();
            }
            return View(diseño);
        }

        // GET: Diseños/Create
        public ActionResult Create()
        {
            ViewBag.TipoID = new SelectList(db.Tipos, "TipoID", "NombreTipo");
            return View();
        }

        // POST: Diseños/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiseñoID,TipoID,Descripcion,PrecioUnitario,Imagen")] Diseño diseño)
        {
            HttpPostedFileBase FileBase = Request.Files[0];

            if (FileBase.ContentLength == 0)
            {
                ModelState.AddModelError("Imagen", "Es necesario seleccionar una imagen.");
            }
            else
            {
                if (FileBase.FileName.EndsWith(".png"))
                {
                    WebImage img = new WebImage(FileBase.InputStream);

                    diseño.Imagen = img.GetBytes();
                }
                else
                {
                    ModelState.AddModelError("Imagen", "Sólo se permiten imágenes *.png");
                }
            }


            if (ModelState.IsValid)
            {
                db.Diseño.Add(diseño);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoID = new SelectList(db.Tipos, "TipoID", "NombreTipo", diseño.TipoID);
            return View(diseño);
        }

        // GET: Diseños/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diseño diseño = db.Diseño.Find(id);
            if (diseño == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoID = new SelectList(db.Tipos, "TipoID", "NombreTipo", diseño.TipoID);
            return View(diseño);
        }

        // POST: Diseños/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiseñoID,TipoID,Descripcion,PrecioUnitario,Imagen")] Diseño diseño)
        {
            //byte[] imagenActual = null;
            Diseño diseno = new Diseño();

            HttpPostedFileBase FileBase = Request.Files[0];

            if (FileBase.ContentLength == 0)
            {
                diseno = db.Diseño.Find(diseño.DiseñoID);
                diseño.Imagen = diseno.Imagen;
            }
            else
            {
                if (FileBase.FileName.EndsWith(".png"))
                {
                    WebImage img = new WebImage(FileBase.InputStream);

                    diseño.Imagen = img.GetBytes();
                }
                else
                {
                    ModelState.AddModelError("Imagen", "Sólo se permiten imágenes *.png");
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(diseno).State = EntityState.Detached;
                db.Entry(diseño).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoID = new SelectList(db.Tipos, "TipoID", "NombreTipo", diseño.TipoID);
            return View(diseño);
        }

        // GET: Diseños/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diseño diseño = db.Diseño.Find(id);
            if (diseño == null)
            {
                return HttpNotFound();
            }
            return View(diseño);
        }

        // POST: Diseños/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diseño diseño = db.Diseño.Find(id);
            db.Diseño.Remove(diseño);
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

        public ActionResult getImage(int id)
        {
            Diseño diseño = db.Diseño.Find(id);
            byte[] byteImage = diseño.Imagen;

            MemoryStream memoryStream = new MemoryStream(byteImage);
            Image image = Image.FromStream(memoryStream);

            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Png);
            memoryStream.Position = 0;

            return File(memoryStream, "image/png");
        }

        public string getTipo(int id)
        {
            return db.Tipos.Find(id).NombreTipo;
        }
    }
}
