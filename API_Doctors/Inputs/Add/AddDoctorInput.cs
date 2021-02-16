using System;

namespace API_Doctors.Inputs.Add
{
    public class AddDoctorInput
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? PhoneNumber{ get; set; }
        public int WorkYears{ get; set; }
        public bool IsAbleToMakePrescriptions { get; set; }
        
    }
    
}