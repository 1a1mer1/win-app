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

using System.IO;

namespace ProtonVPN.Core.OS.FileSystem
{
    public class File
    {
        private readonly string _path;

        public File(string path)
        {
            _path = path;
        }

        public byte[] Content()
        {
            using (var fs = new FileStream(_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                var length = (int)fs.Length;
                var buffer = new byte[length];
                fs.Read(buffer, 0, length);
                return buffer;
            }
        }
    }
}
