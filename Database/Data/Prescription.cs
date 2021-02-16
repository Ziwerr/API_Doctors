using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Data
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string? Name { get; set; }
        public DateTime? CreatedDate{ get; set; }

        [ForeignKey("Doctor")]
        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
    }
}