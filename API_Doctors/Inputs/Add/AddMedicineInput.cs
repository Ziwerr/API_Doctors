using System;

namespace API_Doctors.Inputs.Add
{
    public class MedicineInput
    {
        public string MedicineName { get; set; }
        public string CompanyName { get; set; }
        public string ActiveSubstance { get; set; }
        public decimal Weight{ get; set; }
        public decimal Price{ get; set; }
        public int Amount{ get; set; }
        public DateTime ExpirationDate{ get; set; }
        public int? PrescriptionId { get; set; }
    }
}