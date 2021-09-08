using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
    public interface ICategoriasRepository : IDisposable
    {
        bool AgregarEditar(Categorias model);
        Categorias ObtenerId(int IdCa);
        bool EliminarCa(int IdCa);
    }
}