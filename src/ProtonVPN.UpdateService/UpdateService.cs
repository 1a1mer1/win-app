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
using System.ServiceProcess;

namespace ProtonVPN.UpdateService
{
    public partial class UpdateService : ServiceBase
    {
        private readonly ServiceHost _serviceHost;

        public UpdateService(ServiceHost serviceHost)
        {
            _serviceHost = serviceHost;
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                _serviceHost.Open();
            }
            catch
            {
            }
        }

        protected override void OnStop()
        {
            try
            {
                _serviceHost.Close();
            }
            catch
            {
            }
        }
    }
}
