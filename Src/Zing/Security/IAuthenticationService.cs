﻿namespace Zing.Security {
    public interface IAuthenticationService : IDependency {
        void SignIn(IUser user, bool createPersistentCookie);
        void SignOut();
        void SetAuthenticatedUserForRequest(IUser user);
        IUser GetAuthenticatedUser();
    }
}
