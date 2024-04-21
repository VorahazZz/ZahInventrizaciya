using System;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using ZahInventrizaciya.Entities;

namespace ZahInventrizaciya.Windows;

public partial class AddEditItemsAndClassrooms : Window
{
    private readonly ApplicationContext _db = new ApplicationContext();
    private readonly ItemsAndClassrooms _itemsAndClassrooms = new ItemsAndClassrooms();

    public AddEditItemsAndClassrooms(ItemsAndClassrooms? itemsAndClassrooms)
    {
        InitializeComponent();
        if (itemsAndClassrooms is not null)
        {
            _itemsAndClassrooms = itemsAndClassrooms;
        }
        DataContext = _itemsAndClassrooms;
        KabComBox.ItemsSource = _db.Classrooms.ToList();
        ObjComBox.ItemsSource = _db.Items.ToList();
    }

    private void BackBtn_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private async void AddBtn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var classroom = (Classroom)KabComBox.SelectedItem;
            var item = (Item)ObjComBox.SelectedItem;
            _itemsAndClassrooms.ClassroomId = classroom.Id;
            _itemsAndClassrooms.ItemId = item.Id;
            if (_itemsAndClassrooms.Id == 0)
            {
                await _db.AddAsync(_itemsAndClassrooms);
            }

            else
            {
                _db.Update(_itemsAndClassrooms);
            }

            await _db.SaveChangesAsync();
            Close();
        }
        catch (Exception exception)
        {
            MessageBox.Show(
                "Вы заполнили не все поля",
                "Ошибка добавления",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }
    }
}