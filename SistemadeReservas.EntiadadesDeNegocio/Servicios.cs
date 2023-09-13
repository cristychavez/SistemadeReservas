using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeReservas.EntiadadesDeNegocio
{
    public class Servicios
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El largo máximo es de 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [MaxLength(50, ErrorMessage = "El largo máximo es de 30 caracteres")]
        public string Estado { get; set; }
    }
}
