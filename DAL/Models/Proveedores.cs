using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
  public  class Proveedores
    {

        [Key]
        public int IdProveedor { get; set; }


        [Required(ErrorMessage = "El campo no puede estar vacio")]
        public string NombreProveedor { get; set; }
        

        [Required(ErrorMessage = "El campo no puede estar vacio")]
        public int Telefono { get; set; }


        //Llave foranea de tabla productos y compras
        [ForeignKey("IdProveedor")]
        public ICollection<Compras> Compras { get; set; }

        [ForeignKey("IdProveedor")]
        public ICollection<Productos> Productos { get; set; }

        

    }
}
