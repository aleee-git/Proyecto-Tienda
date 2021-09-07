using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Ventas
    {
        [Key]
        public int IdVenta { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "Cantidad no válida")]
        [Required(ErrorMessage = "El campo no puede estar vacio")]
        public int CantidadVenta { get; set; }


        [Required(ErrorMessage = "El campo no puede estar vacio")]
        public DateTime FechaVenta { get; set; }


         //Llaves foráneas
        public int IdProducto { get; set; }
         
    }
}
