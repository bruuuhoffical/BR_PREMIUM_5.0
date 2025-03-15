using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bruuuh;
using BruuuhPie;
using Memory;
using PREMIUM_6._0.Views;

namespace PREMIUM_6._0.Menu.Aimbot
{
    public class AimFov
    {
        private Home _mainForm;
        public AimFov(Home mainForm)
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
        string search = "19 3E CD CC 4C 3E A4 70 FD 3E AE 47 01 3F A4 70 FD 3E AE 47 01 3F AE 47 E1 3E 29 5C 0F 3F";
        string replace = "19 3E CD CC 4C 3E A4 70 FD 3E AE 47 E9 FF A4 70 FD 3E AE 47 01 3F AE 47 E1 3E 29 5C 0F 3F";
        bool k = false;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        PieMem piemem = new PieMem();

        public void EnableAimfov()
        {
            if (Bool.OthersMem == 0)
            {
                Aimfov1();
            }
            else if (Bool.OthersMem > 1)
            {
                Aimfov2();
            }
        }
        private async void Aimfov1()
        {
            Notify("Enabling AimFov", "");
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
            Notify("Enabled AimFov", "");
        }
        public async void Aimfov2()
        {

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "");

            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                Notify("Enabling AimFov", "");
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
                    Notify("Enabled AimFov", "");

                }
                else
                {
                    Notify("AimFov Failed", "");
                }
            }
        }
    }
}
