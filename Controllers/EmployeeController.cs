using Assignment1.Data;
using Assignment1.Data.Services;
using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        public async Task< IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        // Get : Employee/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FirstName,MiddleName,LastName")]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            await _service.AddAsync(employee);
            return RedirectToAction(nameof(Index));
        }
        // Get : Employee/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var employeeDetails = await _service.GetByIdAsync(id);
            if(employeeDetails == null)
            {
                return View("Empty");
            }
            else
            {
                return View(employeeDetails);
            }
        }


        // Edit
        public async Task <IActionResult> Edit(int id)
        {
            var employeeDetails = await _service.GetByIdAsync(id);
            if (employeeDetails == null)
            {
                return View("Not found:(");
            }
            else
            {
                return View(employeeDetails);
            }
        }
        [HttpPost] 
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName")] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            await _service.UpdateAsync(id,employee);
            return RedirectToAction(nameof(Index));
        }


        // Delete
        public async Task <IActionResult> Delete(int id)
        {
            var employeeDetails = await _service.GetByIdAsync(id);
            if (employeeDetails == null)
            {
                return View("Not found:(");
            }
            else
            {
                return View(employeeDetails);
            }
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeDetails = await _service.GetByIdAsync(id);
            if (employeeDetails == null)
            {
                return View("Not found:(");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
         
        }
    }
}
//"FirstName,LastName,MiddleName,DOB,Department,NationalID,HudumaNumber,EmployeeRole,EmployeeType,Permenant,PermenantAddress,MobileNo,EmailId,Disability,PayAmount,HumanResourceAllowance,LeaveTravelAllowance,ConveyanceAllowance,MedicalAllowance,HouseRentAllowance,HoursOfWork,DateOfJoining,DateOfExit,TaxRelief,UserName,Password,Status"