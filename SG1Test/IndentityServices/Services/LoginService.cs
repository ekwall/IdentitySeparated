using IdentityViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Library.App_Start;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Host.SystemWeb;




namespace IdentityServices.Services
{
    public class LoginService : ILoginService
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public LoginService()
        {
                
        }

        public LoginService(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
       
        

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public async Task<SignInStatus> GetSignInStatus(string provider, string code, bool isPersistent, bool rememberBrowser)
        {
            SignInStatus result = await SignInManager.TwoFactorSignInAsync(provider, code, isPersistent, rememberBrowser);
            return result;
        }

        public async Task<SignInStatus> Login(LoginViewModel model, string returnUrl)
        {
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            return result;
            
            
        }

    }
}
