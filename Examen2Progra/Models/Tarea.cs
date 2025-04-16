using System;
using System.ComponentModel.DataAnnotations;

namespace Examen2Progra.Models
{
    public enum EstadoTarea
    {
        [Display(Name = "Pendiente")]
        Pendiente,
        [Display(Name = "En Progreso")]
        EnProgreso,
        [Display(Name = "Completada")]
        Completada
    }

    public enum Dificultad
    {
        [Display(Name = "Fácil")]
        Facil,
        [Display(Name = "Media")]
        Media,
        [Display(Name = "Difícil")]
        Dificil
    }

    public class Tarea
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "La descripción debe tener entre 5 y 200 caracteres.")]
        public required string Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaLimite { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public EstadoTarea Estado { get; set; }

        [Required(ErrorMessage = "La dificultad es obligatoria.")]
        public Dificultad Dificultad { get; set; }

        [Required(ErrorMessage = "El tiempo estimado es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El tiempo estimado debe ser un valor mayor a 0.")]
        public int TiempoEstimado { get; set; }

        [Display(Name = "Meta Asociada")]
        [Required(ErrorMessage = "Debe especificar la meta asociada.")]
        public int MetaId { get; set; }

        // Propiedad de navegación
        public required Meta Meta { get; set; }
    }
}

