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
    public class MedicineMutation
    {
        public async Task<MedicinePayload> AddMedicine(MedicineInput input, [Service] AppDbContext context)
        {
            var medicine = new Medicine
            {
                Name = input.MedicineName,
                Amount = input.Amount,
                PrescriptionId = input.PrescriptionId,
                Price = input.Price,
                Weight = input.Weight,
                ActiveSubstance = input.ActiveSubstance,
                CompanyName = input.CompanyName,
                ExpirationDate = input.ExpirationDate
            };
            
            context.Medicines.Add(medicine);
            await context.SaveChangesAsync();
            return new MedicinePayload(medicine);
        }
        
        public async Task<MedicinePayload> DeleteMedicine(DeleteMedicineInput input, [Service] AppDbContext context)
        {
            var medicineToDelete = context.Medicines.FirstOrDefault(x=>x.Id==input.Id);
            
            if (medicineToDelete == null)
                throw new MedicineNotFoundException() {Id = input.Id};
            context.Medicines.Remove(medicineToDelete);
            await context.SaveChangesAsync();
            return new MedicinePayload(medicineToDelete);
            
        }
    }
}