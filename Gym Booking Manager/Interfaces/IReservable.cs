﻿using Gym_Booking_Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Gym_Booking_Manager
{
    internal interface IReservable 
    {
        void MakeReservation(User person);
        void CancelReservation(Reservation reservation);
        void ViewTimeTable(); // start and end as arguments?
    }
}
