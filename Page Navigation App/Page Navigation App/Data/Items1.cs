using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Items
{
    [Key] // Определите это свойство как первичный ключ
    public string name { get; set; }
    public int price { get; set; }
    public string imagePath { get; set; }
    public int id { get; set; }
    public int state { get; set; }
}
