using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API_Doctors.DataLoaders;
using API_Doctors.Extensions;
using Database.Data;
using GreenDonut;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace API_Doctors.Types
{
    public class DoctorType : ObjectType<Doctor>
    {
        protected override void Configure(IObjectTypeDescriptor<Doctor> descriptor)
        {
            descriptor
                .Field(t => t.Prescriptions)
                .ResolveWith<DoctorResolver>(t => t.GetPrescriptions(default!, default!, default!, default!));
        }
        private class DoctorResolver
        {
            public async Task<IEnumerable<Prescription?>> GetPrescriptions(
                [Parent]Doctor doctor,
                [Service]AppDbContext dbContextFactory,
                PrescriptionByIdDataLoader prescriptionById,
                CancellationToken cancellationToken)
            {
                int[] prescriptionIds = await dbContextFactory.Prescriptions
                    .Where(x => x.DoctorId == doctor.Id)
                    .Select(s=>s.Id)
                    .ToArrayAsync(cancellationToken: cancellationToken);
            
                return await prescriptionById.LoadAsync(prescriptionIds, cancellationToken);
            }
        }
    }
}