using EmployeeManagement.ViewModel;

namespace EmployeeManagement.Repository
{
    public interface IEmployeeRepository
    {
        Task<IList<EmployeesViewData>> GetDepartment();
        Task<IList<EmployeesViewData>> GetEmployees();
        Task<EmployeesViewData> GetEmployeeById(int id);
        Task<int> AddEmployee(EmployeesViewData employee);
        Task<bool> UpdateEmployee(EmployeesViewData employee);
        Task<bool> DeleteEmployee(int id);
    }
}
