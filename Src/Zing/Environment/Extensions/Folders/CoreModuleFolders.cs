﻿using System.Collections.Generic;
using Zing.Environment.Extensions.Models;

namespace Zing.Environment.Extensions.Folders {
    public class CoreModuleFolders : IExtensionFolders {
        private readonly IEnumerable<string> _paths;
        private readonly IExtensionHarvester _extensionHarvester;

        public CoreModuleFolders(IEnumerable<string> paths, IExtensionHarvester extensionHarvester) {
            _paths = paths;
            _extensionHarvester = extensionHarvester;
        }

        public IEnumerable<ExtensionDescriptor> AvailableExtensions() {
            return _extensionHarvester.HarvestExtensions(_paths, DefaultExtensionTypes.Module, "Module.txt", false/*isManifestOptional*/);
        }
    }
}