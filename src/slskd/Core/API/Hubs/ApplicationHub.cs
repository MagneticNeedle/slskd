﻿// <copyright file="ApplicationHub.cs" company="slskd Team">
//     Copyright (c) slskd Team. All rights reserved.
//
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU Affero General Public License as published
//     by the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
//
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU Affero General Public License for more details.
//
//     You should have received a copy of the GNU Affero General Public License
//     along with this program.  If not, see https://www.gnu.org/licenses/.
// </copyright>

namespace slskd.Core.API
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR;

    /// <summary>
    ///     Extension methods for the application SignalR hub.
    /// </summary>
    public static class ApplicationHubExtensions
    {
        /// <summary>
        ///     Broadcast the present application state.
        /// </summary>
        /// <param name="hub">The hub.</param>
        /// <param name="state">The state to broadcast.</param>
        /// <returns>The operation context.</returns>
        public static Task BroadcastStateAsync(this IHubContext<ApplicationHub> hub, State state)
        {
            return hub.Clients.All.SendAsync(Methods.State, state);
        }

        private static class Methods
        {
            public static readonly string State = "STATE";
        }
    }

    /// <summary>
    ///     The application SignalR hub.
    /// </summary>
    public class ApplicationHub : Hub
    {
    }
}