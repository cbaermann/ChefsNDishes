using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId{get;set;}

        [Required]
        [MinLength(4, ErrorMessage="Dish name must have at least 4 characters")]
        public string Name {get;set;}

        [Required]
        public int Calories {get;set;}

        [Required]
        [Range(1,5)]
        public int Tastiness {get;set;}

        [Required]
        public string Description {get;set;}

        [Required]
        public int ChefId {get;set;}

        public Chef Creator {get;set;}

        public DateTime CreatedAt {get;set;}= DateTime.Now;
        public DateTime UpdatedAt {get;set;}= DateTime.Now;
    }
}