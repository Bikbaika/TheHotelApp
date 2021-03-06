﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheHotelApp.Models
{
    public class RoomType //Класс обслуживания
    {
        public string ID { get; set; } //ID
        public string Name { get; set; } //Вид номера
        public decimal BasePrice { get; set; } //Стоимость номера
        public string Description { get; set; } //Периодичность обслуживания
        public virtual ICollection<Room> Rooms { get; set; }
        // public string ImageUrl { get; set; }
    }
}
