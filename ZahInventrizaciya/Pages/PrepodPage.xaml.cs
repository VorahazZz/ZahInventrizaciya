using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZahInventrizaciya.Entities;
using ZahInventrizaciya.Windows;

namespace ZahInventrizaciya.Pages
{
    /// <summary>
    /// Логика взаимодействия для PrepodPage.xaml
    /// </summary>
    public partial class PrepodPage : Page
    {
        private readonly ApplicationContext _db = new();
        public PrepodPage()
        {
            InitializeComponent();
            TeachersDataGrid.ItemsSource = _db.Teachers.ToList();
        }


        private void AddTeacherBtn_OnClick(object sender, RoutedEventArgs e)
        {
            new AddEditTeacherWindow(null).ShowDialog();
            Helpers.Refresher.RefreshTable(_db.Teachers.ToList(), TeachersDataGrid);
        }

        private void DelTeacherBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Helpers.IsNullChecker.IsNullDel<Teacher>(TeachersDataGrid, _db);
            Helpers.Refresher.RefreshTable(_db.Teachers.ToList(), TeachersDataGrid);
        }

        private void EditTeacherBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Helpers.IsNullChecker.IsNullEdit<Teacher>(teacher =>
            {
                new AddEditTeacherWindow(teacher).ShowDialog();
            }, TeachersDataGrid);
            Helpers.Refresher.RefreshTable(_db.Teachers.ToList(), TeachersDataGrid);
        }
    }
}