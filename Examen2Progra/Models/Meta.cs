using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Examen2Progra.Models
{
    public enum Categoria
    {
        [Display(Name = "Desarrollo Personal")]
        DesarrolloPersonal,
        [Display(Name = "Carrera")]
        Carrera,
        [Display(Name = "Salud")]
        Salud,
        [Display(Name = "Finanzas")]
        Finanzas,
        [Display(Name = "Relaciones")]
        Relaciones,
        [Display(Name = "Otros")]
        Otros
    }

    public enum Prioridad
    {
        [Display(Name = "Alta")]
        Alta,
        [Display(Name = "Media")]
        Media,
        [Display(Name = "Baja")]
        Baja
    }

    public enum EstadoMeta
    {
        [Display(Name = "No Iniciada")]
        NoIniciada,
        [Display(Name = "En Progreso")]
        EnProgreso,
        [Display(Name = "Completada")]
        Completada,
        [Display(Name = "Abandonada")]
        Abandonada
    }

    public class Meta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "El título debe tener entre 5 y 100 caracteres.")]
        public required string Titulo { get; set; }

        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        public Categoria Categoria { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaLimite { get; set; }

        [Required(ErrorMessage = "La prioridad es obligatoria.")]
        public Prioridad Prioridad { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public EstadoMeta Estado { get; set; }

        // Relación: Una Meta puede tener múltiples Tareas asociadas.
        public ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
    }
}
