using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Database.Data
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string? FirstName { get; set; }
        
        [Required]
        [StringLength(200)]
        public string? LastName { get; set; }
        
        [Required]
        [StringLength(30)]
        public DateTime BirthDate { get; set; }  
        
        [StringLength(9)]
        public string? PhoneNumber{ get; set; }
        public int WorkYears{ get; set; }
        
        [Required]
        public bool? IsAbleToMakePrescriptions { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        
    }
}