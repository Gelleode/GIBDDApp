using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GIBDDApp
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        int Attempts = 5;
        public AuthPage()
        {
            InitializeComponent();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            var Username = TBoxName.Text;
            var Password = PBoxPassword.Password;

            if (!(Username == "Inspector" & Password == "Inspector"))
            {
                Attempts = Attempts - 1;
                if (Attempts == 0)
                    System.Windows.Application.Current.Shutdown();
                MessageBox.Show($"Wrong username or password \n Attempts left = {Attempts}");
                return;
            };
            Attempts = 5;
            Manager.MainFrame.Navigate(new DriversPage());
        }
    }
}
