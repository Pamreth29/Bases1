using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace CRUD_TAREA1_FELIXMENDEZ_PAMELAMORATAYA.Models
{
    public class EmpleadoModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido.")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo salario es requerido.")]
        public int? Salario { get; set; }

    }
}
