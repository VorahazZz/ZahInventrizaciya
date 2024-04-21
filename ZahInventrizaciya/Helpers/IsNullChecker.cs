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
        try
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
        catch (Exception e)
        {
            MessageBox.Show(
                "Неизвестная ошибка. Перезапустите программу. Если ошибка повторится, то обратитесь к разработчику",
                "Неизвестная ошибка",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }

    public static void IsNullDel<T>(DataGrid dataGrid, ApplicationContext db)
    {
        try
        {
            if (dataGrid.SelectedItem is T obj)
            {
                db.Remove(obj);
                db.SaveChanges();
            }
            else
                MessageBox.Show(
                    "Выберите для удаленияя объект из таблицы",
                    "Удаление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
        }
        catch (Exception e)
        {
            MessageBox.Show(
                "Неизвестная ошибка. Перезапустите программу. Если ошибка повторится, то обратитесь к разработчику",
                "Неизвестная ошибка",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }
}