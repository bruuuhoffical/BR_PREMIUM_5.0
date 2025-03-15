using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Bruuuh;
using Memory;
using PREMIUM_6._0.Views;

namespace PREMIUM_6._0.Menu.Visuals
{
    public class ChamsMenu
    {
        private Home _mainForm;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        public ChamsMenu(Home mainForm)
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
        #region DLL INJECTION SYSTEM
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr LoadLibraryA(string lpLibFileName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FreeLibrary(IntPtr hModule);

        const uint PROCESS_CREATE_THREAD = 0x2;
        const uint PROCESS_QUERY_INFORMATION = 0x400;
        const uint PROCESS_VM_OPERATION = 0x8;
        const uint PROCESS_VM_WRITE = 0x20;
        const uint PROCESS_VM_READ = 0x10;
        const uint MEM_COMMIT = 0x1000;
        const uint PAGE_READWRITE = 4;

        private static void inject(string resourceName, string outputPath)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            using (Stream resourceStream = executingAssembly.GetManifestResourceStream(resourceName))
            {
                if (resourceStream == null)
                {
                    throw new ArgumentException($"Resource '{resourceName}' not found.");
                }
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create))
                {
                    byte[] buffer = new byte[resourceStream.Length];
                    resourceStream.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                }
            }
        }

        #endregion
        public void EnableChamsMenu()
        {
            if(Bool.isChamsHooked == false)
            {
                Notify("Please Start Chams !", "1000");
                return;
            }
            else if(Bool.isChamsHooked == true)
            {
                if(Bool.ChamsMenu == 0)
                {
                    ChamsMenuNormal();
                }
                else if(Bool.ChamsMenu == 1)
                {
                    ChamsMenuNormalV2();
                }
                else if(Bool.ChamsMenu == 2)
                {
                    ChamsMenuOverlay();
                }
                else if(Bool.ChamsMenu == 3)
                {
                    ChamsMenuOverlayV2();
                }
            }
        }
        #region Menu
        public void ChamsMenuNormal()
        {
            string processName = "HD-Player";
            string glew = "PREMIUM_6._0.Properties.cnormal.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "cnormal.dll");


            inject(glew, glewpath);

            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                Notify("Open Emulator", "2000");
                return;
            }

            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                Notify("Process Failure", "2000");
                return;
            }
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, MEM_COMMIT, PAGE_READWRITE);
            IntPtr bytesWritten;
            WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(glewpath), (uint)glewpath.Length, out bytesWritten);
            IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

            if (hThread == IntPtr.Zero)
            {
                Notify("Chams Menu Failed", "2000");
            }
            else
            {
                Notify("Chams Menu Enabled", "400");
            }
        }
        public void ChamsMenuNormalV2()
        {
            string processName = "HD-Player";
            string glew = "PREMIUM_6._0.Properties.cnormalv2.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "cnormalv2.dll");


            inject(glew, glewpath);

            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                Notify("Open Emulator", "2000");
                return;
            }

            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                Notify("Process Failure", "2000");
                return;
            }
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, MEM_COMMIT, PAGE_READWRITE);
            IntPtr bytesWritten;
            WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(glewpath), (uint)glewpath.Length, out bytesWritten);
            IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

            if (hThread == IntPtr.Zero)
            {
                Notify("Chams Menu V2 Failed", "2000");
            }
            else
            {
                Notify("Chams Menu V2 Enabled", "400");
            }
        }



        public void ChamsMenuOverlay()
        {
            string processName = "HD-Player";
            string glew = "PREMIUM_6._0.Properties.coverlay.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "coverlay.dll");


            inject(glew, glewpath);

            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                Notify("Open Emulator", "2000");
                return;
            }

            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                Notify("Process Failure", "2000");
                return;
            }
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, MEM_COMMIT, PAGE_READWRITE);
            IntPtr bytesWritten;
            WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(glewpath), (uint)glewpath.Length, out bytesWritten);
            IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

            if (hThread == IntPtr.Zero)
            {
                Notify("Chams Overlay Failed", "2000");
            }
            else
            {
                Notify("Chams Overlay Enabled", "400");
            }
        }
        public void ChamsMenuOverlayV2()
        {
            string processName = "HD-Player";
            string glew = "PREMIUM_6._0.Properties.coverlayv2.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "coverlayv2.dll");


            inject(glew, glewpath);

            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                Notify("Open Emulator", "2000");
                return;
            }

            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                Notify("Process Failure", "2000");
                return;
            }
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, MEM_COMMIT, PAGE_READWRITE);
            IntPtr bytesWritten;
            WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(glewpath), (uint)glewpath.Length, out bytesWritten);
            IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

            if (hThread == IntPtr.Zero)
            {
                Notify("Chams Overlay V2 Failed", "2000");
            }
            else
            {
                Notify("Chams Overlay V2 Enabled", "400");
            }
        }
        #endregion
    }
}
