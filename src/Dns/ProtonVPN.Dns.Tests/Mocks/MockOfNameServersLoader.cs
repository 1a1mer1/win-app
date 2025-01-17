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

using System.Collections.Generic;
using System.Linq;
using System.Net;
using ProtonVPN.Dns.Contracts.NameServers;

namespace ProtonVPN.Dns.Tests.Mocks
{
    public class MockOfNameServersLoader : INameServersLoader
    {
        public const int DNS_PORT = 53;

        private IList<IPEndPoint> _endpoints = new List<IPEndPoint>();

        public void Set(params IPAddress[] addresses)
        {
            _endpoints = addresses.Select(a => new IPEndPoint(a, DNS_PORT)).ToList();
        }

        public IList<IPEndPoint> Get()
        {
            return _endpoints;
        }
    }
}