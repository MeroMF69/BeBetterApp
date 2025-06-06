using System.Configuration;
using System.Data;
using System.Windows;
using Syncfusion.Licensing;


namespace BeBetterApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // ⬇️ Hier deinen 7-Tage-Lizenzschlüssel einfügen
            SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NNaF1cWWhPYVJ1WmFZfVtgdVRMZFpbQXFPMyBoS35Rc0VlWXlfcXBTQ2daUUZ+VEBU");

            base.OnStartup(e);
        }
    }

}
