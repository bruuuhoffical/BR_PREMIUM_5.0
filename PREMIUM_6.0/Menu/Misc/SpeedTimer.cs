using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bruuuh;
using Memory;
using PREMIUM_6._0.Views;

namespace PREMIUM_6._0.Menu.Misc
{
    public class SpeedTimer
    {
        private Home _mainForm;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        public SpeedTimer(Home mainForm)
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



        string search = "01 00 00 00 02 2B 69 3D";
        string replace = "01 00 00 00 02 2B 07 3D";
        private List<long> SpeedAddress = new List<long>();
        private List<long> Speed2Address = new List<long>();
        bool k = false;

        public void EnableSpeedTimer()
        {
            if (Bool.OthersMem == 0)
            {
                DetermineInjection1();
            }
            else if (Bool.OthersMem > 1)
            {
                DetermineInjection2();
            }
        }
        private void DetermineInjection1()
        {
            if (Bool.isSpeedLoaded == false)
            {
                LoadSpeedTimer1();
                return;
            }
            else if (Bool.isSpeedLoaded == true)
            {
                SpeedTimer1();
            }
        }
        private void DetermineInjection2()
        {
            if (Bool.isSpeedLoaded == false)
            {
                LoadSpeedTimer2();
                return;
            }
            else if (Bool.isSpeedLoaded == true)
            {
                SpeedTimer2();
            }
        }



        private async Task LoadSpeedTimer1()
        {
            Notify("Loading Speed Timer [0]", "");

            string[] processName = { "HD-Player" };
            bool success = memoryfast.SetProcess(processName);

            if (!success)
            {
                Notify("", "2000");
                Bool.isSpeedTimer1Enabled = false;
                return;
            }

            IEnumerable<long> result = await memoryfast.AoBScan(search);

            SpeedAddress = result.ToList();

            if (SpeedAddress.Count > 0)
            {
                Notify("Speed Timer Loaded [0]", "400");
                Bool.isSpeedLoaded = false;
            }
            else
            {
                Notify("No Address Found [0]", "2000");
                Bool.isSpeedLoaded = false;
            }
        }

        public void SpeedTimer1()
        {
            if (Bool.isSpeedTimer1Enabled == false)
            {
                OnSpeedTimer1();
            }
            else if (Bool.isSpeedTimer1Enabled == true)
            {
                OffSpeedTimer1();
            }
        }
        public void OnSpeedTimer1()
        {
            if (SpeedAddress.Count == 0)
            {
                Notify("Speed Timer Isnt Loaded", "2000");
                Bool.isSpeedTimer1Enabled = false;
                return;
            }
            int delay = Bool.SpeedDelay * 1000;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = delay;
            timer.Tick += (s, args) =>
            {
                timer.Stop();
                timer.Dispose();
                foreach (long address in SpeedAddress)
                {
                    memoryfast.AobReplace(address, replace);
                }

                Notify("Enabled Camera Hack", "400");
                Bool.isSpeedTimer1Enabled = true;
            };
            timer.Start();
        }

        public void OffSpeedTimer1()
        {
            if (SpeedAddress.Count == 0)
            {
                Notify("Speed Timer Isnt Loaded", "2000");
                Bool.isSpeedTimer1Enabled = true;
                return;
            }

            foreach (long address in SpeedAddress)
            {
                memoryfast.AobReplace(address, search);
            }

            Notify("Disabled Camera Hack", "400");
            Bool.isSpeedTimer1Enabled = false;
        }



        private async Task LoadSpeedTimer2()
        {
            string search = this.search;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            Notify("Loading Speed Timer [1]", "");

            IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

            if (foundAddresses.Count() > 0)
            {
                Speed2Address = foundAddresses.ToList();
                Notify("Loaded Speed Timer [1]", "400");
            }
            else
            {
                Notify("Failed to Load Speed Timer [1]", "2000");
            }
        }
        public void SpeedTimer2()
        {
            if (Bool.isSpeedTimer2Enabled == false)
            {
                OnSpeedTimer2();
            }
            else if (Bool.isSpeedTimer2Enabled == true)
            {
                OffSpeedTimer2();
            }
        }
        private void OnSpeedTimer2()
        {
            string replace = this.replace;
            string search = this.search;
            if (Speed2Address.Count > 0)
            {
                bool success = false;

                foreach (var address in Speed2Address)
                {
                    int delay = Bool.SpeedDelay * 1000;

                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    timer.Interval = delay;
                    timer.Tick += (s, args) =>
                    {
                        timer.Stop();
                        timer.Dispose();
                        bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                        if (writeResult)
                        {
                            success = true;
                        }
                    };
                    timer.Start();
                }

                if (success)
                {
                    Notify("Enabled Speed Timer [1]", "400");
                    Bool.isSpeedTimer2Enabled = true;
                }
                else
                {
                    Notify("Speed Timer Failed [1]", "");
                    Bool.isSpeedTimer2Enabled = false;
                }
            }
            else
            {
                Notify("Speed Timer Isnt Loaded [1]", "800");
            }

        }
        private void OffSpeedTimer2()
        {
            string replace = search;
            if (Speed2Address.Count > 0)
            {
                bool success = false;

                foreach (var address in Speed2Address)
                {
                    bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                    if (writeResult)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    Notify("Disabled Speed Timer [1]", "400");
                    Bool.isSpeedTimer2Enabled = true;
                }
                else
                {
                    Notify("Speed Timer Failed [1]", "");
                }
            }
            else
            {
                Notify("Speed Timer Isnt Loaded [1]", "800");
            }

        }
    }
}
