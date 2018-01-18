using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITISystemMine.Models
{
    public enum CourseStatus
    {
        NotFinish,
        Finish
    }
    public class Course
    {
        public Course()
        {
            DeptCrsInstr = new List<DeptCrsInstr>();
            StdCrsInstr = new List<StdCrsInstr>();
        }
        [Key]
        public int Id { get; set; }
        //
        [Required]
        [DataType(DataType.Text, ErrorMessage = "Please enter valid Name")]
        [Index(IsUnique = true)]
        [MaxLength(20)]
        public string Name { get; set; }
        //
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
        public int LecDuration { get; set; }
        //
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
        public int LabDuration { get; set; }
        //
        [Required]
        public CourseStatus Status { get; set; }    //done by CheckBox
        //
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
        public int Duration { get; set; }

        public virtual List<DeptCrsInstr> DeptCrsInstr { set; get; }
        public virtual List<StdCrsInstr> StdCrsInstr { set; get; }
        public virtual List<Department> Departments { get; set; }
        public virtual List<Instructor> Instructors { get; set; }
    }
}