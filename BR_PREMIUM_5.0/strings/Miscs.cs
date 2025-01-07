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
        public Miscs(HOME mainForm)
        {
            _mainForm = mainForm;

        }

        #region NoRecoil
        public async void EnableNoRecoil()
        {
            string search = "03 0A 9F ED 10 0A 01 EE 00 0A 81 EE 10 0A 10 EE 10 8C BD E8 00 00 7A 44 F0";
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


        #region CameraUp

        public async Task ScanCameraUp()
        {
            string search = "10 0A 18 EE 04 8B BD EC F0 88 BD E8 00 00 55 E3 01 00 00 1A 00 00 A0 E3 58 86 09";

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

        public void EnableCameraUp()
        {
            string replace = "82 0E 43 E3 04 8B BD";

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
                        ShowMessageBox("CMU Location Enabled", "", "");
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {
                        ShowMessageBox("CMU Error", "failed", "");
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
        public void ResetCameraUp()
        {
            string originalPattern = "10 0A 18 EE 04 8B BD EC F0 88 BD E8 00 00 55 E3 01 00 00 1A 00 00 A0 E3 58 86 09";

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

                        ShowMessageBox("CMU Location Disabled", "", "");
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {

                    }
                    else
                    {

                        ShowMessageBox("CMU Error 101", "failed", "");
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
