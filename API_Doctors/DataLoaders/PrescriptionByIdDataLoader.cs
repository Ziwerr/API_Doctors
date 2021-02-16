using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Database.Data;
using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace API_Doctors.DataLoaders
{
    public class PrescriptionByIdDataLoader : BatchDataLoader<int, Prescription>
    {
        private readonly AppDbContext _context;
        
        public PrescriptionByIdDataLoader(
            IBatchScheduler batchScheduler, 
            AppDbContext context) 
            : base(batchScheduler)
        {
            _context = context;
        }

        protected override async Task<IReadOnlyDictionary<int, Prescription>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            return await _context.Prescriptions
                .Where(x => keys.Contains(x.Id))
                .ToDictionaryAsync(x => x.Id, cancellationToken);
        }
    }
}