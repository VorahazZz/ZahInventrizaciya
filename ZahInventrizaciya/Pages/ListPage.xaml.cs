using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        private readonly ApplicationContext _db = new ApplicationContext();
        public ListPage()
        {
            InitializeComponent();
            ItemsDataGrid.ItemsSource = _db.Items.ToList();
        }

        private void AddBtn_OnClick(object sender, RoutedEventArgs e)
        {
            new AddEditItem(null).ShowDialog();
            Helpers.Refresher.RefreshTable(_db.Items.ToList(), ItemsDataGrid);
        }

        private void EditBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Helpers.IsNullChecker.IsNullEdit<Item>(item =>
            {
                new AddEditItem(item).ShowDialog();
            }, ItemsDataGrid);
            Helpers.Refresher.RefreshTable(_db.Items.ToList(), ItemsDataGrid);
        }

        private void DelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Helpers.IsNullChecker.IsNullDel<Item>(ItemsDataGrid, _db);
           
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchInvNumTBox.Text;
            if (Regex.IsMatch(searchText, @"^[0-9]+$"))
            {
                var qwe = _db.Items.ToList();
                ItemsDataGrid.ItemsSource = searchText != ""
                    ? qwe.Where(x => x.InventoryNumber.Contains(SearchInvNumTBox.Text))
                    : qwe;
            }

            else
            {
                SearchInvNumTBox.Text = searchText != "" ? searchText.Remove(searchText.Length - 1) : searchText;
            }
        }
    }
}
