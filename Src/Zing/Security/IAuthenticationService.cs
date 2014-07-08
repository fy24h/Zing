﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Security
{
    public interface IAuthenticationService  
    {
        void SignIn(IUser user, bool createPersistentCookie);
        void SignOut();
        void SetAuthenticatedUserForRequest(IUser user);
        IUser GetAuthenticatedUser();
    }
}
