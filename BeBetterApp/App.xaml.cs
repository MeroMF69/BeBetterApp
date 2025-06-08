using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using Syncfusion.Licensing;
using Syncfusion.SfSkinManager;

namespace BeBetterApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Lizenz laden
            try
            {
                string licensePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "license", "license.txt");
                string licenseKey = File.ReadAllText(licensePath).Trim();
                SyncfusionLicenseProvider.RegisterLicense(licenseKey);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lizenz konnte nicht geladen werden: " + ex.Message);
            }

            // Theme aktivieren
            SfSkinManager.ApplyStylesOnApplication = true;

            // Dummy-Termine (leer für den Start)
            var appointments = new ObservableCollection<AppointmentItem>();

            // Fenster starten mit Übergabe
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}

