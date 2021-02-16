using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Database.Data;
using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace API_Doctors
{
    public class MedicineByIdDataLoader : BatchDataLoader<int, Medicine>
    {
        private readonly AppDbContext _context;
        
        public MedicineByIdDataLoader(
            IBatchScheduler batchScheduler, 
            AppDbContext context) 
            : base(batchScheduler)
        {
            _context = context;
        }

        protected override async Task<IReadOnlyDictionary<int, Medicine>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            return await _context.Medicines
                .Where(x => keys.Contains(x.Id))
                .ToDictionaryAsync(x => x.Id, cancellationToken);
        }
    }
}