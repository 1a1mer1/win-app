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

using System.Windows;
using System.Windows.Controls;

namespace ProtonVPN.Core.Wpf
{
    public class PlaceholderTextBox : TextBox
    {
        public Thickness ActiveBorderThickness
        {
            get => (Thickness)GetValue(ActiveBorderThicknessProperty);
            set => SetValue(ActiveBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty ActiveBorderThicknessProperty = DependencyProperty.Register(
            "ActiveBorderThickness",
            typeof(Thickness),
            typeof(PlaceholderTextBox),
            new PropertyMetadata(new Thickness(0, 0, 0, 0)));
    }
}
