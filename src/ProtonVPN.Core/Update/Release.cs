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
using System.Collections.Generic;

namespace ProtonVPN.Core.Update
{
    public class Release
    {
        public Release(Version version, bool earlyAccess, bool isNew, IReadOnlyList<string> changeLog)
        {
            Version = version;
            EarlyAccess = earlyAccess;
            New = isNew;
            ChangeLog = changeLog;
        }

        public Version Version { get; }

        public bool EarlyAccess { get; }

        public bool New { get; }

        public IReadOnlyList<string> ChangeLog { get; }
    }
}