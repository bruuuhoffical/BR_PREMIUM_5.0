using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bruuuh;
using Memory;
using PREMIUM_6._0.Views;

namespace PREMIUM_6._0.Menu.Aimbot
{
    public class ScopeTracking
    {
        private Home _mainForm;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        public ScopeTracking(Home mainForm)
        {
            _mainForm = mainForm;

        }
        private void Notify(string message, string message1)
        {
            _mainForm.Invoke(new Action(() =>
            {
                _mainForm.Notify(message, message1);
            }));
        }



        string search = "A0 42 00 00 C0 3F 33 33 13 40 00 00 F0 3F 00 00 80 3F";
        string replace = "A0 42 00 00 C0 3F 33 33 13 40 00 00 F0 3F 00 00 29 5C";
        bool k = false;
        public void EnableScopeTracking()
        {
            if (Bool.OthersMem == 0)
            {
                ScopeTracking1();
            }
            else if (Bool.OthersMem > 1)
            {
                ScopeTrack2();
            }
        }
        private async void ScopeTracking1()
        {
            Notify("Enabling Scope Tracking", "");
            string[] pocessname = { "HD-Player" };
            bool success = memoryfast.SetProcess(pocessname);

            if (!success)
            {
                return;
            }

            IEnumerable<long> result = await memoryfast.AoBScan(search);

            foreach (long id in result)
            {
                memoryfast.AobReplace(id, replace);
            }
            Notify("Enabled Scope Tracking", "");
        }
        public async void ScopeTrack2()
        {

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "");

            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                Notify("Enabling Scope Tracking", "");
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
                    Notify("Enabled Scope Tracking", "");

                }
                else
                {
                    Notify("Scope Tracking Failed", "");
                }
            }
        }
    }
}
