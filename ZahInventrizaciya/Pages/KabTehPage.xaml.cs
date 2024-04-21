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
    /// Логика взаимодействия для KabTehPage.xaml
    /// </summary>
    public partial class KabTehPage : Page
    {
        private readonly ApplicationContext _db = new ApplicationContext();
        public KabTehPage()
        {
            InitializeComponent();
            ClassroomsDataGrid.ItemsSource = _db.Classrooms.Include(x => x.MOL.Teacher).ToList();
        }

        private void BtnAddKab_Click(object sender, RoutedEventArgs e)
        {
            new AddEditClassroom(null).ShowDialog();
            Helpers.Refresher.RefreshTable(_db.Classrooms.ToList(),ClassroomsDataGrid);
        }

        private void BtnChangeKab_OnClick(object sender, RoutedEventArgs e)
        {
            Helpers.IsNullChecker.IsNullEdit<Classroom>(classroom =>
            {
                new AddEditClassroom(classroom).ShowDialog();
            },ClassroomsDataGrid);
            Helpers.Refresher.RefreshTable(_db.Classrooms.ToList(), ClassroomsDataGrid);
        }

        private void BtnDelKab_OnClick(object sender, RoutedEventArgs e)
        {
            Helpers.IsNullChecker.IsNullDel<Classroom>(ClassroomsDataGrid, _db);
            Helpers.Refresher.RefreshTable(_db.Classrooms.ToList(),ClassroomsDataGrid);
        }
    }
}
