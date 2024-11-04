using RZA_WebsiteJS.Models;
using Microsoft.EntityFrameworkCore;

namespace RZA_WebsiteJS.Services
{
    public class CustomerService
    {

        private readonly TlS2302721RzaContext _context;

        public CustomerService(TlS2302721RzaContext context)
        {
            _context = context;
        }   
    }
}
