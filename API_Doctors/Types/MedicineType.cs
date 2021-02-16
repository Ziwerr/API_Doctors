using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API_Doctors.DataLoaders;
using API_Doctors.Extensions;
using Database.Data;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace API_Doctors.Types
{
    public class MedicineType : ObjectType<Medicine>
    {
        protected override void Configure(IObjectTypeDescriptor<Medicine> descriptor)
         {
             descriptor
                 .Field(t => t.Prescription)
                 .ResolveWith<MedicineResolver>(t => t.GetPrescription(default!, default!, default));
         }
         private class MedicineResolver
         {
             public async Task<Prescription?> GetPrescription(
                 Medicine medicine,
                 PrescriptionByIdDataLoader prescriptionById,
                 CancellationToken cancellationToken)
             {
                 if (medicine.PrescriptionId is null)
                 {
                     return null;
                 }
                 return await prescriptionById.LoadAsync(medicine.PrescriptionId.Value, cancellationToken);
             }
         }
    }
}