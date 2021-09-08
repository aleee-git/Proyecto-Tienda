using BAL.IServices;
using BAL.Services;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Grupal_Inventario.Controllers
{
    public class CategoriaController : Controller
    {
        //Declaro el objeto contexto
        Contexto contexto = new Contexto();

        //Inyecto la clase donde esta el repositorio
        private ICategoriasRepository categoriasRepository;

        //Relaciono el controlador con el repositorio para tener entrada a los elementos de la bd y consultas 
        public CategoriaController()
        {
            this.categoriasRepository = new CategoriasRepository(new Contexto());
        }
        // GET: Categoria
        public ActionResult Index()
        { 

            return View();
        }
        //Metodo de mostrar
        public ActionResult ShowCategories()
        {
            var model = contexto.Categorias.ToList();

            return View(model);
        }

        // GET: Categoria/agregar
        public ActionResult AgregarCategoria(int IdCa = 0)
        {
            var model = new Categorias();
            //verifica si se encuentra dentro de la bd obtendra el id
            if (IdCa >0)
            {
                model = categoriasRepository.ObtenerId(IdCa);
            }

            return View(model);
        }

        // POST: Categoria/agregar o editar
        [HttpPost]
        public ActionResult AgregarCategoria(Categorias model)
        {

            if (ModelState.IsValid)
            {
                var hecho = categoriasRepository.AgregarEditar(model);
                if (hecho)
                {
                    return RedirectToAction("ShowCategories");
                }

            }
         
                return View(model);
            
        }


        // metodo eliminar
        public ActionResult EliminarC(int IdCa)
        {
            var done = categoriasRepository.EliminarCa(IdCa);

            return RedirectToAction("ShowCategories");
        }

    }
}
