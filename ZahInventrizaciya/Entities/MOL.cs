namespace ZahInventrizaciya.Entities;
/// <summary>
/// Материально ответственное лицо
/// </summary>
public class MOL
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Id преподавателя
    /// </summary>
    public int TeacherId { get; set; }
    /// <summary>
    /// Преподаватель
    /// </summary>
    public Teacher Teacher { get; set; } = null!;
    /// <summary>
    /// Должность
    /// </summary>
    public string Speciality { get; set; } = null!;
}