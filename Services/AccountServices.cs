using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ClassRegister.Data;
using ClassRegister.Models;
using ClassRegister.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ClassRegister.Interfaces;

namespace ClassRegister.Services
{
    public class AccountServices : IAccount
    {
        private readonly ClassRegisterContext _context;

        public AccountServices(ClassRegisterContext context)
        {
            _context = context;
        }

        public async Task<Account> GetAccountFromDB(LoginViewModel loginViewModel)
        {
            var getAccountFromDB = await _context
                                        .Accounts
                                        .FirstOrDefaultAsync(a => a.Email == loginViewModel.Email
                                                             && a.Password == loginViewModel.Password);
            return getAccountFromDB;
        }

        public ClaimsIdentity CreateClaim(Account account)
        {
            var role = account.Role;
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, account.Email),
                    new Claim(ClaimTypes.Email, account.Email),
                    new Claim(ClaimTypes.Role as string, account.Role.ToString())
                };
            
            var claimsIdentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            return claimsIdentity;
        }
    }
}
