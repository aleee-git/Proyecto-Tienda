using BAL.IServices;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class CategoriasRepository : ICategoriasRepository, IDisposable
    {
        //declaro el objeto contexto que me permitira tener acceso al modelo
        private readonly Contexto contexto;

        //Declaro el metodo de la clase contexto
        public CategoriasRepository(Contexto contexto_)
        {
            this.contexto = contexto_;
        }

        //Realizo el metodo de crear o editar categoria, en ese caso lo realizo bool para que me ejecute cualquier eleccion agregar o editar
        public bool AgregarEditar(Categorias model)
        {
            bool realizado;
            try
            {

                if (model.IdCategoria > 0)
                {
                    contexto.Entry(model).State = EntityState.Modified;
                }
                else
                {
                    contexto.Entry(model).State = EntityState.Added;
                }
                //guarda los datos y los almacena
                contexto.SaveChanges();

                realizado = true;
            }
            catch (Exception)
            {
                realizado = false;
            }

            return realizado;

        }

        //Este metodo obtiene por id los datos de las categorias, es como un select en bd 
        public Categorias ObtenerId(int IdCa)
        {
            var model = contexto.Categorias.FirstOrDefault(x => x.IdCategoria == IdCa);
            return model;
        }
        public bool EliminarCa(int IdCa)
        {
            bool done;
            var model = ObtenerId(IdCa);

            if (model != null)
            {
                try
                {
                    contexto.Entry(model).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    done = true;
                }
                catch (Exception)
                {

                    done = false;
                }

            }
            else
            {
                done = false;
            }
            return done;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
