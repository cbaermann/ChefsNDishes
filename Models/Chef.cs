using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId{get;set;}
        
        [Required]
        [MinLength(2, ErrorMessage="First name must be at least 2 characters")]
        public string FirstName {get;set;}
       
        [Required]
        [MinLength(2, ErrorMessage="Last name must be at least 2 characters")]
        public string LastName {get;set;}

        [Required]
        
        public DateTime BirthDate {get;set;}
        

        public List<Dish> CreatedDishes {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

    }
}