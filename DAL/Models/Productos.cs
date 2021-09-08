using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class Productos
    {

        [Key]
        public int IdProducto { get; set; }


        [Required(ErrorMessage = "El campo no puede estar vacio")]
        public string NombreProducto { get; set; }


        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [Range(0, double.MaxValue, ErrorMessage = "Cantidad no válida")]
        public double Precio { get; set; }


        [Required(ErrorMessage = "El campo no puede estar vacio")]
        public string Descripcion { get; set; }


        [Required(ErrorMessage = "El campo no puede estar vacio")]
        public string Imagen { get; set; }

        //Objeto virtual que permite cargar datos de esas tablas
        public virtual Categorias Categoria { get; set; }
        public virtual Proveedores Proveedores { get; set; }

        //Llaves foráneas
        public int IdCategoria { get; set; }
        public int IdProveedor { get; set; }


        //Llave foranea de tabla compras
        [ForeignKey("IdProducto")]
        public ICollection<Compras> Compras { get; set; }


        //Llave foranea de tabla inventario
        [ForeignKey("IdProducto")]
        public ICollection<InventarioFinal> InventarioFinal { get; set; }


        //Llave foranea de tabla ventas
        [ForeignKey("IdProducto")]
        public ICollection<Ventas> Ventas { get; set; }


    }
}
