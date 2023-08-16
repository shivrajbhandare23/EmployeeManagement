using EmployeeManagement.Manager;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private IEmployeeManager _manager;

        public EmployeeController(IEmployeeManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Route("GetDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _manager.GetDepartment();
            if (departments == null)
            {
                return NotFound();
            }
            return Ok(departments);
        }


        [HttpGet]
        [Route("DisplayEmployees")]
        public async Task<IActionResult> DsiplayEmployees()
        {
            var employees = await _manager.GetEmployees();
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpGet]
        [Route("DisplayEmployeesById/{id}")]
        public async Task<IActionResult> DisplayEmployeesById(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var employees = await _manager.GetEmployeeById(id);
            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }


        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployees([FromBody] EmployeesViewData employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            var empId = await _manager.AddEmployee(employee);

            if (empId > 0)
            {
                return Ok(empId);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeesViewData employee)
        {
            if (ModelState.IsValid)
            {
                await _manager.UpdateEmployee(employee);

                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            bool result;

            result = await _manager.DeleteEmployee(id);
            if (!result)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
