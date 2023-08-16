using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models;

public partial class UserLogin
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Passcode { get; set; }
}
