using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission2Assign.Models
{
    public class GradeCalculatorModel
    {
        [Range(0,100)]
        [Required]
        public int? AssignScore { get; set; }
        [Range(0, 100)]
        [Required]
        public int? GrpPrjtScore { get; set; }
        [Range(0, 100)]
        [Required]
        public int? QuizScore { get; set; }
        [Range(0, 100)]
        [Required]
        public int? ExamScore { get; set; }
        [Range(0, 100)]
        [Required]
        public int? IntexScore { get; set; }

    }
}
