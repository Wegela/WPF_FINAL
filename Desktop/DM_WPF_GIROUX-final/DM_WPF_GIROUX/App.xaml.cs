using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DM_WPF_GIROUX
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IView
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // En XAML on avait l'attribut : StartupUri="MainWindow.xaml"
            // Equivalent C# :
            //
            // MainWindow win = new MainWindow();
            // win.Show();

            MainWindow win = new MainWindow();
            win.DataContext = new MainViewModel(this); // Définit l'objet partagé avec XAML
            win.Show();
        }

        public void Affiche(MainViewModel c)
        {
            LittleWindow win = new LittleWindow();
            win.DataContext = c; // Définit l'objet partagé avec XAML
            win.Show();
        }
    }
}
