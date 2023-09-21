using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeReservas.EntidadesDeNegocio
{
    public class Mesa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El id es requerido")]
        [MaxLength(30, ErrorMessage = "El largo máximo es de 30 caracteres")]
        public string Id { get; set; }

        [Required(ErrorMessage = "El tipo es requerido")]
        public byte Tipo { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        public byte Estado { get; set; }

       
    
    }
}
