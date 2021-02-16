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
    public class DoctorMutation
    {
        public async Task<DoctorPayload> AddDoctor(AddDoctorInput input, [Service] AppDbContext context)
        {
            var doctor = new Doctor
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                BirthDate = input.BirthDate,
                PhoneNumber = input.PhoneNumber,
                WorkYears = input.WorkYears,
                IsAbleToMakePrescriptions = input.IsAbleToMakePrescriptions,
            };

            context.Doctors.Add(doctor);
            await context.SaveChangesAsync();

            return new DoctorPayload(doctor);
        }
        
        public async Task<DoctorPayload> DeleteDoctor(DeleteDoctorInput input, [Service] AppDbContext context)
        {
            var doctorToDelete = context.Doctors.FirstOrDefault(x=>x.Id==input.Id);

            if (doctorToDelete == null)
                throw new DoctorNotFoundException {Id = input.Id};

            context.Doctors.Remove(doctorToDelete);
            await context.SaveChangesAsync();
            
            return new DoctorPayload(doctorToDelete);
            
        }

    }
}