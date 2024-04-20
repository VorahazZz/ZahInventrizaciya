using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ZahInventrizaciya.Helpers;

public abstract class IsNullChecker
{
    public delegate void ShowEditWindowDelegate<in T>(T obj);
    
    public static void IsNullEdit<T>(ShowEditWindowDelegate<T> showEditWindowDelegate, DataGrid dataGrid)
    {
        if (dataGrid.SelectedItem is T obj)
            showEditWindowDelegate(obj);
        else
            MessageBox.Show(
                "Выберите для редактирования объект из таблицы",
                "Редактирование",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
    }

    public static async void IsNullDel<T>(DataGrid dataGrid, ApplicationContext db)
    {
        if (dataGrid.SelectedItem is T obj)
        {
            db.Remove(obj);
            await db.SaveChangesAsync();
        }
        else
            MessageBox.Show(
                "Выберите для удаленияя объект из таблицы",
                "Удаление",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
    }
}