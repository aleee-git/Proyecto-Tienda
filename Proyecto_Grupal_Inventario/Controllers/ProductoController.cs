using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Grupal_Inventario.Controllers
{
    public class ProductoController : Controller
    {
        //Objeto contextp
        private Contexto contexto = new Contexto();

        //Mostrar Productos
        public ActionResult MostrarProductos (string categoria)
        {
            var model = contexto.Productos.ToList();

            //Variables para obtener nombre de categoria y proveedor
            var nombreCategoria = contexto.Productos.Include(x => x.Categoria).ToList();
            var nombreProveedor = contexto.Productos.Include(x => x.Proveedores).ToList();
            
            return View(model);
        }


        //Crear o editar 
        public ActionResult CreateOrEditProductos (int idProducto = 0)
        {
            //Lista que se llenará con los datos de categorias
            var ListaCategorias = new List<SelectListItem>();

            foreach (var cat in contexto.Categorias.ToList())
            {
                ListaCategorias.Add(new SelectListItem { Text = cat.NombreCategoria, Value = cat.IdCategoria.ToString() });
            }
            ViewBag.ListaCategorias = ListaCategorias;

            //Lista que se llenará con los datos de proveedores
            var ListaProveedores = new List<SelectListItem>();

            foreach (var pro in contexto.Proveedores.ToList())
            {
                ListaProveedores.Add(new SelectListItem { Text = pro.NombreProveedor, Value = pro.IdProveedor.ToString() });
            }
            ViewBag.ListaProveedores = ListaProveedores;

            //Validar id
            if (idProducto > 0)
            {
                var model = contexto.Productos.FirstOrDefault(x => x.IdProducto == idProducto);
                return View(model);
            }
            else
            {
                var model = new Productos();
                return View(model);
            }
        }


        //Crear o editar 
        [HttpPost]
        public ActionResult CreateOrEditProductos (Productos model)
        {
            //Validar estado de modelo
            if (ModelState.IsValid)
            {
                if (model.IdProducto > 0)
                {
                    contexto.Entry(model).State = EntityState.Modified;
                    contexto.SaveChanges();
                }
                else
                {
                    contexto.Entry(model).State = EntityState.Added;
                    contexto.SaveChanges();
                }
                return RedirectToAction("MostrarProductos");
            }
            return View(model);
        }


        //Eliminar productos
        public ActionResult DeleteProductos (int idProducto)
        {
            var model = contexto.Productos.FirstOrDefault(x => x.IdProducto == idProducto);

            contexto.Entry(model).State = EntityState.Deleted;
            contexto.SaveChanges();
            
            return RedirectToAction("MostrarProductos");
        }


    }
}