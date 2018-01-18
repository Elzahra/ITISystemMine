using ITISystemMine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITISystemMine.ViewModel
{
    public class StudentDepartmentViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}