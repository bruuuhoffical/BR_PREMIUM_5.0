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
    public class Recoil
    {
        private Home _mainForm;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        public Recoil(Home mainForm)
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
        


        string search = "10 0A 01 EE 00 0A 81 EE 10 0A 10 EE 10 80 BD E8 00 00 7A 44 30 48 2D E9 02 8B 2D ED 08 D0 4D E2";
        string replace = "10 0A 81 EE 00 0A 81 EE 10 0A 10 EE 10 80 BD E8 00 00 7A 00 30 48 2D E9 02 8B 2D ED 08 D0 4D E2";
        bool k = false;
        public void EnableNoRecoil()
        {
            if (Bool.OthersMem == 0)
            {
                NoRecoil1();
            }
            else if (Bool.OthersMem > 1)
            {
                NoRecoil2();
            }
        }
        private async void NoRecoil1()
        {
            Notify("Enabling No Recoil", "");
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
            Notify("Enabled No Recoil", "");
        }
        public async void NoRecoil2()
        {

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "");

            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                Notify("Enabling No Recoil", "");
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
                    Notify("Enabled No Recoil", "");

                }
                else
                {
                    Notify("No Recoil Failed", "");
                }
            }
        }

    }
}
