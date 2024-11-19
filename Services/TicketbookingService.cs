using Microsoft.EntityFrameworkCore;
using RZA_WebsiteJS.Models;

namespace RZA_WebsiteJS.Services
{
    public class TicketbookingService
    {
        private readonly TlS2302721RzaContext _context;
        public TicketbookingService(TlS2302721RzaContext context)
        {
            _context = context;
        }
        public async Task<List<Ticketbooking>> GetTicketbookingsAsync()
        {
            return await _context.Ticketbookings.ToListAsync();
        }
        public async Task AddTicketbookingAsync(Ticketbooking newTicketbooking)
        {
            await _context.Ticketbookings.AddAsync(newTicketbooking);
            await _context.SaveChangesAsync();
        }
    }
}
