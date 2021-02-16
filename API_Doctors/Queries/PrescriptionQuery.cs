using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API_Doctors.DataLoaders;
using Database.Data;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace API_Doctors
{ 
    [ExtendObjectType(Name = "Query")]

    public class PrescriptionQuery
    {
        public Task<List<Prescription>> GetPrescriptions([Service] AppDbContext context) =>
            context.Prescriptions.ToListAsync();
        
        public Task<Prescription> GetPrescription
            (int id, PrescriptionByIdDataLoader prescriptionById, CancellationToken cancellationToken) =>
            prescriptionById.LoadAsync(id,cancellationToken);
    }
}