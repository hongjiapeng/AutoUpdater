using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

public class AutoUpdater
{
    public static void Start(string xmlUri)
    {
        var doc = XDocument.Load(xmlUri);
        var app = XMLSerializer.Deserialize<AppInfo>(doc.ToString());

        CheckUpdate(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                    app.NewVersion,
                    app.UpdateLogUrl,
                    app.UpdateFileUrl,
                    AppDomain.CurrentDomain.BaseDirectory,
                    app.FileMd5);
    }

    private static void CheckUpdate(string currentVersion, string newVersion, string updateLogUrl, string updateFileUrl, string unpackPath, string fileMd5)
    {
        var appName = "AutoUpdater.exe";
        var appPath = unpackPath + appName;
        if (File.Exists(appPath) &&
            new Version(currentVersion) <
            new Version(newVersion))
        {
            var process = Process.GetCurrentProcess();
            var processStartInfo = new ProcessStartInfo()
            {
                UseShellExecute = false,
                FileName = appName,
                Arguments = $"{currentVersion} " +
                            $"{newVersion} " +
                            $"{updateLogUrl} " +
                            $"{updateFileUrl} " +
                            $"{unpackPath} " +
                            $"{fileMd5} "+
                            $"{process.ProcessName}.exe"
            };
            Process.Start(processStartInfo);
            process.Kill();
        }
    }
}

