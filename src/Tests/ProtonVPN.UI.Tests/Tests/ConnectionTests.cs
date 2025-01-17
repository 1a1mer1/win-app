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

using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using ProtonVPN.UI.Tests.Results;
using ProtonVPN.UI.Tests.TestsHelper;
using ProtonVPN.UI.Tests.Windows;

namespace ProtonVPN.UI.Tests.Tests
{
    [TestFixture]
    [Category("Connection")]
    public class ConnectionTests : TestSession
    {
        private LoginWindow _loginWindow = new LoginWindow();
        private HomeWindow _homeWindow = new HomeWindow();
        private ProfilesWindow _profilesWindow = new ProfilesWindow();
        private SettingsWindow _settingsWindow = new SettingsWindow();
        private HomeResult _homeResult = new HomeResult();
        private SettingsResult _settingsResult = new SettingsResult();
        private LoginResult _loginResult = new LoginResult();

        private const string DNS_ADDRESS = "8.8.8.8";
        private const string GOOGLE_URL = "www.google.com";

        [Test]
        [Category("Smoke")]
        public async Task QuickConnectAndDisconnect()
        {
            TestCaseId = 221;

            _homeWindow.PressQuickConnectButton()
                .WaitUntilConnected();

            ReportTestResults();
            TestCaseId = 229;

            await _homeResult.CheckIfCorrectIpAddressIsDisplayed();

            ReportTestResults();
            TestCaseId = 222;

            _homeWindow.PressQuickConnectButton()
                .WaitUntilDisconnected();
        }

        [Test]
        public void ConnectToProfileViaProfileTab()
        {
            TestCaseId = 225;

            _homeWindow.NavigateToProfilesTab()
                .ConnectViaProfile("Fastest")
                .WaitUntilConnected();
        }

        [Test]
        public void ConnectByCountryList()
        {
            TestCaseId = 223;

            _homeWindow.ConnectViaCountry("Netherlands")
                .WaitUntilConnected();

            ReportTestResults();
            TestCaseId = 224;

            _homeWindow.PressDisconnectButtonInCountryList("Netherlands")
                .WaitUntilDisconnected();
        }

        [Test]
        [Category("Smoke")]
        public void ConnectToCreatedProfile()
        {
            TestCaseId = 21551;
            DeleteProfiles();

            _homeWindow.NavigateToProfiles();
            _profilesWindow.PressCreateNewProfile()
                .CreateProfile(TestConstants.ProfileName)
                .ConnectToProfile(TestConstants.ProfileName);
            _homeWindow.WaitUntilConnected();
        }

        [Test]
        public void LogoutWhileConnectedToVpn()
        {
            TestCaseId = 212;

            _homeWindow.PressQuickConnectButton()
                .WaitUntilConnected()
                .Logout();
            _homeWindow.ContinueLogout();
            _loginResult.CheckIfLoginWindowIsDisplayed();
        }

        [Test]
        public void CancelLogoutWhileConnectedToVpn()
        {
            TestCaseId = 21549;

            _homeWindow.PressQuickConnectButton()
                .WaitUntilConnected()
                .Logout();
            _homeWindow.CancelLogout();
            _homeResult.CheckIfLoggedIn();
        }

        [Test]
        public void CheckIfKillSwitchIsNotActiveOnLogout()
        {
            TestCaseId = 215;

            _homeWindow.EnableKillSwitch()
                .PressQuickConnectButton()
                .WaitUntilConnected()
                .Logout();
            _homeWindow.ContinueLogout();
            _loginResult.CheckIfLoginWindowIsDisplayed()
                .CheckIfKillSwitchIsNotActive();
            _homeResult.CheckIfDnsIsResolved(GOOGLE_URL);
        }

        [Test]
        public void CheckIfConnectionIsRestoredToSameServerAfterAppKill()
        {
            TestCaseId = 217;

            _homeWindow.NavigateToSettings()
                .DisableStartToTray()
                .ClickOnConnectOnBoot()
                .CloseSettings();
            _homeWindow.PressQuickConnectButton()
                .WaitUntilConnected();
            _homeResult.KillClientAndCheckIfConnectionIsKept();
        }

