using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bruuuh;
using RedMem;
using System.Diagnostics;

namespace BR_PREMIUM_5._0.strings
{
    public class Miscs
    {
        private List<MessageBoxControl> _messageBoxes;
        private static int activeMessageBoxes = 0;
        private static int lastMessageBoxY = 0;
        private MessageBoxControl _messageBox;
        private ParticleSystem particleSystem;
        private string RED;

        public static MemRed RedLib = new MemRed();
        public static String PID;
        Evelyn bruuuh = new Evelyn();
        private int _processId;

        private HOME _mainForm;
        private List<long> CameraUpAddress = new List<long>();
        private List<long> SpeedAddress = new List<long>();
        private List<long> GlitchAddress = new List<long>();
        private List<long> WallAddress = new List<long>();
        public Miscs(HOME mainForm)
        {
            _mainForm = mainForm;

        }
        public bool Speed = false;
        public bool Wall = false;
        public bool Glitch = false;

        #region NoRecoil
        public async void EnableNoRecoil()
        {
            string search = "03 0A 9F ED 10 0A 01 EE 00 0A 81 EE 10 0A 10 EE 10 8C BD E8 00 00 7A 44 F0";
            string replace = "03 0A 9F ED 10 0A 01 EE 00 0A 81 EE 10 0A 10 EE 10 8C BD E8 00 00 00 00 F0";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Enabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("No Recoil Enabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        public async void DisableNoRecoil()
        {
            string search = "03 0A 9F ED 10 0A 01 EE 00 0A 81 EE 10 0A 10 EE 10 8C BD E8 00 00 00 00 F0";
            string replace = "03 0A 9F ED 10 0A 01 EE 00 0A 81 EE 10 0A 10 EE 10 8C BD E8 00 00 7A 44 F0";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Disabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("No Recoil Disabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        #endregion
        
        
        #region FixFemale
        public async void EnableFixFemale()
        {
            string search = "45 23 05 06 46 23 05 06 47 23 05 06 48 23 05 06 87 65 14 06 88 65 14 06 49 23 05 06 89 65 14 06 4A 23 05 06 8A 65 14 06 8B 65 14 06 4B 23 05 06 8C 65 14 06 4C 23 05 06 8D 65 14 06 4D 23 05 06 8E 65 14 06 4E 23 05 06 8F 65 14 06 50 23 05 06 90 65 14 06 4F 23 05 06 51 23 05 06 91 65 14 06 52 23 05 06 92 65 14 06 53 23 05 06 93 65 14 06 94 65 14 06 95 65 14 06 96 65 14 06 54 23 05 06 97 65 14 06 98 65 14 06 55 23 05 06 99 65 14 06 9A 65 14 06 9B 65 14 06 9C 65 14 06 56 23 05 06 9D 65 14 06 57 23 05 06";
            string replace = "85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 8E 65 14 06 85 65 14 06 8F 65 14 06 85 65 14 06 90 65 14 06 85 65 14 06 85 65 14 06 91 65 14 06 85 65 14 06 92 65 14 06 85 65 14 06 93 65 14 06 94 65 14 06 95 65 14 06 96 65 14 06 85 65 14 06 97 65 14 06 98 65 14 06 85 65 14 06 99 65 14 06 9A 65 14 06 9B 65 14 06 9C 65 14 06 85 65 14 06 9D 65 14 06 85 65 14 06";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Enabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("Fix Female Enabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        public async void DisableFixFemale()
        {
            string search = "85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 8E 65 14 06 85 65 14 06 8F 65 14 06 85 65 14 06 90 65 14 06 85 65 14 06 85 65 14 06 91 65 14 06 85 65 14 06 92 65 14 06 85 65 14 06 93 65 14 06 94 65 14 06 95 65 14 06 96 65 14 06 85 65 14 06 97 65 14 06 98 65 14 06 85 65 14 06 99 65 14 06 9A 65 14 06 9B 65 14 06 9C 65 14 06 85 65 14 06 9D 65 14 06 85 65 14 06";
            string replace = "45 23 05 06 46 23 05 06 47 23 05 06 48 23 05 06 87 65 14 06 88 65 14 06 49 23 05 06 89 65 14 06 4A 23 05 06 8A 65 14 06 8B 65 14 06 4B 23 05 06 8C 65 14 06 4C 23 05 06 8D 65 14 06 4D 23 05 06 8E 65 14 06 4E 23 05 06 8F 65 14 06 50 23 05 06 90 65 14 06 4F 23 05 06 51 23 05 06 91 65 14 06 52 23 05 06 92 65 14 06 53 23 05 06 93 65 14 06 94 65 14 06 95 65 14 06 96 65 14 06 54 23 05 06 97 65 14 06 98 65 14 06 55 23 05 06 99 65 14 06 9A 65 14 06 9B 65 14 06 9C 65 14 06 56 23 05 06 9D 65 14 06 57 23 05 06";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Disabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("Fix Female Disabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        #endregion
        
        
        #region FastReload
        public async void EnableFastReload()
        {
            string search = "6D 00 00 EB 00 0A B7 EE 10 0A 01 EE 00 0A 31 EE 10 5A 01 EE 00 0A 21 EE 10 0A 10 EE 30 88 BD E8 F0 48";
            string replace = "FF 02 44 E3";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Enabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("Fast Reload Enabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        public async void DisableFastReload()
        {
            string search = "FF 02 44 E3";
            string replace = "6D 00 00 EB 00 0A B7 EE 10 0A 01 EE 00 0A 31 EE 10 5A 01 EE 00 0A 21 EE 10 0A 10 EE 30 88 BD E8 F0 48";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Disabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("Fast Reload Disabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        #endregion
        
        
        #region BlackSky
        public async void EnableBlackSky()
        {
            string search = "A4 70 7D 3F 3A CD 13 3F 0A D7 23 3C BD 37 86 35";
            string replace = "A4 70 7D 3F 3A CD 13 3F 0A D7 23 3C 00 00 80 BF";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Enabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("Black Sky Enabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        public async void DisableBlackSky()
        {
            string search = "A4 70 7D 3F 3A CD 13 3F 0A D7 23 3C 00 00 80 BF";
            string replace = "A4 70 7D 3F 3A CD 13 3F 0A D7 23 3C BD 37 86 35";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Disabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("Black Sky Disabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        #endregion
        
        #region CameraUp
        public async void EnableCameraUp1()
        {
            string search = "";
            string replace = "";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Enabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("Camera Up Enabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        public async void DisableCameraUp()
        {
            string search = "";
            string replace = "";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Disabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("Camera Up Disabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        #endregion


        #region CameraRight

        public async Task ScanCameraRight()
        {
            string search = "9A 99 19 3F 00 00 80 3E 00 00 00 00";

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            ShowMessageBox("Scanning...", "activating", "");

            IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

            if (foundAddresses.Count() > 0)
            {
                CameraUpAddress = foundAddresses.ToList();
                ShowMessageBox("Scan Success", "", "");
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Scan Failed", "Memory pattern not found", "");
                }
            }
        }

        public void EnableCameraRight()
        {
            string replace = "9A 99 19 3F 00 00 80 3E 00 00 00 3C";

            if (CameraUpAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in CameraUpAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("CMR Location Enabled", "", "");
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("CMR Error", "failed", "");
                    }
                }
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Please Load First !", "failed", "");
                }
            }
        }
        public void ResetCameraRight()
        {
            string originalPattern = "9A 99 19 3F 00 00 80 3E 00 00 00 00";

            if (CameraUpAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in CameraUpAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", originalPattern);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("CML Disabled", "", "");
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("CML Error 101", "failed", "");
                    }
                }
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {

                    ShowMessageBox("Please Load First !", "failed", "");
                }
            }
        }
        #endregion
        
        
        //#region SpeedHack

        //public async Task ScanSpeedHack()
        //{
        //    string search = "01 00 00 00 02 2b 07 3d";

        //    if (Process.GetProcessesByName("HD-Player").Length == 0)
        //    {
        //        ShowMessageBox("Open Emulator", "failed", "");
        //        return;
        //    }

        //    bruuuh.OpenProcess("HD-Player");
        //    ShowMessageBox("Scanning...", "activating", "");

        //    IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

        //    if (foundAddresses.Count() > 0)
        //    {
        //        SpeedAddress = foundAddresses.ToList();
        //        ShowMessageBox("Scan Success", "", "");
        //    }
        //    else
        //    {
        //        if (_mainForm.IsCheckboxChecked())
        //        {

        //        }
        //        else
        //        {
        //            ShowMessageBox("Scan Failed", "Memory pattern not found", "");
        //        }
        //    }
        //}

        //public void EnableSpeedHck()
        //{
        //    string replace = "01 00 00 00 FF FF 84 3D";

        //    if (SpeedAddress.Count > 0)
        //    {
        //        bool success = false;

        //        foreach (var address in SpeedAddress)
        //        {
        //            bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
        //            if (writeResult)
        //            {
        //                success = true;
        //            }
        //        }

        //        if (success)
        //        {
        //            if (_mainForm.IsCheckboxChecked())
        //            {

        //            }
        //            else
        //            {
        //                ShowMessageBox("SPH Location Enabled", "", "");
        //            }
        //        }
        //        else
        //        {
        //            if (_mainForm.IsCheckboxChecked())
        //            {

        //            }
        //            else
        //            {
        //                ShowMessageBox("SPH Error", "failed", "");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (_mainForm.IsCheckboxChecked())
        //        {

        //        }
        //        else
        //        {
        //            ShowMessageBox("Please Load First !", "failed", "");
        //        }
        //    }
        //}
        //public void ResetSpeedHack()
        //{
        //    string originalPattern = "01 00 00 00 02 2b 07 3d";

        //    if (SpeedAddress.Count > 0)
        //    {
        //        bool success = false;

        //        foreach (var address in SpeedAddress)
        //        {
        //            bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", originalPattern);
        //            if (writeResult)
        //            {
        //                success = true;
        //            }
        //        }

        //        if (success)
        //        {
        //            if (_mainForm.IsCheckboxChecked())
        //            {

        //            }
        //            else
        //            {

        //                ShowMessageBox("SPH Location Disabled", "", "");
        //            }
        //        }
        //        else
        //        {
        //            if (_mainForm.IsCheckboxChecked())
        //            {

        //            }
        //            else
        //            {

        //                ShowMessageBox("SPH Error 101", "failed", "");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (_mainForm.IsCheckboxChecked())
        //        {

        //        }
        //        else
        //        {

        //            ShowMessageBox("Please Load First !", "failed", "");
        //        }
        //    }
        //}
        //#endregion
        
        
        
        
        
        #region GlitchFire

        public async Task ScanGlitchFire()
        {
            string search = "C0 3F 00 00 00 3F 00 00 80 3F 00 00";

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            ShowMessageBox("Scanning...", "activating", "");

            IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

            if (foundAddresses.Count() > 0)
            {
                GlitchAddress = foundAddresses.ToList();
                ShowMessageBox("Scan Success", "", "");
                Glitch = false;
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Scan Failed", "Memory pattern not found", "");
                }
            }
        }

        public void EnableGlitchFire()
        {
            string replace = "00 00";

            if (GlitchAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in GlitchAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("GLT Location Enabled", "", "");
                        Glitch = true;
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("GLT Error", "failed", "");
                        Glitch = false;
                    }
                }
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Please Load First !", "failed", "");
                }
            }
        }
        public void ResetGlitchFire()
        {
            string originalPattern = "C0 3F 00 00 00 3F 00 00 80 3F 00 00";

            if (GlitchAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in GlitchAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", originalPattern);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("GLT Location Disabled", "", "");
                        Glitch = false;
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("GLT Error 101", "failed", "");
                        Glitch = true;
                    }
                }
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {

                    ShowMessageBox("Please Load First !", "failed", "");
                }
            }
        }
        #endregion
        
        
        #region SpeedHack

        public async Task ScanSpeed()
        {
            string search = "3F AE 47 81 3F 00 1A B7 EE DC 3A 9F ED 300x3F AE 47 81 3F 00 1A B7 EE DC 3A 9F ED 30";

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            ShowMessageBox("Scanning...", "activating", "");

            IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

            if (foundAddresses.Count() > 0)
            {
                SpeedAddress = foundAddresses.ToList();
                ShowMessageBox("Scan Success", "", "");
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Scan Failed", "Memory pattern not found", "");
                    Speed = false;
                }
            }
        }

        public void EnablSpeed()
        {
            string replace = "BF";

            if (SpeedAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in SpeedAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("SP Location Enabled", "", "");
                        Speed = true;
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("SP Error", "failed", "");
                        Speed = false;
                    }
                }
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Please Load First !", "failed", "");
                }
            }
        }
        public void ResetSpeed()
        {
            string originalPattern = "3F AE 47 81 3F 00 1A B7 EE DC 3A 9F ED 300x3F AE 47 81 3F 00 1A B7 EE DC 3A 9F ED 30";

            if (SpeedAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in SpeedAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", originalPattern);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("SP Location Disabled", "", "");
                        Speed = false;
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("SP Error 101", "failed", "");
                        Speed = true;
                    }
                }
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {

                    ShowMessageBox("Please Load First !", "failed", "");
                }
            }
        }
        #endregion
        
        
        #region WallHack

        public async Task ScanWall()
        {
            string search = "01 00 00 00 02 2B 07 3D";

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            ShowMessageBox("Scanning...", "activating", "");

            IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

            if (foundAddresses.Count() > 0)
            {
                WallAddress = foundAddresses.ToList();
                ShowMessageBox("Scan Success", "", "");
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Scan Failed", "Memory pattern not found", "");
                    Wall = false;
                }
            }
        }

        public void EnablWall()
        {
            string replace = "01 00 00 00 02 2B 70 3D";

            if (WallAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in WallAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("WH Location Enabled", "", "");
                        Wall = true;
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("WH Error", "failed", "");
                        Wall = false;
                    }
                }
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Please Load First !", "failed", "");
                }
            }
        }
        public void ResetWall()
        {
            string originalPattern = "01 00 00 00 02 2B 07 3D";

            if (WallAddress.Count > 0)
            {
                bool success = false;

                foreach (var address in WallAddress)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", originalPattern);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("WH Location Disabled", "", "");
                        Wall = false;
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("WH Error 101", "failed", "");
                        Wall = true;
                    }
                }
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {

                    ShowMessageBox("Please Load First !", "failed", "");
                }
            }
        }
        #endregion


        private void ShowMessageBox(string message, string status, string imageKey)
        {
            _mainForm.Invoke(new Action(() =>
            {
                _mainForm.ShowMessageBox(message, status, imageKey);
            }));
        }
    }
}
