using EmployeeManagement.Manager;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private IDepartmentManager _manager;
        public DepartmentController(IDepartmentManager manager)
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
        [Route("GetDepartmentByID/{id}")]
        public async Task<IActionResult> GetDepartmentByID(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var department = await _manager.GetDepartmentByID(id);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }


        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentViewData department)
        {
            if (department == null)
            {
                return BadRequest();
            }

            var empId = await _manager.AddDepartment(department);

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
        [Route("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment([FromBody] DepartmentViewData department)
        {
            if (ModelState.IsValid)
            {
                await _manager.UpdateDepartment(department);

                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteDepartment/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            bool result;

            result = await _manager.DeleteDepartment(id);
            if (!result)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
