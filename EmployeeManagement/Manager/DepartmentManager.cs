using EmployeeManagement.Repository;
using EmployeeManagement.ViewModel;
using System.Text.RegularExpressions;

namespace EmployeeManagement.Manager
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentManager(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddDepartment(DepartmentViewData department)
        {
            return await (_repository.AddDepartment(department));
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            return await (_repository.DeleteDepartment(id));
        }

        public async Task<IList<DepartmentViewData>> GetDepartment()
        {
            return await (_repository.GetDepartment());
        }

        public async Task<DepartmentViewData> GetDepartmentByID(int id)
        {
            return await (_repository.GetDepartmentByID(id));
        }

        public async Task<bool> UpdateDepartment(DepartmentViewData department)
        {
            return await (_repository.UpdateDepartment(department));
        }
    }
}
