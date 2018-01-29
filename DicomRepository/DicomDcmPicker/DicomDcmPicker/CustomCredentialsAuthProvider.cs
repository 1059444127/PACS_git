using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomDcmPicker
{
    public class CustomCredentialsAuthProvider:CredentialsAuthProvider
    {
        public override bool TryAuthenticate(IServiceBase authService, string userName, string password)
        {
            if (userName == "XYL")
                return true;
            return false;
        }

        public override IHttpResult OnAuthenticated(IServiceBase authService, IAuthSession session, IAuthTokens tokens, Dictionary<string, string> authInfo)
        {
            session.FirstName = "Ryan";
            return base.OnAuthenticated(authService, session, tokens, authInfo);
        }



    }
}
