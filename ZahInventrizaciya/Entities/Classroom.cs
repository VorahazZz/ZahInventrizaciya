namespace ZahInventrizaciya.Entities;
/// <summary>
/// Кабинет
/// </summary>
public class Classroom
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Номер кабинета
    /// </summary>
    public int PersonalNumber { get; set; }
    /// <summary>
    /// Название кабинета
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// Id МОЛ за кабинет
    /// </summary>
    public int MOLId { get; set; }
    /// <summary>
    /// Материально ответсвенное лицо
    /// </summary>
    public MOL MOL { get; set; }
}