using System;

namespace API_Doctors.Extensions
{
    public class MedicineNotFoundException : Exception
    {
        public int Id { get; set; }
    }
}