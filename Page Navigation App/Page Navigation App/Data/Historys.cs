using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Historys
{
    [Key] // Определите это свойство как первичный ключ
    public string data { get; set; }
    public string itemName { get; set; }
    public int price { get; set; }
    public string status { get; set; }
    public int usersId { get; set; }

}
