using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class Categorias
    {

        [Key]
        public int IdCategoria { get; set; }


        [Required(ErrorMessage = "El campo no puede estar vacio")]
        public string NombreCategoria { get; set; }


        //Llave foranea de tabla productos
        [ForeignKey("IdCategoria")]
        public ICollection<Productos> Productos { get; set; }

    }
}
