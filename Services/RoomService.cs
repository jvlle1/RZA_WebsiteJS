using RZA_WebsiteJS.Models;
using Microsoft.EntityFrameworkCore;

namespace RZA_WebsiteJS.Services
{
    public class RoomService
    {
        private readonly TlS2302721RzaContext _context;
        public RoomService(TlS2302721RzaContext context)
        {
            _context = context;
        }
        public async Task<List<Room>> GetRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }
        public async Task<Room> GetRoomAsync(int roomNumber)
        {
            return await _context.Rooms.FirstAsync(r => r.RoomNumber == roomNumber);
        }


    }
}
