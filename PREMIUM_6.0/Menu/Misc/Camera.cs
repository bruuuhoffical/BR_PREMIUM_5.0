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
    public class Camera
    {
        private Home _mainForm;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        public Camera(Home mainForm)
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



        string Leftsearch = "00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 80 7F 00 00 80 7F 00 00 80 7F 00 00 80 FF";
        string Leftreplace = "00 00 00 00 00 80 40 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 80 7F 00 00 80 7F 00 00 80 7F 00 00 80 FF";
        string RightSearch = "00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 80 7F 00 00 80 7F 00 00 80 7F 00 00 80 FF";
        string RightReplace = "00 00 00 00 22 8E C3 40 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 80 7F 00 00 80 7F 00 00 80 7F 00 00 80 FF";
        private List<long> CameraLeft1Address = new List<long>();
        private List<long> CameraLeft2Address = new List<long>();
        private List<long> CameraRight1Address = new List<long>();
        private List<long> CameraRight2Address = new List<long>();
        bool k = false;

        public void EnableCameraHack()
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
            if (Bool.CameraPostion == 0)
            {
                LoadCameraLeft1();
            }
            else if (Bool.CameraPostion == 1)
            {
                CameraLeft1();
            }
            else if (Bool.CameraPostion == 2)
            {

            }
        }
        private void DetermineInjection2()
        {
            if (Bool.CameraPostion == 0)
            {
                LoadCameraLeft2();
            }
            else if (Bool.CameraPostion == 1)
            {
                CameraLeft2();
            }
            else if (Bool.CameraPostion == 2)
            {

            }
        }



        private async Task LoadCameraLeft1()
        {
            Notify("Loading Camera Left [0]", "");

            string[] processName = { "HD-Player" };
            bool success = memoryfast.SetProcess(processName);

            if (!success)
            {
                Notify("", "2000");
                Bool.isCameraLeft1Enabled = false;
                return;
            }

            IEnumerable<long> result = await memoryfast.AoBScan(Leftsearch);

            CameraLeft1Address = result.ToList();

            if (CameraLeft1Address.Count > 0)
            {
                Notify("Camera Left Loaded [0]", "400");
                Bool.isCameraLeft1Enabled = false;
            }
            else
            {
                Notify("No Address Found [0]", "2000");
                Bool.isCameraLeft1Enabled = false;
            }
        }

        public void CameraLeft1()
        {
            if (Bool.isCameraLeft1Enabled == false)
            {
                OnCameraLeft1();
            }
            else if (Bool.isCameraLeft1Enabled == true)
            {
                OffCameraLeft1();
            }
        }
        public void OnCameraLeft1()
        {
            if (CameraLeft1Address.Count == 0)
            {
                Notify("Camera Left Isnt Loaded", "2000");
                Bool.isCameraLeft1Enabled = false;
                return;
            }

            foreach (long address in CameraLeft1Address)
            {
                memoryfast.AobReplace(address, Leftreplace);
            }

            Notify("Enabled Camera Hack", "400");
            Bool.isCameraLeft1Enabled = true;
        }
        
        public void OffCameraLeft1()
        {
            if (CameraLeft1Address.Count == 0)
            {
                Notify("Camera Left Isnt Loaded", "2000");
                Bool.isCameraLeft1Enabled = true;
                return;
            }

            foreach (long address in CameraLeft1Address)
            {
                memoryfast.AobReplace(address, Leftsearch);
            }

            Notify("Disabled Camera Hack", "400");
            Bool.isCameraLeft1Enabled = false;
        }



        private async Task LoadCameraLeft2()
        {
            string search = Leftsearch;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            Notify("Loading Camera Left [1]", "");

            IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

            if (foundAddresses.Count() > 0)
            {
                CameraLeft2Address = foundAddresses.ToList();
                Notify("Loaded Camera Left [1]", "400");
            }
            else
            {
                Notify("Failed to Load Camera Left [1]", "2000");
            }
        }
        public void CameraLeft2()
        {
            if (Bool.isCameraLeft2Enabled == false)
            {
                OnCameraLeft2();
            }
            else if (Bool.isCameraLeft2Enabled == true)
            {
                OffCameraLeft2();
            }
        }
        private void OnCameraLeft2()
        {
            string replace = Leftreplace;
            string search = Leftsearch;
            if (CameraLeft2Address.Count > 0)
            {
                bool success = false;

                foreach (var address in CameraLeft2Address)
                {
                    int delay = Bool.CameraDelay * 1000;

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
                    Notify("Enabled Camera Left [1]", "400");
                    Bool.isCameraLeft2Enabled = true;
                }
                else
                {
                    Notify("Camera Left Failed [1]", "");
                    Bool.isCameraLeft2Enabled = false;
                }
            }
            else
            {
                Notify("Camera left Isnt Loaded [1]", "800");
            }

        }
        private void OffCameraLeft2()
        {
            string replace = Leftsearch;
            if (CameraLeft2Address.Count > 0)
            {
                bool success = false;

                foreach (var address in CameraLeft2Address)
                {
                    int delay = Bool.CameraDelay * 1000;

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
                    Notify("Disabled Camera Left [1]", "400");
                    Bool.isCameraLeft2Enabled = true;
                }
                else
                {
                    Notify("Camera Left Failed [1]", "");
                }
            }
            else
            {
                Notify("Camera left Isnt Loaded [1]", "800");
            }

        }









    }
}

