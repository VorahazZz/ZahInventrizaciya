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
using ZahInventrizaciya.Pages;

namespace ZahInventrizaciya
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (TboxLogin.Text == "" || Pbox.Password == "")
            {
                MessageBox.Show("Вы должны ввести логин и пароль!", "Ошибка входа", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            await using (var db = new ApplicationContext())
            {
                var user = db.Teachers.FirstOrDefault(x => x.Login == TboxLogin.Text && x.Password == Pbox.Password);
                if (user is null)
                {
                    MessageBox.Show("Вы ввели неверный логин или пароль!", "Ошибка входа", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
            }

            for (var i = 0; i <= 210; i+=10)
            {
                MenuColumn.Width = new GridLength(i);
                await Task.Delay(30);
            }
            
            BtnInfo.IsEnabled = true;
            BtnInvent.IsEnabled = true;
            BtnKab.IsEnabled = true;
            BtnLogOut.IsEnabled = true;
            BtnMOL.IsEnabled = true;
            BtnPredm.IsEnabled = true;
            BtnPrepod.IsEnabled = true;
        }

        private async void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            BtnInfo.IsEnabled = false;
            BtnInvent.IsEnabled = false;
            BtnKab.IsEnabled = false;
            BtnLogOut.IsEnabled = false;
            BtnMOL.IsEnabled = false;
            BtnPredm.IsEnabled = false;
            BtnPrepod.IsEnabled = false;
            Title = "Инвентаризация | Вход";
            FrameContent.Visibility = Visibility.Hidden;
            
            for (var i = 210; i >= 0; i-=10)
            {
                MenuColumn.Width = new GridLength(i);
                await Task.Delay(30);
            }
        }

        private void BtnKab_Click(object sender, RoutedEventArgs e)
        {
            Title = "Инвентаризация | Кабинеты техникума";
            FrameContent.Visibility = Visibility.Visible;
            FrameContent.Navigate(new KabTehPage());
        }

        private void BtnInvent_Click(object sender, RoutedEventArgs e)
        {
            Title = "Инвентаризация | Инвентаризация";
            FrameContent.Visibility = Visibility.Visible;
            FrameContent.Navigate(new InventPage());
        }

        private void BtnPredm_Click(object sender, RoutedEventArgs e)
        {
            Title = "Инвентаризация | Список имущества";
            FrameContent.Visibility = Visibility.Visible;
            FrameContent.Navigate(new ListPage());
        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            Title = "Инвентаризация | О программе";
            FrameContent.Visibility = Visibility.Visible;
            FrameContent.Navigate(new InfoPage());
        }

        private void BtnMOL_Click(object sender, RoutedEventArgs e)
        {
            Title = "Инвентаризация | МОЛ";
            FrameContent.Visibility = Visibility.Visible;
            FrameContent.Navigate(new MOLPage());
        }

        private void BtnPrepod_Click(object sender, RoutedEventArgs e)
        {
            FrameContent.Navigate(new PrepodPage());
            Title = "Инвентаризация | Преподаватели";
            FrameContent.Visibility = Visibility.Visible;
        }
    }
}