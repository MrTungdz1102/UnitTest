using ProjectTest.ApplicationCore.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.IntegrationTests
{
    public class ObjectCompare : IComparer
    {
        public int Compare(object? x, object? y)
        {
            var booking1 = (StudyRoomBooking)x;
            var booking2 = (StudyRoomBooking)y;
            if(booking1.BookingId != booking2.BookingId)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