        [Test]
        [Category("Smoke")]
        public void CheckIfAutoConnectConnectsAutomatically()
        {
            TestCaseId = 204;

            _homeWindow.NavigateToSettings();
            _settingsWindow.DisableStartToTray()
                .CloseSettings()
                .ExitTheApp();

            //Delay to allow app to properly exit
            Thread.Sleep(2000);
            LaunchApp();

            _homeWindow.WaitUntilConnected();

            ReportTestResults();
            TestCaseId = 205;

            _homeWindow.PressQuickConnectButton()
                .NavigateToSettings();
            _settingsWindow.ClickOnConnectOnBoot()
                .CloseSettings()
                .ExitTheApp();

            //Delay to allow app to properly exit
            Thread.Sleep(2000);
            LaunchApp();

            _homeWindow.WaitUntilDisconnected();
        }

        [Test]
        public void ConnectAndDisconnectViaMap()
        {
            TestCaseId = 219;

            _homeWindow.PerformConnectionViaMap(TestConstants.MapCountry)
                .WaitUntilConnected();

            ReportTestResults();
            TestCaseId = 220;

            _homeWindow.PerformConnectionViaMap(TestConstants.MapCountry)
                .WaitUntilDisconnected();
        }

        [Test]
        [Category("Smoke")]
        public void CheckCustomDnsManipulation()
        {
            TestCaseId = 4578;

            _homeWindow.NavigateToSettings();
            _settingsWindow.NavigateToConnectionTab()
                .ClickOnCustomDnsCheckBox()
                .PressContinueToDisableNetshield()
                .CloseSettings();
            _homeResult.CheckIfNetshieldIsDisabled();

            ReportTestResults();
            TestCaseId = 4579;

            _homeWindow.NavigateToSettings();
            _settingsWindow.NavigateToConnectionTab()
                .EnterCustomDnsAddress(DNS_ADDRESS)
                .CloseSettings();
            _homeWindow.PressQuickConnectButton()
                .WaitUntilConnected();
            _settingsResult.CheckIfDnsAddressMatches(DNS_ADDRESS);

            ReportTestResults();
            TestCaseId = 4581;

            _homeWindow.NavigateToSettings();
            _settingsWindow.NavigateToConnectionTab()
                .RemoveCustomDns()
                .PressReconnect()
                .WaitUntilConnected();
            _settingsResult.CheckIfDnsAddressDoesNotMatch(DNS_ADDRESS);
        }

        [Test]
        [Category("Smoke")]
        public void CancelConnectionWhileConnecting()
        {
            TestCaseId = 227;

            _homeWindow.PressQuickConnectButton()
                .CancelConnection()
                .WaitUntilDisconnected();
        }

        [Test]
        [Category("Smoke")]
        public void AppExitWithKillSwitchEnabled()
        {
            TestCaseId = 216;

            _homeWindow.PressQuickConnectButton()
                .WaitUntilConnected()
                .EnableKillSwitch()
                .ExitTheApp()
                .ConfirmExit();
            _homeResult.CheckIfDnsIsResolved(GOOGLE_URL);
        }

        [Test]
        public void ConnectUsingOpenVpnUdp()
        {
            TestCaseId = 153137;

            _homeWindow.NavigateToSettings()
                .NavigateToConnectionTab()
                .SelectProtocolOpenVpnUdp()
                .CloseSettings();
            _homeWindow.PressQuickConnectButton()
                .WaitUntilConnected();
        }

        [Test]
        public void ConnectUsingOpenVpnTcp()
        {
            TestCaseId = 153139;

            _homeWindow.NavigateToSettings()
                .NavigateToConnectionTab()
                .SelectProtocolOpenVpnTcp()
                .CloseSettings();
            _homeWindow.PressQuickConnectButton()
                .WaitUntilConnected();
        }

        [SetUp]
        public void TestInitialize()
        {
            DeleteUserConfig();
            LaunchApp();
            _loginWindow.SignIn(TestUserData.GetPlusUser());
        }

        [TearDown]
        public void TestCleanup()
        {
            Cleanup();
        }
    }
}
