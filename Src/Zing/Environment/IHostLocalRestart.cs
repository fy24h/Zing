﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Caching;
using Zing.Environment.Descriptor;
using Zing.Environment.Configuration;
using Zing.FileSystems.AppData;
using Zing.Logging;
using Zing.Environment.Descriptor.Models;

namespace Zing.Environment
{
    public interface IHostLocalRestart
    {
        /// <summary>
        /// Monitor changes on the persistent storage.
        /// </summary>
        void Monitor(Action<IVolatileToken> monitor);
    }

    public class DefaultHostLocalRestart : IHostLocalRestart, IShellDescriptorManagerEventHandler, IShellSettingsManagerEventHandler
    {
        private readonly IAppDataFolder _appDataFolder;
        private const string fileName = "hrestart.txt";

        public DefaultHostLocalRestart(IAppDataFolder appDataFolder)
        {
            _appDataFolder = appDataFolder;
            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public void Monitor(Action<IVolatileToken> monitor)
        {
            if (!_appDataFolder.FileExists(fileName))
                TouchFile();

            monitor(_appDataFolder.WhenPathChanges(fileName));
        }

        void IShellSettingsManagerEventHandler.Saved(ShellSettings settings)
        {
            TouchFile();
        }

        void IShellDescriptorManagerEventHandler.Changed(ShellDescriptor descriptor, string tenant)
        {
            TouchFile();
        }

        private void TouchFile()
        {
            try
            {
                _appDataFolder.CreateFile(fileName, "Host Restart");
            }
            catch (Exception e)
            {
                Logger.Warning(e, "Error updating file '{0}'", fileName);
            }
        }
    }
}
