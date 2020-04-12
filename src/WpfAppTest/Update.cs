using System;
using System.Diagnostics;
using System.IO;

namespace WpfAppTest
{
    public class Update
    {
        public static void CheckUpdate(string currentVersion, string newVersion, string updateLogUrl, string updateFileUrl, string unpackPath, string fileMd5)
        {
            var appPath = AppDomain.CurrentDomain.BaseDirectory + "AutoUpdater.exe";

            //同时启动自动更新程序
            if (File.Exists(appPath) &&
                new Version(currentVersion) <
                new Version(newVersion))
            {
                var processStartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = false,
                    FileName = "AutoUpdater.exe",
                    Arguments = $"{currentVersion} " +
                                $"{newVersion} " +
                                $"{updateLogUrl} " +
                                $"{updateFileUrl} " +
                                $"{unpackPath} " +
                                $"{fileMd5}"
                };
                var proc = Process.Start(processStartInfo);
                if (proc != null)
                {
                    proc.WaitForExit();
                }
            }
        }

    }
}
