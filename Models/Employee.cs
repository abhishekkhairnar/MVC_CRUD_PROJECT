using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage ="First Name is Required")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        [Required(ErrorMessage = "Middle Name is Required")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        
    }
}



























//[Display(Name = "Date Of Birth")]
//public DateTime DOB { get; set; }
//[Display(Name = "Gender")]
//public string Gender { get; set; }
//[Display(Name = "Department")]
//public string Department { get; set; }
//[Display(Name = "NationalID")]
//public string NationalID { get; set; }
//[Display(Name = "Huduma Number")]
//public string HudumaNumber { get; set; }
//[Display(Name = "Employee Role")]
//public string EmployeeRole { get; set; }
//[Display(Name = "Employee Type")]
//public string EmployeeType { get; set; }
//[Display(Name = "Permenant")]
//public bool Permenant { get; set; }
//[Display(Name = "Permenant Address")]
//public string PermenantAddress { get; set; }
//[Display(Name = "Mobile Number")]
//public string MobileNo { get; set; }
//[Display(Name = "Email Address")]
//[Required(ErrorMessage = "Email Address is Required")]
//public string EmailId { get; set; }
//[Display(Name = "Disability")]
//public bool Disability { get; set; }
//[Display(Name = "Pay Amount")]
//public int PayAmount { get; set; }
//[Display(Name = "Human Resource Allowance")]
//public int HumanResourceAllowance { get; set; }
//[Display(Name = "Leave Travel Allowance")]
//public int LeaveTravelAllowance { get; set; }
//[Display(Name = "Conveyance Allowance")]
//public int ConveyanceAllowance { get; set; }
//[Display(Name = "Medical Allowance")]
//public int MedicalAllowance { get; set; }
//[Display(Name = "House Rent Allowance")]
//public int HouseRentAllowance { get; set; }
//[Display(Name = "Hours Of Work")]
//public int HoursOfWork { get; set; }
//[Display(Name = "Date Of Joining")]
//public DateTime DateOfJoining { get; set; }
//[Display(Name = "Date Of Exit")]
//public DateTime DateOfExit { get; set; }
//[Display(Name = "Tax Relief")]
//public int TaxRelief { get; set; }
//[Display(Name = "User Name")]
//[Required(ErrorMessage = "User Name is Required")]
//public string UserName { get; set; }
//[Display(Name = "Password")]
//[Required(ErrorMessage = "Password is Required")]
//public string Password { get; set; }
//[Display(Name = "Status")]
//public string Status { get; set; }