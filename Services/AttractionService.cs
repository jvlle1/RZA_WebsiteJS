using Microsoft.EntityFrameworkCore;
using RZA_WebsiteJS.Models;

namespace RZA_WebsiteJS.Services
{
    public class AttractionService
    {

        private readonly TlS2302721RzaContext _context;

        public AttractionService(TlS2302721RzaContext context)
        {
            _context = context;
        }
        

        public async Task<List<Attraction>> GetAttractionsAsync()
        {
            return await _context.Attractions.ToListAsync();
        }
    }
}

