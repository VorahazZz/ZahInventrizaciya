using System;

namespace ZahInventrizaciya.Entities;
/// <summary>
/// Предмет
/// </summary>
public class Item
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Дата выпуска
    /// </summary>
    public DateOnly Date { get; set; }

    /// <summary>
    /// Инвентаризационный номер
    /// </summary>
    public string InventoryNumber { get; set; } = null!;
    /// <summary>
    /// Название предмета
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// Кол-во
    /// </summary>
    public int Count { get; set; }
}