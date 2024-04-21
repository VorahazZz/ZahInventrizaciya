using System.Windows;
using ZahInventrizaciya.Entities;

namespace ZahInventrizaciya.Windows;

public partial class AddEditItemsAndClassrooms : Window
{
    public AddEditItemsAndClassrooms(ItemsAndClassrooms? itemsAndClassrooms)
    {
        InitializeComponent();
    }

    private void BackBtn_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void AddBtn_Click(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}