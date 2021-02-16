using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Database.Data;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace API_Doctors
{ 
    [ExtendObjectType(Name = "Query")]
    public class MedicineQuery
    {
        
        public Task<List<Medicine>> GetMedicines([Service] AppDbContext context) =>
            context.Medicines.ToListAsync();
        
        public Task<Medicine> GetMedicine
            (int id, MedicineByIdDataLoader medicineById, CancellationToken cancellationToken) =>
            medicineById.LoadAsync(id,cancellationToken);
    }
}