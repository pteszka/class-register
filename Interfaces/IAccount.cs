using System.Security.Claims;
using System.Threading.Tasks;
using ClassRegister.Models;
using ClassRegister.ViewModels;

namespace ClassRegister.Interfaces 
{
    public interface IAccount
    {
        Task<Account> GetAccountFromDB(LoginViewModel loginViewModel);
        ClaimsIdentity CreateClaim(Account account);
    }
}