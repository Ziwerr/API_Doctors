using System.Linq;
using System.Threading.Tasks;
using API_Doctors.Extensions;
using API_Doctors.Inputs.Add;
using API_Doctors.Inputs.Delete;
using Database.Data;
using HotChocolate;
using HotChocolate.Types;
using static API_Doctors.Payload;

namespace API_Doctors.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class PrescriptionMutation
    {
        public async Task<PrescriptionPayload> AddPrescription(PrescriptionInput input, [Service] AppDbContext context)
        {
            var prescription = new Prescription
            {
                Name = input.Name,
                CreatedDate = input.CreatedDate,
                DoctorId = input.doctorId,
            };
            
            context.Prescriptions.Add(prescription);
            await context.SaveChangesAsync();
            return new PrescriptionPayload(prescription);
        }
        
        public async Task<PrescriptionPayload> DeletePrescription(DeletePrescriptionInput input, [Service] AppDbContext context)
        {
            var prescriptionToDelete = context.Prescriptions.FirstOrDefault(x=>x.Id==input.Id);

            if (prescriptionToDelete == null)
                throw new PrescriptionNotFoundException {Id = input.Id};
            context.Prescriptions.Remove(prescriptionToDelete);
            await context.SaveChangesAsync();
            return new PrescriptionPayload(prescriptionToDelete);
            
        }   
        
        public async Task<PrescriptionPayload> RenamePrescription(RenamePrescriptionInput input, [Service] AppDbContext context)
        {
            var prescription = context.Prescriptions.FirstOrDefault(x=>x.Id==input.Id);

            if (prescription== null)
                throw new PrescriptionNotFoundException {Id = input.Id};
            prescription.Name = input.NewName;
                await context.SaveChangesAsync();
                return new PrescriptionPayload(prescription);
        }

    }
}