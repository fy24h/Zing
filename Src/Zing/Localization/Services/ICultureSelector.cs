﻿using System.Web;

namespace Zing.Localization.Services
{
    public class CultureSelectorResult {
        public int Priority { get; set; }
        public string CultureName { get; set; }
    }

    public interface ICultureSelector : IDependency {
        CultureSelectorResult GetCulture(HttpContextBase context);
    }
}
