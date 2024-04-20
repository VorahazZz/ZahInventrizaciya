using System.Collections.Generic;
using System.Windows.Controls;

namespace ZahInventrizaciya.Helpers;

public abstract class Refresher
{
    public static void RefreshTable<T>(List<T> objList, DataGrid dataGrid)
    {
        dataGrid.ItemsSource = objList;
    }
}