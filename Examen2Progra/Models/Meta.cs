using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace Examen2Progra.Models
{
    public enum MetaCategoria
    {
        DesarrolloPersonal, Carrera, Salud, Finanzas, Relaciones, Otros
    }

    public enum MetaPrioridad
    {
        Alta, Media, Baja
    }

    public enum MetaEstado
    {
        NoIniciada, EnProgreso, Completada, Abandonada
    }

    public class Meta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "El título debe tener entre 5 y 100 caracteres.")]
        public required string Titulo { get; set; }

        [Display(Name = "Descripción")]
        public required string Descripcion { get; set; }

        [Display(Name = "Categoría")]
        public MetaCategoria Categoria { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Display(Name = "Fecha Límite")]
        public DateTime? FechaLimite { get; set; }

        [Display(Name = "Prioridad")]
        public MetaPrioridad Prioridad { get; set; }

        [Display(Name = "Estado")]
        public MetaEstado Estado { get; set; }

        public List<Tarea> Tareas { get; set; } = new List<Tarea>(); // Relación con Tareas
    }
}