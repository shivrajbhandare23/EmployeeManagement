using EmployeeManagement.Models;

namespace EmployeeManagement.ViewModel
{
    public class DepartmentViewData
    {
        public int DeptId { get; set; }

        public string? DepartmentName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
