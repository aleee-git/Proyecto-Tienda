using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class DatosUsuarios
    {

        [Key]
        public int IdUsuario { get; set; }


        [Required(ErrorMessage = "El campo no puede estar vacio")]
        public string Nombre { get; set; }
         

        [Required(ErrorMessage = "El campo no puede estar vacio")]
        public string Usuario { get; set; }


        [Required(ErrorMessage = "El campo no puede estar vacio")]
        public string Contra { get; set; }


        [Required(ErrorMessage = "El campo no puede estar vacio")]
        public string Carnet { get; set; }
         

        public bool IsActive { get; set; }


        public Roles Roles { get; set; }

    }

    public enum Roles
    {

        [Description("Administrador")]
        Admin,
        [Description("Vendedor")]
        Vendedor

    }

}
