using DatabaseLibrary.Contexts;
using DatabaseLibrary.Models;
using DatabaseLibrary.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.Services
{
    public class AuthService
    {
        private readonly ShoeStoreDbContext _context = new ShoeStoreDbContext();
        public async Task<string> GenerateTokenAsync(User user)
        {
            int minutes = 15;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthOptions.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var role = await GetUserRoleByLoginAsync(user.Login);

            var claims = new Claim[]
            {
                    new ("id", user.UserId.ToString()),
                    new ("login", user.Login),
                    new ("role", role.Name),
            };

            var token = new JwtSecurityToken(signingCredentials: credentials,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(minutes),
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserRole> GetUserRoleByLoginAsync(string login)
        {
            var user = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Login == login);
            return user?.Role;
        }

        public async Task<string?> AuthUserAsync(string login, string password)
        {
            var user = await FindUserByLoginAsync(login);
            if (user is null)
                return null;

            if (password == user.Password)
                return await GenerateTokenAsync(user);

            return null;
        }

        public async Task<User?> FindUserByLoginAsync(string login)
            => await _context.Users
                .FirstOrDefaultAsync(u => u.Login == login);
    }
}
