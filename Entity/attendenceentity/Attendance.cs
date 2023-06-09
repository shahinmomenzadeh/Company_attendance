﻿using model;

public class Attendance : BaseEntity
{
    public int EmployeeId { get; set; }
    public DateTime EntryTime { get; set; }
    public DateTime ExitTime { get; set; }
    public Employee Employee { get; set; }
}