using System;

namespace API_Doctors.Extensions
{
    public class PrescriptionNotFoundException : Exception
    {
        public int Id { get; set; }
    }
}