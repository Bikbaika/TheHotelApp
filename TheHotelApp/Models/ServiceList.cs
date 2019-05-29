using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheHotelApp.Models
{
    public class ServiceList // Перечень услуг
    {
        public Guid ID { get; set; } // Номер услуги
        public string Name { get; set; } // Наименование
        public decimal BasePrice { get; set; } //Стоимость номера
        public string Description { get; set; } //Единицы измеренмя
    }
}
