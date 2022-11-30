﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodTrucksMenus.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }
        [Display(Name = "Pais")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<State> States { get; set; }

        [Display(Name = "Estado/Provincia")]
        public int StatesNumber => States == null ? 0 : States.Count;
    }
}