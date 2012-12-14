﻿using Orchard.ContentManagement;
using Zing.Security.Permissions;

namespace Zing.Security {
    /// <summary>
    /// Entry-point for configured authorization scheme. Role-based system
    /// provided by default. 
    /// </summary>
    public interface IAuthorizationService : IDependency {
        void CheckAccess(Permission permission, IUser user, IContent content);
        bool TryCheckAccess(Permission permission, IUser user, IContent content);
    }
}