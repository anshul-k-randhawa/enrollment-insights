
using CourseEnrollment.Core.Models;
using CourseEnrollment.Core.ViewModel;
using System;
using System.Collections.Generic;

namespace CourseEnrollment.Core.SeedWork
{
    public static class ModelConversion
    {
        public static IEnumerable<StudentEnrollment> ConvertToEnrollment(this Schedule schedule)
        {
            List<StudentEnrollment> lst = new List<StudentEnrollment>();
            foreach (var item in schedule.class_details)
            {
                lst.Add(new StudentEnrollment() { StudentId = schedule.student_id, StudentName = schedule.student_name, ClassDate = item.exact_class_date, SubjectName = item.subject_desc, SubjectCode = item.subject_code, CampusCode = item.campus_code, DayOfWeek = item.day_of_week, Duration = item.duration, DurationCode = item.duration_code, EndTime = item.end_time, GpsCoordinates = item.gps_coordinates, HasStandardRoomDescription = item.hasStandardRoomDescription, IsHoliday = item.isHoliday, Room = item.room, RoomNumber = item.room_number, StartTime = item.start_time, WeekEndDate = item.week_end_date, WeekStartDate = item.week_start_date });
            }
            return lst;
        }
    }
}
