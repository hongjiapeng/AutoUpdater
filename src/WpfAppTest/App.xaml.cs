using System;
using System.Windows;

namespace WpfAppTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //AutoUpdater.Start("1.9.0.0",
            //                   "2.0.0.0",
            //                   "http://192.168.1.192/doku.php?id=project:yinxiaotong:release",
            //                   "http://samples.mplayerhq.hu/MPEG-4/video.mp4",
            //                   AppDomain.CurrentDomain.BaseDirectory,
            //                   "11cc1744cbf531df1fa1b388e47a478d");



            base.OnStartup(e);
        }
    }
}
