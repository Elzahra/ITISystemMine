using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITISystemMine.Models
{
    public enum Work_Status
    {
        internal_stat,
        external_stat
    }
    public class Instructor
    {
        public Instructor()
        {
            DeptCrsInstr = new List<DeptCrsInstr>();
            StdCrsInstr = new List<StdCrsInstr>();
            Courses = new List<Course>();
        }
        [Key]
        public int Id { get; set; }
        //
        [Required]
        [Display(Name = "Full Name")]
        [DataType(DataType.Text, ErrorMessage = "Please enter valid Name")]
        public string Name { get; set; }
        //
        [DataType(DataType.Date, ErrorMessage = "Enter Valid Date")]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        //
        [Required]
        [Display(Name = "Degree")]
        [DataType(DataType.Text, ErrorMessage = "Please enter valid Name")]
        public string Degree { get; set; }
        //
        [Required]
        [Display(Name = "Graduation Year")]
        public int Graduation_Year { get; set; }
        //
        [Required]
        [Display(Name = "Work Status")]
        [Range(0, 1, ErrorMessage = "Please enter valid Number")]
        public Work_Status Work_Status { get; set; }

        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public int? Department_Key { get; set; }

        public virtual Department Department { get; set; }

        public virtual List<DeptCrsInstr> DeptCrsInstr { set; get; }
        public virtual List<StdCrsInstr> StdCrsInstr { set; get; }

        public virtual List<Course> Courses { get; set; }
    }
}