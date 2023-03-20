﻿using System.Reflection.Metadata.Ecma335;

namespace BarberShop.Models
{
    public class Reservation : BaseEntity
    {
        public int ReservationId { get; set; }
        public DateOnly ReservationDate { get; set; }
        public TimeOnly ReservationTime { get; set; }
        public bool BarberApprove { get; set; }
        public bool CustomerApprove { get; set; }
        public string DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public Barber Barber { get; set; }
        public Customer Customer { get; set; }
    }
}