using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

    
    [ForeignKey("EmpRef")]
    public int EmpRef { get; set; }
    public Employee? emps { get; set; }


    public DayAttendance Sunday { get; set; } = new DayAttendance();
        public DayAttendance Monday { get; set; } = new DayAttendance();
        public DayAttendance Tuesday { get; set; } = new DayAttendance();
        public DayAttendance Wednesday { get; set; } = new DayAttendance();
        public DayAttendance Thursday { get; set; } = new DayAttendance();
        public DayAttendance Friday { get; set; } = new DayAttendance();
        public DayAttendance Saturday { get; set; } = new DayAttendance();
    }

    public class DayAttendance
    {
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
    }
