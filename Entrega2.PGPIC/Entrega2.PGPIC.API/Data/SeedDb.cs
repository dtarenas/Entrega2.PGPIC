using Entrega2.PGPIC.API.Helpers;
using Entrega2.PGPIC.Shared.Entities;
using Entrega2.PGPIC.Shared.Entities.Identity;
using Entrega2.PGPIC.Shared.Enums;

namespace Entrega2.PGPIC.API.Data
{
    public class SeedDb
    {
        private readonly PGPICContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(PGPICContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckResearchersAsync();
            await CheckRolesAsync();
            await CheckUserAsync("12345678", "Admin", "Admin", "admin@gmail.com", "321654987", "Cr 125 6548", UserType.Admin);
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);

            if (user == null)
            {
                user = new User
                {
                    Document = document,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phone,
                    UserName = email,
                    Address = address,
                    UserType = userType,
                };

                await _userHelper.AdduserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
            return user;
        }

        private async Task CheckResearchersAsync()
        {
            if (!_context.Researchers.Any())
            {
                var researchers = GetDefaultResearcher();
                _context.AddRange(researchers);
            }

            await _context.SaveChangesAsync();
        }

        private static List<Researcher> GetDefaultResearcher()
        {
            List<Researcher> researchers =
            [
                new() { Name = "John Doe", Specialization = "Inteligencia Artificial", Afiliation = "Universidad A" },
                new() { Name = "Jane Smith", Specialization = "Biología Molecular", Afiliation = "Universidad B" },
                new() { Name = "Carlos García", Specialization = "Física Cuántica", Afiliation = "Universidad C" },
                new() { Name = "Emily Johnson", Specialization = "Neurociencia", Afiliation = "Universidad D" },
                new() { Name = "David Martinez", Specialization = "Ciencias del Clima", Afiliation = "Universidad E" },
                new() { Name = "Maria Rodriguez", Specialization = "Ingeniería Biomédica", Afiliation = "Universidad F" }
            ];

            return researchers;
        }
    }
}