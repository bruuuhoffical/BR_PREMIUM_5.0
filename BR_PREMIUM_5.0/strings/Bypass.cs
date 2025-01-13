using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BR_PREMIUM_5._0;
using Bruuuh;

namespace BR_PREMIUM.strings
{
    public class Bypass
    {
        private HOME _mainForm;
        private List<long> SecureBypass = new List<long>();
        Evelyn bruuuh = new Evelyn();
        public Bypass(HOME mainForm)
        {
            _mainForm = mainForm;

        }
        private List<MessageBoxControl> _messageBoxes;
        private static int activeMessageBoxes = 0;
        private static int lastMessageBoxY = 0;
        private MessageBoxControl _messageBox;




        public async void EnableBypass()
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
                ShowMessageBox("Bypassing Main....", "failed", "");
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
                    ShowMessageBox("All Bypass Success", "failed", "");
                }
                else
                {
                    ShowMessageBox("Error", "failed", "");
                }
            }
        }
        public async void DisableBypass()
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
                ShowMessageBox("Hold on....", "failed", "");
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
                    ShowMessageBox("Restored", "failed", "");
                }
                else
                {
                    ShowMessageBox("Bypass Error", "failed", "");
                }
            }
        }

        #region SecureBypass

        public async Task ScanSecureBypass()
        {
            string searchA = "";
            string searchB = "";
            string searchC = "";
            string searchD = "";
            string searchE = "";
            string searchF = "";

            List<string> searchPatterns = new List<string> { searchA, searchB, searchC, searchD, searchE, searchF };

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            ShowMessageBox("Please Wait...", "failed", "");
            List<long> allFoundAddresses = new List<long>();

            foreach (var searchPattern in searchPatterns)
            {
                IEnumerable<long> foundAddresses = await bruuuh.AoBScan(searchPattern, writable: true);

                allFoundAddresses.AddRange(foundAddresses);
            }

            if (allFoundAddresses.Count > 0)
            {
                SecureBypass = allFoundAddresses.Distinct().ToList();
                ShowMessageBox("Step 1 Done", "failed", "");
                EnableSecureBypass();
            }
            else
            {
                ShowMessageBox("Step 1 Error", "failed", "");
                return;
            }
        }


        public void EnableSecureBypass()
        {
            string replaceA = "";
            string replaceB = "";
            string replaceC = "";
            string replaceD = "";
            string replaceE = "";
            string replaceF = "";

            List<string> replacements = new List<string> { replaceA, replaceB, replaceC, replaceD, replaceE, replaceF };

            if (SecureBypass.Count > 0)
            {
                bool success = false;
                ShowMessageBox("Step 2, Wait...", "failed", "");

                foreach (var address in SecureBypass)
                {
                    foreach (var replace in replacements)
                    {
                        bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                        if (writeResult)
                        {
                            success = true;
                        }
                    }
                }

                if (success)
                {
                    ShowMessageBox("Step 2 Done", "failed", "");
                    EnableBypass();
                }
                else
                {

                }
            }
            else
            {

            }
        }
        public void ResetSecureBypass()
        {
            string replaceA = "";
            string replaceB = "";
            string replaceC = "";
            string replaceD = "";
            string replaceE = "";
            string replaceF = "";

            List<string> replacements = new List<string> { replaceA, replaceB, replaceC, replaceD, replaceE, replaceF };

            if (SecureBypass.Count > 0)
            {
                bool success = false;

                foreach (var address in SecureBypass)
                {
                    foreach (var replace in replacements)
                    {
                        bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                        if (writeResult)
                        {
                            success = true;
                        }
                    }
                }

                if (success)
                {

                }
                else
                {

                }
            }
            else
            {

            }
        }
        #region .

        #endregion
        private void ShowMessageBox(string message, string status, string imageKey)
        {
            _mainForm.Invoke(new Action(() =>
            {
                _mainForm.ShowMessageBox(message, status, imageKey);
            }));
        }

        #endregion
    }
}
