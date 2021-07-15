﻿/*
 * Copyright (c) 2020 Proton Technologies AG
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
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtonVPN.Common.Networking;
using ProtonVPN.Service.Contract.Vpn;

namespace ProtonVPN.Service.Contract.Test.Vpn
{
    [TestClass]
    public class VpnProtocolContractTest
    {
        [TestMethod]
        public void Enum_ShouldHaveSame_UnderlyingType_As_VpnError()
        {
            // Arrange
            var type = Enum.GetUnderlyingType(typeof(VpnProtocolContract));
            var expected = Enum.GetUnderlyingType(typeof(VpnProtocol));
            // Assert
            type.Should().BeSameAs(expected);
        }

        [TestMethod]
        public void Enum_ShouldHaveSame_Values_As_VpnError()
        {
            // Arrange
            var values = (int[])Enum.GetValues(typeof(VpnProtocolContract));
            var expected = (int[])Enum.GetValues(typeof(VpnProtocol));
            // Assert
            values.Should().BeEquivalentTo(expected);
        }
    }
}