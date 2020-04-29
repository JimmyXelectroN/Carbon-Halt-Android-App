using System;
using System.IO;
using System.Runtime.InteropServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarbonHalt
{
    public partial class App : Application
    {
        static Database database;
        
        public static Database Database 
        {
            get 
            {
                if (database == null) 
                {
                    database = new Database(Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                        "emissionLevels.db3"));
                }
                return database;
            }
        }
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjQyOTQxQDMxMzgyZTMxMmUzMFJ2NDZyanFrWWhlTFhGNThUS09vaVJIdmpOUEhnWEN6cUJ2OGh6YjhjL009");
            InitializeComponent();

            MainPage = new NavigationPage(new Dashboard()); ;
        }
    }
}
