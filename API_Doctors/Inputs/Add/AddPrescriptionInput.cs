using System;

namespace API_Doctors.Inputs.Add
{
    public class PrescriptionInput
    { 
        public string? Name { get; set; }
        public DateTime? CreatedDate{ get; set; }
        public int doctorId { get; set; }
        
    }
}