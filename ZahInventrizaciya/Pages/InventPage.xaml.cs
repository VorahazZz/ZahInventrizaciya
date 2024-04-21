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
    /// Логика взаимодействия для InventPage.xaml
    /// </summary>
    public partial class InventPage : Page
    {
        private readonly ApplicationContext _db = new ApplicationContext();
        public InventPage()
        {
            InitializeComponent();
            KabDG.ItemsSource = _db.Classrooms.Include(x => x.MOL.Teacher).ToList();
            KabDG.SelectedIndex = 0;
            DgFill();
        }

        private void DgFill()
        {
            var currentClassroom = (Classroom)KabDG.SelectedItem;
            var itemsList = _db.ItemsAndClassrooms.Include(x => x.Item).ToList();
            ObjDG.ItemsSource = itemsList.Where(x => x.ClassroomId == currentClassroom.Id);
        }
        
        private void ObjDG_LoadingRow(object? sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        
        private void KabDG_LoadingRow(object? sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
        
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            new AddEditItemsAndClassrooms(null).ShowDialog();
            Helpers.Refresher.RefreshTable(_db.Classrooms.Include(x => x.MOL.Teacher).ToList(), KabDG);
            DgFill();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Helpers.IsNullChecker.IsNullEdit<ItemsAndClassrooms>(itemsAndClassrooms =>
            {
                new AddEditItemsAndClassrooms(itemsAndClassrooms).ShowDialog();
            }, ObjDG);
            Helpers.Refresher.RefreshTable(_db.Classrooms.Include(x => x.MOL.Teacher).ToList(), KabDG);
            DgFill();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            Helpers.IsNullChecker.IsNullDel<ItemsAndClassrooms>(ObjDG, _db);
            DgFill();
        }

        private void KabDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DgFill();
        }

        private void InventPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            KabDG.SelectedIndex = 0;
        }
    }
}
