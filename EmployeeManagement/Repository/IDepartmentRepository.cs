using EmployeeManagement.ViewModel;

namespace EmployeeManagement.Repository
{
    public interface IDepartmentRepository
    {
        Task<IList<DepartmentViewData>> GetDepartment();
        Task<DepartmentViewData> GetDepartmentByID(int id);
        Task<int> AddDepartment(DepartmentViewData department);
        Task<bool> UpdateDepartment(DepartmentViewData department);
        Task<bool> DeleteDepartment(int id);
    }
}
