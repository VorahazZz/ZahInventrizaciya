using System;
using System.Windows;
using System.Windows.Controls;
using ZahInventrizaciya.Entities;

namespace ZahInventrizaciya.Windows;

public partial class AddEditTeacherWindow : Window
{
    private Teacher? _teacher = new Teacher();
    private readonly ApplicationContext _db = new();

    public AddEditTeacherWindow(Teacher? teacher)
    {
        InitializeComponent();
        if (teacher is not null)
        {
            _teacher = teacher;
            GroupBox.Header = "Редактирование учителя";
            ApplyBtn.Content = "Изменить";
            Title = "Редактирование учителя";
        }

        DataContext = _teacher;
    }

    private async void ApplyBtn_OnClick(object sender, RoutedEventArgs e)
    {
        if (LoginTeacherTBox.Text == "" &&
            PasswordTeacherTBox.Text == "" &&
            PersonalTeacherTBox.Text == "" &&
            FirstNameTeacherTBox.Text == "" &&
            LastNameTeacherTBox.Text == "" &&
            SecondNameTeacherTBox.Text == "")
        {
            MessageBox.Show("Не все поля заполнены", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        else
        {
            if (_teacher is not null)
                if (_teacher.Id != 0)
                {
                    _db.Update(_teacher);

                }

                else
                {
                    await _db.AddAsync(_teacher);
                }


            await _db.SaveChangesAsync();
            Close();
        }
    }

    private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}