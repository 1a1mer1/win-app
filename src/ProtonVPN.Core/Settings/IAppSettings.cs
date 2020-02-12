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
using System.ComponentModel;
using ProtonVPN.Common;
using ProtonVPN.Core.Models;
using ProtonVPN.Core.Native.Structures;
using ProtonVPN.Core.Profiles.Cached;
using ProtonVPN.Core.Settings.Contracts;

namespace ProtonVPN.Core.Settings
{
    public interface IAppSettings
    {
        event PropertyChangedEventHandler PropertyChanged;
        CachedProfileDataContract Profiles { get; set; }
        DateTime ProfileChangesSyncedAt { get; set; }
        string OvpnProtocol { get; set; }
        string Language { get; set; }
        bool AppFirstRun { get; set; }
        bool ShowNotifications { get; set; }
        WindowPlacement WindowPlacement { get; set; }
        WindowPlacement SidebarWindowPlacement { get; set; }
        double Width { get; set; }
        string AutoConnect { get; set; }
        string QuickConnect { get; set; }
        string LastEventId { get; set; }
        bool StartOnStartup { get; set; }
        bool LoggedInWithSavedCredentials { get; set; }
        StartMinimizedMode StartMinimized { get; set; }
        bool EarlyAccess { get; set; }
        bool RememberLogin { get; set; }
        bool SecureCore { get; set; }
        string LastUpdate { get; set; }
        bool KillSwitch { get; set; }
        bool Ipv6LeakProtection { get; set; }
        bool CustomDnsEnabled { get; set; }
        bool SidebarMode { get; set; }
        bool WelcomeModalShown { get; set; }
        long TrialExpirationTime { get; set; }
        bool AboutToExpireModalShown { get; set; }
        bool ExpiredModalShown { get; set; }
        int OnboardingStep { get; set; }
        int AppStartCounter { get; set; }
        int SidebarTab { get; set; }
        SplitTunnelingApp[] SplitTunnelingBlockApps { get; set; }
        SplitTunnelingApp[] SplitTunnelingAllowApps { get; set; }
        IpContract[] SplitTunnelingIps { get; set; }
        IpContract[] CustomDnsIps { get; set; }
        int SettingsSelectedTabIndex { get; set; }
        bool SplitTunnelingEnabled { get; set; }
        SplitTunnelMode SplitTunnelMode { get; set; }
        string[] GetSplitTunnelApps();
        bool NetShieldEnabled { get; set; }
        int NetShieldMode { get; set; }
        bool NetShieldModalShown { get; set; }
    }
}
