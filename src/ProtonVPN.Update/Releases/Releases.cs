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
using System.Collections;
using System.Collections.Generic;
using ProtonVPN.Update.Contracts;

namespace ProtonVPN.Update.Releases
{
    /// <summary>
    /// Transforms deserialized release data (stream of <see cref="CategoryContract"/>) into stream of <see cref="Release"/>.
    /// </summary>
    public class Releases : IEnumerable<Release>
    {
        private readonly IEnumerable<CategoryContract> _categories;
        private readonly Version _currentVersion;
        private readonly string _earlyAccessCategoryName;

        public Releases(IEnumerable<CategoryContract> categories, Version currentVersion, string earlyAccessCategoryName)
        {
            _categories = categories;
            _currentVersion = currentVersion;
            _earlyAccessCategoryName = earlyAccessCategoryName;
        }

        public IEnumerator<Release> GetEnumerator()
        {
            foreach (var category in _categories)
            {
                if (category.Releases == null)
                    continue;

                var earlyAccess = string.Equals(_earlyAccessCategoryName, category.Name, StringComparison.OrdinalIgnoreCase);

                foreach (var release in category.Releases)
                {
                    yield return new Release(release, earlyAccess, _currentVersion);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
