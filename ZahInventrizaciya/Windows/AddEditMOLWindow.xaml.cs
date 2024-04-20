using System.Linq;
using System.Windows;
using ZahInventrizaciya.Entities;

namespace ZahInventrizaciya.Windows;

public partial class AddEditMolWindow : Window
{
    private readonly ApplicationContext _db = new();
    private MOL? _mol = new MOL();

    public AddEditMolWindow(MOL? mol)
    {
        InitializeComponent();
        if (mol is not null)
        {
            _mol = mol;
            Title = "Редактирование материально ответственного лица";
            ApplyBtn.Content = "Изменить";
            GroupBox.Header = "Редактирование МОЛ";
        }

        DataContext = _mol;
        TeachersComBox.ItemsSource = _db.Teachers.ToList();
    }

    private async void ApplyBtn_OnClick(object sender, RoutedEventArgs e)
    {
        if (SpecialityTBox.Text == "")
        {
            MessageBox.Show("Не все поля заполнены", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        else
        {
            if (TeachersComBox.SelectedItem is not Teacher teacher) return;
            
            if (_mol is null) return;
            
            _mol.Teacher = teacher;
            if (_mol.Id != 0)
            {
                _db.Update(_mol);
            }
            else
            {
                await _db.AddAsync(_mol);
            }

            await _db.SaveChangesAsync();
            Close();
        }
    }

    private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}