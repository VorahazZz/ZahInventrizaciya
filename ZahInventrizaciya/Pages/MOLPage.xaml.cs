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
using Microsoft.EntityFrameworkCore;
using ZahInventrizaciya.Entities;
using ZahInventrizaciya.Windows;

namespace ZahInventrizaciya
{
    /// <summary>
    /// Логика взаимодействия для MOLPage.xaml
    /// </summary>
    public partial class MOLPage : Page
    {
        private readonly ApplicationContext _db = new();
        public MOLPage()
        {
            InitializeComponent();
            MOLDataGrid.ItemsSource = _db.MOLs.Include(x => x.Teacher).ToList();
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            new AddEditMolWindow(null).ShowDialog();
            Helpers.Refresher.RefreshTable(_db.MOLs.Include(x=>x.Teacher).ToList(), MOLDataGrid);
        }

        private void BtnChange_OnClick(object sender, RoutedEventArgs e)
        {
            Helpers.IsNullChecker.IsNullEdit<MOL>(mol =>
            {
                new AddEditMolWindow(mol).ShowDialog();
            }, MOLDataGrid);
            Helpers.Refresher.RefreshTable(_db.MOLs.Include(x=>x.Teacher).ToList(), MOLDataGrid);
        }

        private void BtnDel_OnClick(object sender, RoutedEventArgs e)
        {
            Helpers.IsNullChecker.IsNullDel<MOL>(MOLDataGrid, _db);
            Helpers.Refresher.RefreshTable(_db.MOLs.Include(x=>x.Teacher).ToList(), MOLDataGrid);
        }
    }
}
