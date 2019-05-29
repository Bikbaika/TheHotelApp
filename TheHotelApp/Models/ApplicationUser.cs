using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheHotelApp.Models
{
    public class ApplicationUser
    {
        public string CustomerName { get; set; } //ФИО
        public int PassportId { get; set; } //Номер паспорта
        public int PassportSer { get; set; } //Серия паспорта
        public string Address { get; set; } //Адрес
        public string CitizenShip { get; set; } //Гражданство
        public List<Booking> Bookings { get; set; }
    }
}
