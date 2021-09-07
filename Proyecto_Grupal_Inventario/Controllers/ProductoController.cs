using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Grupal_Inventario.Controllers
{
    public class ProductoController : Controller
    {
        //Objeto contextp
        private Contexto contexto = new Contexto();

        public ActionResult MostrarProductos ()
        {
            var model = contexto.Productos.ToList();
            return View(model);
        }


    }
}