using System.ComponentModel.DataAnnotations;

namespace MantenedorVehiculos.Models
{
    public class ModeloVehiculos
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Marca es obligatorio")]
        public string? Marca { get; set; }
        [Required(ErrorMessage = "El campo Modelo es obligatorio")]
        public string? Modelo { get; set; }
        [Required(ErrorMessage = "El campo Color es obligatorio")]
        public string? Color { get; set; }
        [Required(ErrorMessage = "El campo Patente es obligatorio")]
        public string? Patente { get; set; }
        //[Required(ErrorMessage = "El campo Año es obligatorio")]
        [Range(1850,2024, ErrorMessage = "El Año está fuera de rango o vacío")]
        public int Anio { get; set; }
        [Required]
        public int Cilindrada { get; set; }
    }
}
