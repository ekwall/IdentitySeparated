using System.Threading.Tasks;
using System.Web.Mvc;
using IdentityViewModels.ViewModels;
using Microsoft.AspNet.Identity.Owin;

namespace IdentityServices.Services
{
    public interface ILoginService
    {
        Task<SignInStatus> Login(LoginViewModel model, string returnUrl);
        Task<SignInStatus> GetSignInStatus(string provider, string code, bool isPersistent, bool rememberBrowser);
    }
}