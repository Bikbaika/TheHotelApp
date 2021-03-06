﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheHotelApp.Models
{
    public class Room //Описание номера
    {
        public string ID { get; set; } //ID
        public int Number { get; set; } //Номер номера
        public string RoomTypeID { get; set; }
        public virtual RoomType RoomType { get; set; } //Вид номера
        public string Description { get; set; } //Расположение
        public virtual ICollection<Room> Rooms { get; set; }

        //  public decimal Price { get; set; }
        //  public bool Available { get; set; }
        //  public int MaximumGuests { get; set; }
        //  public virtual List<Feature> Features { get; set; }
        //  public virtual List<Image> RoomImages { get; set; }
        //  public virtual List<Review> Reviews { get; set; }
        //  public virtual List<Booking> Bookings { get; set; }
    }
}
