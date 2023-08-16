using EmployeeManagement.ViewModel;

namespace EmployeeManagement.Manager
{
    public interface IDepartmentManager
    {
        Task<IList<DepartmentViewData>> GetDepartment();
        Task<DepartmentViewData> GetDepartmentByID(int id);
        Task<int> AddDepartment(DepartmentViewData department);
        Task<bool> UpdateDepartment(DepartmentViewData department);
        Task<bool> DeleteDepartment(int id);
    }
}
