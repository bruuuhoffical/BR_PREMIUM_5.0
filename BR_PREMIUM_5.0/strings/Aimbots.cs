using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AIMBOTBYTANZIM;
using Bruuuh;
using Red;
using RedMem;
using static Guna.UI2.WinForms.Suite.Descriptions;

namespace BR_PREMIUM_5._0.strings
{
    public class Aimbots
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

        private HOME _mainForm;
        public List<long> foundAddresses { get; private set; } = new List<long>();
        private int _processId;
        private List<long> AimbotAddress = new List<long>();
        private List<long> AimbotHeadv2Address = new List<long>();
        private List<long> AimbotDragAddress = new List<long>();
        private List<long> AimbotNeckAddress = new List<long>();
        private List<long> AimbotExtraAddress = new List<long>();
        private List<long> AimbotBody = new List<long>();
        private List<long> AimbotValue = new List<long>();
        private List<long> AimbotDValue = new List<long>();
        private static SCOPRION scorpion = new SCOPRION();


        private static BRUUUHAIM magi = new BRUUUHAIM();
        private List<long> scannedAddresses = new List<long>();
        private readonly string aobPattern = "00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 80 bf 00 00 00 00 00 00 80 bf 00 00 00 00 00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 80 bf 00 00 80 7f 00 00 80 7f 00 00 80 7f 00 00 80 ff";

        private readonly string replaceValueTrue = "00 00 00 00 00 00 D1 40 00 00 00 00 00 00 00 00 00 00 80 bf 00 00 00 00 00 00 80 bf 00 00 00 00 00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 80 bf 00 00 80 7f 00 00 80 7f 00 00 80 7f 00 00 80 ff";

        private readonly string replaceValueFalse = "00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 80 bf 00 00 00 00 00 00 80 bf 00 00 00 00 00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 80 bf 00 00 80 7f 00 00 80 7f 00 00 80 7f 00 00 80 ff";

        string AimbotScan = "A5 43 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 80 BF";
        string headoffset = "0x2A";
        string chestoffset = "0x26";
        private Dictionary<long, int> OrginalValues1 = new Dictionary<long, int>();
        private Dictionary<long, int> OrginalValues2 = new Dictionary<long, int>();
        private Dictionary<long, int> OrginalValues3 = new Dictionary<long, int>();
        private Dictionary<long, int> OrginalValues4 = new Dictionary<long, int>();
        public Aimbots(HOME mainForm)
        {
            _mainForm = mainForm;

        }



        public bool scanaimheadv1 = false;
        public bool onaimheadv1 = false;
        public bool scanaimheadv2 = false;
        public bool onaimheadv2 = false;
        public bool scanaimdrag = false;
        public bool onaimdrag = false;
        public bool scanaimneck = false;
        public bool onaimneck = false;
        public bool scanaimbody = false;
        public bool onaimbody = false;



        #region Aimbots










        #region AimbotHeadV1

