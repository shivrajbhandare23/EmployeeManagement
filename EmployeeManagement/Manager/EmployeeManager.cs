using EmployeeManagement.Repository;
using EmployeeManagement.ViewModel;

namespace EmployeeManagement.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeManager(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<EmployeesViewData>> GetEmployees()
        {
            return await _repository.GetEmployees();
        }

        public async Task<EmployeesViewData> GetEmployeeById(int id)
        {
            return await _repository.GetEmployeeById(id);
        }

        public async Task<int> AddEmployee(EmployeesViewData employee)
        {
            return await _repository.AddEmployee(employee);
        }

        public async Task<bool> UpdateEmployee(EmployeesViewData employee)
        {
            return await _repository.UpdateEmployee(employee);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            return await _repository.DeleteEmployee(id);
        }

        public async Task<IList<EmployeesViewData>> GetDepartment()
        {
            return await _repository.GetDepartment();
        }
    }
}
