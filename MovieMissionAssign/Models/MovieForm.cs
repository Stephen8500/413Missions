using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMissionAssign.Models
{
    //class for movie data to be entered into db
    public class MovieForm
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required(ErrorMessage ="You must enter a movie title")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Please input a valid year")]
        //nullable to make sure correct error message 
        public ushort? Year { get; set; }
        [Required(ErrorMessage = "You must enter a director")]
        public string Director { get; set; }
        [Required(ErrorMessage = "You must enter a rating")]
        public string Rating { get; set; }
        //rest of vars not required in db
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        public string Notes { get; set; }

        // foreign key to category table
        [Required(ErrorMessage = "Please select a category")]
        //nullable to be sure correct error message shows if empty
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
