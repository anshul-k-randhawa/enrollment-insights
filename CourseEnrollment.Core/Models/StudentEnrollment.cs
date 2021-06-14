using CourseEnrollment.Core.SeedWork;
using System;

namespace CourseEnrollment.Core.Models
{
    public class StudentEnrollment : Entity
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        
        public string SubjectCode { get; set; }
        
        public string SubjectName { get; set; }
        
        public DateTime ClassDate { get; set; }
        
        public DateTime WeekStartDate { get; set; }
        
        public DateTime WeekEndDate { get; set; }
        
        public string DayOfWeek { get; set; }
        
        public string RoomNumber { get; set; }
        
        public string GpsCoordinates { get; set; }
        
        public string Room { get; set; }
        
        public string StartTime { get; set; }
        
        public string EndTime { get; set; }
        
        public string CampusCode { get; set; }
        
        public bool HasStandardRoomDescription { get; set; }
        
        public int Duration { get; set; }
        
        public string DurationCode { get; set; }
        
        public bool IsHoliday { get; set; }
    }
}
