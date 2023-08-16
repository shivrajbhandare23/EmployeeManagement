using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public DateTime? Doj { get; set; }

    public int? DeptId { get; set; }

    //public virtual Department? Dept { get; set; }
}
