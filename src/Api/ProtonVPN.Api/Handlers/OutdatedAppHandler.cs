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
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ProtonVPN.Api.Contracts;
using ProtonVPN.Api.Contracts.Common;
using ProtonVPN.Api.Deserializers;

namespace ProtonVPN.Api.Handlers
{
    /// <summary>
    /// Detects outdated app by checking response code.
    /// </summary>
    public class OutdatedAppHandler : DelegatingHandler
    {
        private readonly IBaseResponseMessageDeserializer _baseResponseDeserializer;
        public event EventHandler<BaseResponse> AppOutdated;

        public OutdatedAppHandler(IBaseResponseMessageDeserializer baseResponseDeserializer)
        {
            _baseResponseDeserializer = baseResponseDeserializer;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            BaseResponse baseResponse = await _baseResponseDeserializer.DeserializeAsync(response);
            if (baseResponse == null)
            {
                return response;
            }

            if (ForceLogoutRequired(baseResponse.Code))
            {
                AppOutdated?.Invoke(this, baseResponse);
            }

            return response;
        }

        private bool ForceLogoutRequired(int code)
        {
            return code is ResponseCodes.OutdatedApiResponse or ResponseCodes.OutdatedAppResponse;
        }
    }
}