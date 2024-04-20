namespace ZahInventrizaciya.Entities;
/// <summary>
/// Предметы и кабинеты
/// </summary>
public class ItemsAndClassrooms
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Id кабинета
    /// </summary>
    public int ClassroomId { get; set; }
    /// <summary>
    /// Кабинет
    /// </summary>
    public Classroom Classroom { get; set; } = null!;
    /// <summary>
    /// Id предмета
    /// </summary>
    public int ItemId { get; set; }
    /// <summary>
    /// Предмет
    /// </summary>
    public Item Item { get; set; } = null!;
}