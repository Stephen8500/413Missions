using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMissionAssign.Models
{
    // separate table linked to main movies table
    public class Category
    {
        //id for category
        [Required(ErrorMessage ="Please enter a category")]
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Please enter a category name")]
        public string CategoryName { get; set; }
    }
}
