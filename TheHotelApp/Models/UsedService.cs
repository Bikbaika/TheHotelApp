using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheHotelApp.Models
{
    public class UsedService
    {
        public Guid ID { get; set; } // Номер используемой услуги
        public string Name { get; set; } // Наименование
        public decimal BasePrice { get; set; } //Стоимость номера
        public DateTime Date { get; set; } //Дата 
        public string Description { get; set; } //Единицы измеренмя
        public Guid BookingId { get; set; } //Номер заказа
        public virtual Booking Booking { get; set; }
        public Guid ServiceListId { get; set; } //Номер заказа
        public virtual ServiceList ServiceList { get; set; }
    }
}
