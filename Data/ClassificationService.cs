using SeshDB.Data.Sesh;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sesh.Data
{
    public class ClassificationService
    {
        private readonly SeshContext _context;
        public ClassificationService(SeshContext context)
        {
            _context = context;
        }
        public async Task<List<Classifications>>
            GetClassificationsAsync(string strCurrentUser)
        {
            return await _context.Classifications
                .Where(x => x.UserName == strCurrentUser)
                .AsNoTracking().ToListAsync();
        }
    }
}
