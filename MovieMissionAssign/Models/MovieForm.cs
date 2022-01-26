﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMissionAssign.Models
{
    public class MovieForm
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public ushort Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        public string Notes { get; set; }

    }
}