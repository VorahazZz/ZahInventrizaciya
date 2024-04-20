namespace ZahInventrizaciya.Entities;
/// <summary>
/// Преподаватели
/// </summary>
public class Teacher
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    public string Firstname { get; set; } = null!;
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Secondname { get; set; } = null!;
    /// <summary>
    /// Отчество
    /// </summary>
    public string Lastname { get; set; } = null!;
    /// <summary>
    /// Табельный номер
    /// </summary>
    public ulong PersonalNumber { get; set; }
    /// <summary>
    /// Логин
    /// </summary>
    public string Login { get; set; } = null!;
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; } = null!;
}