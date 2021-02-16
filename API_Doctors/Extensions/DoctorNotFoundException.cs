using System;

namespace API_Doctors.Extensions
{
    public class DoctorNotFoundException : Exception
    {
        public int Id { get; set; }
    }
}