using CourseEnrollment.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseEnrollment.Core.Models
{
    public class StaffRegistration : Entity
    {
        public string StaffName { get; set; }
        public string StaffEmail { get; set; }
        public string StaffPswd { get; set; }
        public string StaffPhone { get; set; }
        public string StaffDepartment { get; set; }
    }

}
