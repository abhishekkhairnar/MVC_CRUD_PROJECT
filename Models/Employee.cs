using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        //navigation property: configure one-t0-many relationship with Photo   
        public List<Photo> Photos { get; set; }

        [FromForm]
        [NotMapped]
        public IFormFileCollection Files { get; set; }

    }
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public byte[] Bytes { get; set; }
        public string FileExtension { get; set; }
        public decimal Size { get;set; }    
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }

}