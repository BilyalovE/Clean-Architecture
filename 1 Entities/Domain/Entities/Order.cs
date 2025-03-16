using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Domain.Enums;

namespace Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public OrderStatus Status { get; set; }
    public ICollection<OrderItem> Items { get; set; }

    // Для рич моделей
    // public decimal GetTotal()
    // {
    //     return Items.Sum(x => x.Product.Price * x.Quantity);
    // }
}