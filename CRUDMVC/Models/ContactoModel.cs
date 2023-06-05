using System.ComponentModel.DataAnnotations;

namespace CRUDMVC.Models
{
    public class ContactoModel
    {
        public int IdContacto{ get; set; }
        [Required(ErrorMessage ="El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo Teléfono es obligatorio")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El campo Correo es obligatorio, escribe un correo valido")]
        public string? Correo { get; set; }
    }
}
