using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API_Doctors.DataLoaders;
using API_Doctors.Extensions;
using Database.Data;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace API_Doctors.Types
{
    public class PrescriptionType : ObjectType<Prescription>
    {
        protected override void Configure(IObjectTypeDescriptor<Prescription> descriptor)
         {
             descriptor
                 .Field(t => t.Doctor)
                 .ResolveWith<PrescriptionResolver>(t => t.GetDoctor(default!, default!, default));
             
             descriptor
                 .Field(t => t.Medicines)
                 .ResolveWith<PrescriptionResolver>(t => t.GetMedicine(default!, default!, default, default!));
             
         }
        private class PrescriptionResolver
         {
             public async Task<Doctor?> GetDoctor(
                 Prescription prescription,
                 DoctorByIdDataLoader doctorById,
                 CancellationToken cancellationToken)
             {
                 if (prescription.DoctorId != null)
                     return await doctorById.LoadAsync(prescription.DoctorId.Value, cancellationToken);
                 return null;
             }
             
             public async Task<IEnumerable<Medicine>> GetMedicine(
                 [Parent]Prescription prescription,
                 [Service]AppDbContext dbContextFactory,
                 MedicineByIdDataLoader medicineById,
                 CancellationToken cancellationToken)
             {
                
                 int[] medicinesIds = await dbContextFactory.Medicines
                     .Where(x => x.PrescriptionId == prescription.Id)
                     .Select(s=>s.Id)
                     .ToArrayAsync(cancellationToken: cancellationToken);

                 return await medicineById.LoadAsync(medicinesIds, cancellationToken);
             }
             
         }
    }
}