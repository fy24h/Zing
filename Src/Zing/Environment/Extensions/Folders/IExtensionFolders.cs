﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Environment.Extensions.Models;

namespace Zing.Environment.Extensions.Folders
{
    public interface IExtensionFolders
    {
        IEnumerable<ExtensionDescriptor> AvailableExtensions();
    }
}
