using System;

namespace Database.Data
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string CompanyName { get; set; }
        
        public string ActiveSubstance { get; set; }
        
        public decimal Weight{ get; set; }
        
        public decimal Price{ get; set; }
        
        public int Amount{ get; set; }
        
        public DateTime ExpirationDate{ get; set; }
        public int? PrescriptionId { get; set; }
        public Prescription? Prescription { get; set; }
    }
}