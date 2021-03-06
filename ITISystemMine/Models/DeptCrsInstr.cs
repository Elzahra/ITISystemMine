﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITISystemMine.Models
{
    public class DeptCrsInstr
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Departments")]
        public int? Department_key { get; set; }
        //
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Courses")]
        public int? Course_key { get; set; }
        //
        [Key]
        [Column(Order = 3)]
        [ForeignKey("Instructors")]
        public int? Instructor_key { get; set; }
        //
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid Number")]
        public float? Full_evaluation { get; set; }

        public virtual Department Departments { get; set; }
        public virtual Course Courses { get; set; }
        public virtual Instructor Instructors { get; set; }
    }
}