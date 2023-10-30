using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class CartP
{
    [Key] // Определите это свойство как первичный ключ
    public int CartId { get; set; }
    public int UserId { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
}
