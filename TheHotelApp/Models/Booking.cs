using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHotelApp.Models;

namespace TheHotelApp.Models
{
    public class Booking //Заказ
    {
        public Guid ID { get; set; } //Номер заказа
        public Guid RoomID { get; set; } // Номер номера
        public virtual Room Room { get; set; }
        public DateTime DateCreated { get; set; } //Дата заказа
        public DateTime CheckIn { get; set; } //Дата прибытия
        public DateTime CheckOut { get; set; } //Дата выезда
        public decimal TotalFee { get; set; } //Стоимость
        public Guid ApplicationUserId { get; set; } //Номер клиента
        public virtual ApplicationUser ApplicationUser { get; set; }

     //   public int Guests { get; set; }
        
     //   public bool Paid { get; set; }
     //   public bool Completed { get; set; }

     //   public string CustomerName { get; set; }
     //   public string CustomerEmail { get; set; }
     //   public string CustomerPhone { get; set; }
      //  public string CustomerAddress { get; set; }
      //  public string CustomerCity { get; set; }
     //   public string OtherRequests { get; set; }
    }
}
