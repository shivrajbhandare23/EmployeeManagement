using AutoMapper;
using BancoAssignment.Profile;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagementContext _dbContext;

        private readonly IMapper _mapper;

        public EmployeeRepository(EmployeeManagementContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = EmployeeProfile.InitializeAutomapper();
        }

        public async Task<IList<EmployeesViewData>> GetDepartment()
        {
            var employeeResult = await _dbContext.Departments.ToListAsync();
            return _mapper.Map<IList<EmployeesViewData>>(employeeResult);
        }

        public async Task<EmployeesViewData> GetEmployeeById(int id)
        {
            var employeeResult = await _dbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
            return _mapper.Map<EmployeesViewData>(employeeResult);
        }

        public async Task<IList<EmployeesViewData>> GetEmployees()
        {
            var employeeResult = await _dbContext.Employees.ToListAsync();
            return _mapper.Map<IList<EmployeesViewData>>(employeeResult);
        }

        public async Task<int> AddEmployee(EmployeesViewData employee)
        {
            var employeeData = new Employee()
            {
                EmployeeName = employee.EmployeeName,
                Doj = employee.Doj,
                DeptId = employee.DeptId
            };

            _dbContext.Employees.Add(employeeData);
            await _dbContext.SaveChangesAsync();

            return employeeData.EmployeeId;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            int isEmployeeDeleted;
            var employeeResult = await _dbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (employeeResult != null)
            {
                _dbContext.Employees.Remove(employeeResult);
                isEmployeeDeleted = await _dbContext.SaveChangesAsync();
                return (isEmployeeDeleted > 0);

            }
            return false;
        }

        public async Task<bool> UpdateEmployee(EmployeesViewData employee)
        {
            Employee? empRecord = await _dbContext.Employees.SingleOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);

            int isUpdated;
            if (empRecord != null)
            {
                empRecord.EmployeeName = employee.EmployeeName;
                empRecord.DeptId = employee.DeptId;
                empRecord.Doj = employee.Doj;
                isUpdated = await _dbContext.SaveChangesAsync();
                return (isUpdated > 0);
            }
            return false;
        }
    }
}
