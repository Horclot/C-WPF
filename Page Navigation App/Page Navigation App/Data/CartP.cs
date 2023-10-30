using Microsoft.EntityFrameworkCore;
public class CartP
{
    public int UserId { get; set; }
    public int CartId { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
}
