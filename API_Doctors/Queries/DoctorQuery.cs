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
    public class DoctorQuery
    {
        public Task<List<Doctor>> GetDoctors([Service] AppDbContext context) =>
            context.Doctors.ToListAsync();
        
        public Task<Doctor> GetDoctor
        (int id, DoctorByIdDataLoader dataLoader, CancellationToken cancellationToken) 
            => dataLoader.LoadAsync(id, cancellationToken);
        
    }
}