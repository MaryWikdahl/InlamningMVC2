using Inlamning2Mvc.Models;
using Inlamning2Mvc.Models.Data;
using Inlamning2Mvc.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Inlamning2Mvc.Helpers
{
   
        public interface IProfileManager
        {
            Task<ProfileResult> CreateAsync(IdentityUser user, UserProfile profile);
            Task<UserProfile> ReadAsync(string userId);

            Task<string> DisplayNameAsync(string userId);

            string GetRolesById(int userId);
        }

        public class ProfileManager : IProfileManager
        {
            private readonly AppDbContext _context;

            public ProfileManager(AppDbContext context)
            {
                _context = context;
            }

            public async Task<ProfileResult> CreateAsync(IdentityUser user, UserProfile profile)
            {
                if (await _context.Users.AnyAsync(x => x.Id == user.Id))
                {
                    var profileEntity = new ProfileEntity
                    {
                        FirstName = profile.FirstName,
                        LastName = profile.LastName,
                        Address = profile.Address,
                        ZipCode = profile.ZipCode,
                        City = profile.City,
                        Country = profile.Country,
                        UserId = user.Id
                    };
                    _context.Profiles.Add(profileEntity);
                    await _context.SaveChangesAsync();

                    return new ProfileResult { Succeeded = true };
                }

                return new ProfileResult { Succeeded = false };
            }

            public async Task<UserProfile> ReadAsync(string userId)
            {
                var profile = new UserProfile();
                var profileEntity = await _context.Profiles.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == userId);
                if (profileEntity != null)
                {
                    profile.FirstName = profileEntity.FirstName;
                    profile.LastName = profileEntity.LastName;
                    profile.Email = profileEntity.User.Email;
                    profile.Address = profileEntity.Address;
                    profile.ZipCode = profileEntity.ZipCode;
                    profile.City = profileEntity.City;
                    profile.Country = profileEntity.Country;
                    profile.Id = profileEntity.Id;
                }

                return profile;
            }

            public async Task<string> DisplayNameAsync(string userId)
            {
                var result = await ReadAsync(userId);
                return $"{result.FirstName} {result.LastName}";
            }
            public string GetRolesById(int id)
            {
                var userId = _context.Profiles.Where(p => p.Id == id).Select(p => p.UserId).FirstOrDefault();
                var userRoles = _context.UserRoles.Where(r => r.UserId == userId).Select(r => r.RoleId).FirstOrDefault();
                return _context.Roles.Where(r => r.Id == userRoles).Select(r => r.Name).FirstOrDefault();
            }
    }

        public class ProfileResult
        {
            public bool Succeeded { get; set; } = false;
        }
}

