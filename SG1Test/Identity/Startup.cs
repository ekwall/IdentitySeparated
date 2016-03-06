using Microsoft.Owin;
using Owin;
using Library.App_Start;
using Library.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;

//[assembly: OwinStartupAttribute(typeof(Identity.Startup))]
namespace Identity
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var startup = new Library.App_Start.Startup();

            startup.Configuration(app);
            //ConfigureAuth(app);

            
        }
    }
}
