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

using ProtonVPN.Common.Configuration;
using ProtonVPN.Core.Modals;
using ProtonVPN.Core.Profiles;
using ProtonVPN.Core.Servers;
using ProtonVPN.Core.Settings;

namespace ProtonVPN.Profiles.Form
{
    public class P2PProfileFormViewModel : ServerProfileFormViewModel
    {
        public P2PProfileFormViewModel(
            IConfiguration appConfig,
            ColorProvider colorProvider,
            IUserStorage userStorage,
            ProfileManager profileManager,
            IDialogs dialogs,
            IModals modals,
            ServerManager serverManager,
            IProfileFactory profileFactory) 
            : base(appConfig, colorProvider, userStorage, profileManager, dialogs, modals, serverManager, profileFactory)
        {
        }

        protected override Features GetFeatures()
        {
            return Features.P2P;
        }
    }
}
