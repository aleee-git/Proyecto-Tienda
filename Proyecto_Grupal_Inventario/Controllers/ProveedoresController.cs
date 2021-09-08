using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Grupal_Inventario.Controllers
{
    public class ProveedoresController : Controller
    {
        // GET: Proveedores
        public ActionResult Index()
        {
            return View();
        }

       
        // Agregar
        public ActionResult Agregar()
        {
            return View();
        }

        // POST: Proveedores/Create
        [HttpPost]
        public ActionResult Agregar(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

      

        // GET: Proveedores/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

    }
}
