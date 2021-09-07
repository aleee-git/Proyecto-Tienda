using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class Compras
    {

        [Key]
        public int IdCompra { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "Cantidad no válida")]
        [Required(ErrorMessage = "El campo no puede estar vacio")]
        public int CantidadCompra { get; set; }


        [Required(ErrorMessage = "El campo no puede estar vacio")]
        public DateTime FechaCompra { get; set; }


        //Llaves foraneas
        public int IdProducto { get; set; }
        public int IdProveedor { get; set; }

    }
}
