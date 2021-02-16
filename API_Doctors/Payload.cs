using Database.Data;

namespace API_Doctors
{
    public class Payload
    {
        public class DoctorPayload
        {
            public Doctor Doctor { get;}
            public DoctorPayload(Doctor doctor)
            {
                Doctor = doctor;
            }
        }
        public class PrescriptionPayload
        {
            public Prescription Prescription { get;}
            public PrescriptionPayload(Prescription prescription)
            {
                Prescription = prescription;
            }
        }
        public class MedicinePayload
        {
            public Medicine Medicine { get;}
            
            public MedicinePayload(Medicine medicine)
            {
                Medicine = medicine;
            }
        }
    }
}