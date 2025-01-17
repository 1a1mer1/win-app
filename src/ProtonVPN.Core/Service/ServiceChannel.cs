﻿/*
 * Copyright (c) 2022 Proton Technologies AG
 *
 * This file is part of ProtonVPN.
 *
 * ProtonVPN is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * ProtonVPN is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with ProtonVPN.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using System.ServiceModel;

namespace ProtonVPN.Core.Service
{
    public class ServiceChannel<T> : IDisposable
    {
        private readonly ICommunicationObject _factory;

        public T Proxy { get; }

        public ServiceChannel(ICommunicationObject factory, T channel)
        {
            _factory = factory;
            Proxy = channel;
        }

        public void Dispose()
        {
            try
            {
                _factory.Close();
            }
            catch (CommunicationException)
            {
                _factory.Abort();
            }
            catch (TimeoutException)
            {
                _factory.Abort();
            }
            catch (Exception)
            {
                _factory.Abort();
                throw;
            }
        }
    }
}