        public void LoadAimbotNeck()
        {
            var processes = Process.GetProcessesByName("HD-Player");
            if (processes.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                //throw new InvalidOperationException("Emulator not running.");
            }
            _processId = processes[0].Id;
            RedLib.OpenProcess(_processId);
            ShowMessageBox("Loading", "sucess", "");
            var task = RedLib.AoBScan(
                0x0000000000010000,
                0x00007ffffffeffff,
                //65536L,
                //140737488289791L,
                "FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 A5 43 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF",
                true,
                true
            );

            task.Wait();
            var result = task.Result;

            if (result == null || !result.Any())
            {
                ShowMessageBox("Error ", "sucess", "");
                return;
            }   

            AimbotAddress = result.ToList();
            ShowMessageBox("Load Complete!", "sucess", "");
            scanaimheadv1 = true;
        }
        public void EnableAimbotNeck()
        {
            #region default
            //if (AimbotAddress == null || !AimbotAddress.Any())
            //{
            //    ShowMessageBox("Error", "Enable Failed", "Run the scan first.");
            //    return;
            //}
            #endregion
            if (scanaimheadv1 == false)
            {
                LoadAimbotNeck();
                ShowMessageBox("Aimbot Drag Isnt Loaded", "failed", "");
            }
            else
            {
                foreach (long address in AimbotAddress)
                {
                    byte[] numArray = RedLib.AhReadMeFucker((address + 156L).ToString("X"), 4);
                    RedLib.WriteMemory((address + 108L).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }
                ShowMessageBox("Aimbot Drag Enabled", "", "");
                onaimheadv1 = true;
            }
        }
        public void DisableAimbotNeck()
        {
            if (onaimheadv1 == false)
            {
                LoadAimbotNeck();
                ShowMessageBox("Aimbot Isnt Enabled", "failed", "");
            }
            else
            {

                foreach (long address in AimbotAddress)
                {
                    byte[] numArray = RedLib.AhReadMeFucker((address + 108L).ToString("X"), 4);
                    RedLib.WriteMemory((address + 156L).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }

                ShowMessageBox("Aimbot Enabled", "", "");
            }
            
        }

        #endregion
        
        
        
        
        
        #region AimbotHeadV2

        public void LoadAimbotHeadV2()
        {
            var processes = Process.GetProcessesByName("HD-Player");
            if (processes.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                //throw new InvalidOperationException("Emulator not running.");
            }
            _processId = processes[0].Id;
            RedLib.OpenProcess(_processId);
            ShowMessageBox("Loading", "sucess", "");
            var task = RedLib.AoBScan(
                //0x0000000000010000,
                //0x00007ffffffeffff,
                65536L,
                140737488289791L,
                "FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 A5 43 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF",
                true,
                true
            );

            task.Wait();
            var result = task.Result;

            if (result == null || !result.Any())
            {
                ShowMessageBox("Error ", "sucess", "");
                return;
            }

            AimbotAddress = result.ToList();
            ShowMessageBox("Load Complete!", "sucess", "");
            scanaimheadv1 = true;
        }
        public void EnableAimbotHeadV2()
        {
            #region default
            //if (AimbotAddress == null || !AimbotAddress.Any())
            //{
            //    ShowMessageBox("Error", "Enable Failed", "Run the scan first.");
            //    return;
            //}
            #endregion
            if (scanaimheadv1 == false)
            {
                LoadAimbotHeadV1();
                //ShowMessageBox("Aimbot Isnt Loaded", "failed", "");
            }
            else
            {
                foreach (long address in AimbotAddress)
                {
                    byte[] numArray = RedLib.AhReadMeFucker((address + 156L).ToString("X"), 4);
                    RedLib.WriteMemory((address + 108L).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }
                ShowMessageBox("Aimbot Enabled", "", "");
                onaimheadv1 = true;
            }
        }
        public void DisableAimbotHeadV2()
        {
            if (onaimheadv1 == false)
            {
                LoadAimbotHeadV1();
                ShowMessageBox("Aimbot Isnt Enabled", "failed", "");
            }
            else
            {

                foreach (long address in AimbotAddress)
                {
                    byte[] numArray = RedLib.AhReadMeFucker((address + 108L).ToString("X"), 4);
                    RedLib.WriteMemory((address + 156L).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }

                ShowMessageBox("Aimbot Enabled", "", "");
            }
            
        }

        #endregion
        
        
        
        
        #region AimbotDrag

        public void LoadAimbotDrag()
        {
            var processes = Process.GetProcessesByName("HD-Player");
            if (processes.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                //throw new InvalidOperationException("Emulator not running.");
            }
            _processId = processes[0].Id;
            RedLib.OpenProcess(_processId);
            ShowMessageBox("Loading", "sucess", "");
            var task = RedLib.AoBScan(
                0x0000000000010000,
                0x00007ffffffeffff,
                "FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 A5 43 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF ?? ?? ?? ?? 00 00 00 00 00 00 80 BF",
                true,
                true
            );

            task.Wait();
            var result = task.Result;

            if (result == null || !result.Any())
            {
                ShowMessageBox("Error ", "sucess", "");
                return;
            }

            AimbotAddress = result.ToList();
            ShowMessageBox("Load Complete!", "sucess", "");
            scanaimdrag = true;
        }
        public void EnableAimbotDrag()
        {
            #region default
            //if (AimbotAddress == null || !AimbotAddress.Any())
            //{
            //    ShowMessageBox("Error", "Enable Failed", "Run the scan first.");
            //    return;
            //}
            #endregion
            if (scanaimheadv1 == false)
            {
                //LoadAimbotHeadV1();
                //ShowMessageBox("Aimbot Isnt Loaded", "failed", "");
            }
            else
            {
                foreach (long address in AimbotAddress)
                {
                    byte[] numArray = RedLib.AhReadMeFucker((address + 112L).ToString("X"), 4);
                    RedLib.WriteMemory((address + 0x6C).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }
                ShowMessageBox("Aimbot Enabled", "", "");
                onaimheadv1 = true;
            }
        }
        public void DisableAimbotDrag()
        {
            if (onaimdrag == false)
            {
                //LoadAimbotHeadV1();
                ShowMessageBox("Aimbot Isnt Enabled", "failed", "");
            }
            else
            {

                foreach (long address in AimbotAddress)
                {
                    byte[] numArray = RedLib.AhReadMeFucker((address + 0x6C).ToString("X"), 4);
                    RedLib.WriteMemory((address + 112L).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }

                ShowMessageBox("Aimbot Enabled", "", "");
            }
            
        }

        #endregion
        
        
        
        #region AimbotNeck

        public void LoadAimbotHeadV1()
        {
            var processes = Process.GetProcessesByName("HD-Player");
            if (processes.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                //throw new InvalidOperationException("Emulator not running.");
            }
            _processId = processes[0].Id;
            RedLib.OpenProcess(_processId);
            ShowMessageBox("Loading", "sucess", "");
            var task = RedLib.AoBScan(
                0x0000000000010000,
                0x00007ffffffeffff,
                "FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 A5 43 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF",
                true,
                true
            );

            task.Wait();
            var result = task.Result;

            if (result == null || !result.Any())
            {
                ShowMessageBox("Error ", "sucess", "");
                return;
            }

            AimbotNeckAddress = result.ToList();
            ShowMessageBox("Load Complete!", "sucess", "");
            scanaimneck = true;
        }
        public void LoadAimbotExtra()
        {
            var processes = Process.GetProcessesByName("HD-Player");
            if (processes.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                //throw new InvalidOperationException("Emulator not running.");
            }
            _processId = processes[0].Id;
            RedLib.OpenProcess(_processId);
            ShowMessageBox("Loading", "sucess", "");
            var task = RedLib.AoBScan(
                0x0000000000010000,
                0x00007ffffffeffff,
                "FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 A5 43 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF ?? ?? ?? ?? 00 00 00 00 00 00 80 BF",
                true,
                true
            );

            task.Wait();
            var result = task.Result;

            if (result == null || !result.Any())
            {
                ShowMessageBox("Error ", "sucess", "");
                return;
            }

            AimbotExtraAddress = result.ToList();
            ShowMessageBox("Load Complete!", "sucess", "");
            scanaimneck = true;
        }
        public void EnableAimbotHeadV1()
        {
            #region default
            //if (AimbotAddress == null || !AimbotAddress.Any())
            //{
            //    ShowMessageBox("Error", "Enable Failed", "Run the scan first.");
            //    return;
            //}
            #endregion
            if (scanaimneck == false)
            {
                LoadAimbotNeck();
                ShowMessageBox("Aimbot Isnt Loaded", "failed", "");
            }
            else
            {
                foreach (long address in AimbotNeckAddress)
                {
                    byte[] numArray = RedLib.AhReadMeFucker((address + 0x9C).ToString("X"), 4);
                    byte[] numArray1 = RedLib.AhReadMeFucker((address + 0x70).ToString("X"), 4);
                    RedLib.WriteMemory((address + 0x6C).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                    RedLib.WriteMemory((address + 0x6C).ToString("X"), "int", BitConverter.ToInt32(numArray1, 0).ToString());
                }
                ShowMessageBox("Aimbot Enabled", "", "");
                onaimneck = true;
            }
        }
        public void EnableAimbotHeadExtra()
        {
            #region default
            //if (AimbotAddress == null || !AimbotAddress.Any())
            //{
            //    ShowMessageBox("Error", "Enable Failed", "Run the scan first.");
            //    return;
            //}
            #endregion
            if (scanaimneck == false)
            {
                LoadAimbotNeck();
                ShowMessageBox("Aimbot Isnt Loaded", "failed", "");
            }
            else
            {
                foreach (long address in AimbotExtraAddress)
                {
                    byte[] numArray = RedLib.AhReadMeFucker((address + 0xa0).ToString("X"), 4);
                    RedLib.WriteMemory((address + 0x6C).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }
                ShowMessageBox("Aimbot Enabled", "", "");
                onaimneck = true;
            }
        }
        public void DisableAimbotHeadV1()
        {
            if (onaimneck == false)
            {
                ShowMessageBox("Aimbot Isnt Enabled", "failed", "");
            }
            else
            {

                foreach (long address in AimbotNeckAddress)
                {
                    byte[] numArray = RedLib.AhReadMeFucker((address + 0x2C).ToString("X"), 4);
                    RedLib.WriteMemory((address + 0x60).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }

                ShowMessageBox("Aimbot Disabled", "", "");
            }
            
        }

        #endregion





        #region AimbotBody

        public async Task ScanAimbotbody()
        {
            string searchA = "dc 52 39 bd 27 c1 8b 3c c0 d0 f8 b9";
            string searchB = "63 71 b0 bd 90 98 74 bb 00 00 80 b3";
            string searchC = "7b f9 6c bd 58 34 09 bb b0 60 be ba";
            string searchD = "54 1b 87 bd 90 c6 d7 ba 80 54 99 b9";
            string searchE = "71 02 87 bd 90 fd d7 ba 40 18 98 39";
            string searchF = "cc f8 6c bd 40 d2 ce b9 58 64 be 3a";

            List<string> searchPatterns = new List<string> { searchA, searchB, searchC, searchD, searchE, searchF };

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            ShowMessageBox("Scanning...", "activating", "");

            List<long> allFoundAddresses = new List<long>();

            foreach (var searchPattern in searchPatterns)
            {
                IEnumerable<long> foundAddresses = await bruuuh.AoBScan(searchPattern, writable: true);

                allFoundAddresses.AddRange(foundAddresses);
            }

            if (allFoundAddresses.Count > 0)
            {
                AimbotBody = allFoundAddresses.Distinct().ToList();
                ShowMessageBox("Scan Success", "", "");
                scanaimbody = true;
            }
            else
            {
                if (_mainForm.IsCheckboxChecked())
                {

                }
                else
                {
                    ShowMessageBox("Scan Failed", "Memory pattern not found", "");
                    scanaimbody = false;
                }
            }
        }


        public void EnableAimbotBody()
        {
            string replaceA = "00 00 00 3e 0a d7 23 3d d2 a5 f9 bc";
            string replaceB = "cd dc 79 44 90 98 74 bb 00 00 80 b3";
            string replaceC = "cd dc 79 44 90 c6 d7 ba 80 54 99 b9";
            string replaceD = "cd dc 79 44 90 c6 d7 ba 80 54 99 b9";
            string replaceE = "cd dc 79 44 90 fd d7 ba 40 18 98 39";
            string replaceF = "cd dc 79 44 40 d2 ce b9 58 64 be 3a";

            List<string> replacements = new List<string> { replaceA, replaceB, replaceC, replaceD, replaceE, replaceF };

            if (AimbotBody.Count > 0)
            {
                bool success = false;

                foreach (var address in AimbotBody)
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
                    if (_mainForm.IsCheckboxChecked())
                    {
                        
                    }
                    else
                    {
                        ShowMessageBox("Aimbot Body Enabled", "", "");
                        onaimbody = true;
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {
                        
                    }
                    else
                    {
                        ShowMessageBox("AIB Error", "failed", "");
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
        public void ResetAimbotBody()
        {
            string replaceA = "dc 52 39 bd 27 c1 8b 3c c0 d0 f8 b9";
            string replaceB = "63 71 b0 bd 90 98 74 bb 00 00 80 b3";
            string replaceC = "7b f9 6c bd 58 34 09 bb b0 60 be ba";
            string replaceD = "54 1b 87 bd 90 c6 d7 ba 80 54 99 b9";
            string replaceE = "71 02 87 bd 90 fd d7 ba 40 18 98 39";
            string replaceF = "cc f8 6c bd 40 d2 ce b9 58 64 be 3a";

            List<string> replacements = new List<string> { replaceA, replaceB, replaceC, replaceD, replaceE, replaceF };

            if (AimbotBody.Count > 0)
            {
                bool success = false;

                foreach (var address in AimbotBody)
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
                    if (_mainForm.IsCheckboxChecked())
                    {
                        
                    }
                    else
                    {
                        ShowMessageBox("Aimbot Body Disabled", "", "");
                        onaimbody = false;
                    }
                }
                else
                {
                    if (_mainForm.IsCheckboxChecked())
                    {
                        
                    }
                    else
                    {
                        ShowMessageBox("AIB Error", "failed", "");
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

        #region AimFov
        public async void EnableAimFov()
        {
            string search = "00 00 20 42 00 00 40 40 00 00 70 42 00 00 00 00 00 00 C0 3F 0A D7 A3 3B 0A D7 A3 3B 8F C2 75 3D AE 47 E1 3D 9A 99 19 3E CD CC 4C 3E A4 70 FD 3E";
            string replace = "00 00 20 42 00 00 FF FF 00 00 70 42 00 00 00 00 00 00 C0 3F 0A D7 A3 3B 0A D7 A3 3B 8F C2 75 3D AE 47 E1 3D 9A 99 19 3E CD CC 4C 3E A4 70 FD 3E";
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
                    ShowMessageBox("Aim Fov Enabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        public async void DisableAimFov()
        {
            string search = "00 00 20 42 00 00 FF FF 00 00 70 42 00 00 00 00 00 00 C0 3F 0A D7 A3 3B 0A D7 A3 3B 8F C2 75 3D AE 47 E1 3D 9A 99 19 3E CD CC 4C 3E A4 70 FD 3E";
            string replace = "00 00 20 42 00 00 40 40 00 00 70 42 00 00 00 00 00 00 C0 3F 0A D7 A3 3B 0A D7 A3 3B 8F C2 75 3D AE 47 E1 3D 9A 99 19 3E CD CC 4C 3E A4 70 FD 3E";
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
                    ShowMessageBox("Aimfov Disabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        #endregion




        #region Aimbot+Anticheat
        public void AimbotOff()
        {
            foreach (var entry in OrginalValues1)
            {
                magi.WriteMemory(entry.Key.ToString("X"), "int", entry.Value.ToString());
            }
            foreach (var entry in OrginalValues2)
            {
                magi.WriteMemory(entry.Key.ToString("X"), "int", entry.Value.ToString());
            }
        }
        public void AimbotOn()
        {
            foreach (var entry in OrginalValues3)
            {
                magi.WriteMemory(entry.Key.ToString("X"), "int", entry.Value.ToString());

            }
            foreach (var entry in OrginalValues4)
            {
                magi.WriteMemory(entry.Key.ToString("X"), "int", entry.Value.ToString());
            }
        }
        public async void EnableAimbotSecurity()
        {
            ShowMessageBox("Aimbot Secured Activating", "", "");
            OrginalValues1.Clear();
            OrginalValues2.Clear();
            OrginalValues3.Clear();
            OrginalValues4.Clear();

            Int64 readoffset = Convert.ToInt64(headoffset, 16);
            Int64 writeoffset = Convert.ToInt64(chestoffset, 16);
            Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
            magi.OpenProcess(proc);
            var result = await magi.AoBScan2(AimbotScan, true, true);
            if (result.Count() != 0)
            {
                foreach (var CurrentAddress in result)
                {
                    Int64 addressToSave = CurrentAddress + writeoffset;
                    var currentBytes = magi.readMemory(addressToSave.ToString("X"), sizeof(int));
                    int currentValue = BitConverter.ToInt32(currentBytes, 0); OrginalValues1[addressToSave] = currentValue;
                    Int64 addressToSave9 = CurrentAddress + readoffset;
                    var currentBytes9 = magi.readMemory(addressToSave9.ToString("X"), sizeof(int));
                    int currentValue9 = BitConverter.ToInt32(currentBytes9, 0); OrginalValues2[addressToSave9] = currentValue9;
                    Int64 headbytes = CurrentAddress + readoffset;
                    Int64 chestbytes = CurrentAddress + writeoffset;
                    var bytes = magi.readMemory(headbytes.ToString("X"), sizeof(int));
                    int Read = BitConverter.ToInt32(bytes, 0);
                    var bytes2 = magi.readMemory(chestbytes.ToString("X"), sizeof(int));
                    int Read2 = BitConverter.ToInt32(bytes2, 0);
                    magi.WriteMemory(chestbytes.ToString("X"), "int", Read.ToString());
                    magi.WriteMemory(headbytes.ToString("X"), "int", Read2.ToString());
                    Int64 addressToSave1 = CurrentAddress + writeoffset;
                    var currentBytes1 = magi.readMemory(addressToSave1.ToString("X"), sizeof(int));
                    int currentValue1 = BitConverter.ToInt32(currentBytes1, 0); OrginalValues1[addressToSave1] = currentValue1;
                    Int64 addressToSave19 = CurrentAddress + readoffset;
                    var currentBytes19 = magi.readMemory(addressToSave19.ToString("X"), sizeof(int));
                    int currentValue19 = BitConverter.ToInt32(currentBytes19, 0); OrginalValues4[addressToSave19] = currentValue19;
                    ShowMessageBox("Aimbot Secured Activated", "", "");


                }

            }
            else
            {
                ShowMessageBox("Error ASC", "", "");
            }
        }
        
        #endregion




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
