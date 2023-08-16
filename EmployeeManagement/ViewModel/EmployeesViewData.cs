using EmployeeManagement.Models;

namespace EmployeeManagement.ViewModel
{
    public class EmployeesViewData
    {
        public int EmployeeId { get; set; }

        public string? EmployeeName { get; set; }

        public DateTime? Doj { get; set; }

        public int? DeptId { get; set; }

        public virtual Department? Dept { get; set; }
    }
}
