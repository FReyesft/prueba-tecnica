using Inmersys.Core.Dtos;
using Inmersys.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inmersys.Api.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;
        public EmployeesController(IEmployeesService employeesService) { 
            _employeesService = employeesService;
        }
        [HttpGet]
        public async Task<ActionResult<GetListEmployeesDto>> GetAllEmployees() {
            return Ok(await _employeesService.GetAllEmployeesAsync());
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeResponseDto>> CreateEmployee(CreateEmployeeRequestDto createEmployeeRequestDto)
        {
            return Ok(await _employeesService.CreateEmployeeAsync(createEmployeeRequestDto));
        }

        [HttpPut("{IdEmployee}")]
        public async Task<ActionResult<EmployeeResponseDto>> UpdateEmployee(int IdEmployee, CreateEmployeeRequestDto createEmployeeRequestDto)
        {
            return Ok(await _employeesService.UpdateEmployeeAsync(IdEmployee, createEmployeeRequestDto));
        }

        [HttpDelete("{IdEmployee}")]
        public async Task<ActionResult<EmployeeResponseDto>> DeleteEmployee([FromRoute]int IdEmployee)
        {
            return Ok(await _employeesService.DeleteEmployeeAsync(IdEmployee));
        }

        [HttpGet("{IdEmployee}")]
        public async Task<ActionResult<GetListEmployeesDto>> GetEmployeeById([FromRoute] int IdEmployee)
        {
            return Ok(await _employeesService.GetEmployeeByIdAsync(IdEmployee));
        }
    }
}
