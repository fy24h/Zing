﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web.SessionState;

namespace Zing.Mvc.Routes
{
    public class RouteDescriptor
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public RouteBase Route { get; set; }
        public SessionStateBehavior SessionState { get; set; }
    }

    public class HttpRouteDescriptor : RouteDescriptor
    {
        public string RouteTemplate { get; set; }
        public object Defaults { get; set; }
        public object Constraints { get; set; }
    }
}