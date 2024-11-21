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

        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer?> LogIn(Customer customer)
        {
            return await _context.Customers.FirstOrDefaultAsync(
                c => c.Username == customer.Username &&
                c.Passsword == customer.Passsword);
        }

        public async Task ChangePassword(int customerId, string hashedOldPassword, string hashedNewPassword)
        {
            Customer? customer = await _context.Customers.SingleOrDefaultAsync(
                c => c.CustomerId == customerId &&
                c.Passsword == hashedOldPassword);
            if (customer != null)
            {
                customer.Passsword = hashedNewPassword;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Customer> GetCustomerFromIdAsync(int id)
        {
            return await _context.Customers.FirstAsync(c => c.CustomerId == id);
        }
    }
}
