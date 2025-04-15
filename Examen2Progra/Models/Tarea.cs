using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Examen2Progra.Models;

namespace Examen2Progra.Models
{
    public enum TareaEstado
    {
        Pendiente, EnProgreso, Completada
    }

    public enum TareaDificultad
    {
        Facil, Media, Dificil
    }

    public class Tarea
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "La descripción debe tener entre 5 y 200 caracteres.")]
        public required string Descripcion { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Display(Name = "Fecha Límite")]
        public DateTime? FechaLimite { get; set; }

        [Display(Name = "Estado")]
        public TareaEstado Estado { get; set; }

        [Display(Name = "Dificultad")]
        public TareaDificultad Dificultad { get; set; }

        [Display(Name = "Tiempo Estimado (horas)")]
        public int TiempoEstimado { get; set; }

        public int MetaId { get; set; }  // Clave foránea
        [ForeignKey("MetaId")]
        public required Meta Meta { get; set; }    // Navegación a Meta
    }
}