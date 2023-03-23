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
        public async Task<IActionResult> Create([FromForm]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            // create a new employee
            Employee newEmployee = new() 
            { 
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName
            };

            // create a photo list to store and upload files
            List<Photo> photoList = new List<Photo>();
            if(employee.Files.Count >= 0)
            {
                foreach (var formFile in employee.Files)
                {
                    if(formFile.Length >= 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await formFile.CopyToAsync(memoryStream);
                            // upload the file if less than 2MB
                            if(memoryStream.Length > 2097152)
                            {
                                // based on the upload file to create photo instance
                                var newphoto = new Photo()
                                {
                                    Bytes = memoryStream.ToArray(),
                                    FileExtension = Path.GetExtension(formFile.FileName),
                                    Size = formFile.Length,
                                };
                                // add photo instance to the list
                                photoList.Add(newphoto);
                            }
                            else
                            {
                                ModelState.AddModelError("File", "The file is too large.");
                            }
                        }
                    }
                }
            }
            // assign the photos to to the employee using the navigation property
            newEmployee.Photos = photoList;
            await _service.AddAsync(newEmployee);
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