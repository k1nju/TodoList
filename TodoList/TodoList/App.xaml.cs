using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace TodoList
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var cultureInfo = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture= cultureInfo;
            CultureInfo.DefaultThreadCurrentCulture= cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture= cultureInfo;
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
                new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
            base.OnStartup(e);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow otherWindow = new TodoList.MainWindow();
            otherWindow.Show();
        }
    }
}
