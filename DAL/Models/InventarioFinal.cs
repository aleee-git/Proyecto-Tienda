using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class InventarioFinal
    {

        [Key]
        public int IdInventarioFinal { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "Cantidad no válida")]
        public int CantidadCompra { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "Cantidad no válida")]
        public int CantidadVenta { get; set; }


        public int Existencia { get; set; }


        //Llave foránea
        public int IdProducto { get; set; }

    }
}
