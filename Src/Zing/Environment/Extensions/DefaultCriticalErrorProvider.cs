﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Localization;
using System.Collections.Concurrent;

namespace Zing.Environment.Extensions
{
    public class DefaultCriticalErrorProvider : ICriticalErrorProvider
    {
        private ConcurrentBag<LocalizedString> _errorMessages;
        private readonly object _synLock = new object();

        public DefaultCriticalErrorProvider()
        {
            _errorMessages = new ConcurrentBag<LocalizedString>();

        }

        public IEnumerable<LocalizedString> GetErrors()
        {
            return _errorMessages;
        }

        public void RegisterErrorMessage(LocalizedString message)
        {
            if (_errorMessages != null && _errorMessages.All(m => m.TextHint != message.TextHint))
            {
                _errorMessages.Add(message);
            }
        }

        public void Clear()
        {
            lock (_synLock)
            {
                _errorMessages = new ConcurrentBag<LocalizedString>();
            }

        }
    }
}