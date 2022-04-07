using System;
using System.IO;
using ToDos.Data;
using Xamarin.Forms;

namespace ToDos
{
    public partial class App : Application
    {
        static ToDosDatabase db;

        internal static ToDosDatabase DB
        {
            get
            {
                if (db == null)
                {
                    db = new ToDosDatabase(Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "ToDos.db3"));  // user/... app\data.db3
                }

                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()); // opakowanie navigation page
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
